using AutomataSimulator;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FATransitionEditPanel : MonoBehaviour
{
    private TransitionLine transition;
    private AutomatonNode automaton;
    [SerializeField] Button deleteButton;

    public TMP_Dropdown alphabetDrodown;

    public void Setup(TransitionLine transitionLine)
    {
        transition = transitionLine;
        automaton = transition.automaton;
        alphabetDrodown.onValueChanged.AddListener(onValueChanged);
        deleteButton.onClick.AddListener(DeleteTransition);
        automaton.OnInputAlphabetUpdated += LoadInputDropdownOptions;
        LoadInputDropdownOptions();
    }

    private void onValueChanged(int index)
    {
        AutomatonError error;
        string symbol = alphabetDrodown.options[index].text;
        transition.automaton.UpdateTransitionInput(transition.key, symbol, out error);


        if (error.code != AutomatonErrorCode.OK)
        {
            automaton.ShowError(error);
            return;
        }
    }

    private void LoadInputDropdownOptions()
    {
        AutomatonError error;
        string[] alphabet = transition.automaton.GetInputAlphabet(out error);
        var allOptionsList = new List<string> {};
        allOptionsList.AddRange(alphabet);
        alphabetDrodown.ClearOptions();
        alphabetDrodown.AddOptions(allOptionsList);
        alphabetDrodown.interactable = allOptionsList.Count > 0;
    }

    private void DeleteTransition()
    {
        AutomatonError error;
       
        automaton.RemoveTransition(transition.key, out error);

        if (error.code != AutomatonErrorCode.OK)
        {
            return;
        }

        Destroy(transition.gameObject);
    }
}
