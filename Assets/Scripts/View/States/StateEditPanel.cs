using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class StateEditPanel : MonoBehaviour
{
    public GameObject panel;
    public Button labelButton;
    private AutomatonNode automaton;
    [SerializeField] private StateNode stateNode;
    [SerializeField] private Button deleteButton;
    [SerializeField] private Button resetButton;
    [SerializeField] private Toggle acceptToggle;

    private bool deleteConfirm = false;
    private bool resetConfirm = false;
    private Coroutine deleteTimeoutCoroutine;
    private Coroutine resetTimeoutCoroutine;

    public void Setup(AutomatonNode automaton)
    {
        this.automaton = automaton;
        panel.SetActive(false);
        labelButton.onClick.AddListener(ToggleShow);
        deleteButton.onClick.AddListener(OnDeleteButtonClicked);
        resetButton.onClick.AddListener(OnResetButtonClicked);
        acceptToggle.onValueChanged.AddListener(OnAcceptToggleChange);
    }

    public void ToggleShow()
    {
        //if (automaton.simulateMode)
        //{
        //    AutomatonError error;
        //    automaton.CheckNextState(stateNode.stateKey, out error);
        //}

        if (panel.activeSelf)
        {
            panel.SetActive(false);
            ResetConfirmStates();
        }
        else
        {
            panel.SetActive(true);
        }
    }

    private void OnDeleteButtonClicked()
    {
        if (!deleteConfirm)
        {
            deleteConfirm = true;
            deleteButton.GetComponentInChildren<TMP_Text>().text = "Confirm";

            if (deleteTimeoutCoroutine != null)
                StopCoroutine(deleteTimeoutCoroutine);

            deleteTimeoutCoroutine = StartCoroutine(ResetDeleteConfirmAfterDelay());
            return;
        }

        DeleteState();
        ResetConfirmStates();
    }

    private void OnResetButtonClicked()
    {
        if (!resetConfirm)
        {
            resetConfirm = true;
            resetButton.GetComponentInChildren<TMP_Text>().text = "Confirm";

            if (resetTimeoutCoroutine != null)
                StopCoroutine(resetTimeoutCoroutine);

            resetTimeoutCoroutine = StartCoroutine(ResetResetConfirmAfterDelay());
            return;
        }

        ClearTransitions();
        ResetConfirmStates();
    }

    private IEnumerator ResetDeleteConfirmAfterDelay()
    {
        yield return new WaitForSeconds(3f);
        deleteConfirm = false;
        deleteButton.GetComponentInChildren<TMP_Text>().text = "Delete";
    }

    private IEnumerator ResetResetConfirmAfterDelay()
    {
        yield return new WaitForSeconds(3f);
        resetConfirm = false;
        resetButton.GetComponentInChildren<TMP_Text>().text = "Reset";
    }

    public void DeleteState()
    {
        AutomatonError error;
        stateNode.automaton.RemoveState(stateNode.stateKey, out error);

        if (error.code != AutomatonErrorCode.OK)
        {
            stateNode.automaton.ShowError(error);
            return;
        }

        Destroy(stateNode.gameObject);
    }

    public void ClearTransitions()
    {
        AutomatonError error;
        stateNode.automaton.ClearStateTransitions(stateNode.stateKey, out error);

        if (error.code != AutomatonErrorCode.OK)
        {
            stateNode.automaton.ShowError(error);
            return;
        }

        foreach (TransitionLine t in stateNode.outgoingTransitions)
        {
            Destroy(t.gameObject);
            stateNode.UnregisterOutgoing(t);
        }
    }

    public void OnAcceptToggleChange(bool value)
    {
        AutomatonError error;
        stateNode.automaton.UpdateStateAccept(stateNode.stateKey, value, out error);

        if (error.code != AutomatonErrorCode.OK) return;
    }

    private void ResetConfirmStates()
    {
        deleteConfirm = false;
        resetConfirm = false;

        if (deleteTimeoutCoroutine != null)
            StopCoroutine(deleteTimeoutCoroutine);

        if (resetTimeoutCoroutine != null)
            StopCoroutine(resetTimeoutCoroutine);

        deleteButton.GetComponentInChildren<TMP_Text>().text = "Delete";
        resetButton.GetComponentInChildren<TMP_Text>().text = "Reset";
    }
}
