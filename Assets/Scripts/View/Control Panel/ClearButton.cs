using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClearButton : MonoBehaviour
{
    public Button button;
    public TMP_Text buttonText;
    public string confirmMessage = "Click again to confirm";
    public string originalText = "Clear Canvas";
    public float confirmTimeout = 3f;

    private AutomatonNode automaton;

    private bool waitingForConfirm = false;
    private Coroutine resetCoroutine;

    public void Setup(AutomatonNode automaton)
    {
        this.automaton = automaton;
        automaton.OnSimulateModeChange += OnSimulateModeChange;

        if (button == null) button = GetComponent<Button>();
        button.onClick.AddListener(HandleClick);
        if (buttonText == null) buttonText = button.GetComponentInChildren<TMP_Text>();
    }
    void OnSimulateModeChange()
    {
        button.interactable = automaton.simulateMode;
    }

    void HandleClick()
    {
        if (!waitingForConfirm)
        {
            waitingForConfirm = true;
            buttonText.text = confirmMessage;

            resetCoroutine = StartCoroutine(ResetAfterDelay());
        }
        else
        {
            if (resetCoroutine != null)
            {
                StopCoroutine(resetCoroutine);
            }

            AutomatonError error;
            waitingForConfirm = false;
            buttonText.text = originalText;

            automaton.ClearAutomata(out error);
        }
    }

    IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(confirmTimeout);
        waitingForConfirm = false;
        buttonText.text = originalText;
    }
}
