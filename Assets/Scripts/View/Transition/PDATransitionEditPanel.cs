using AutomataSimulator;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PDATransitionEditPanel : MonoBehaviour
{
    private TransitionLine transition;
    private AutomatonNode automaton;

    public TMP_Dropdown inputDropdown;
    public TMP_Dropdown stackSymbolDropdown;
    public TMP_Dropdown pushSymbolDropdown;
    [SerializeField] Button deleteButton;

    public void Setup(TransitionLine transitionLine)
    {
        transition = transitionLine;
        automaton = transition.automaton;
        inputDropdown.onValueChanged.AddListener(onInputValueChanged);
        inputDropdown.onValueChanged.AddListener(onStackSymbolChanged);
        inputDropdown.onValueChanged.AddListener(onPushSymbolChanged);
        deleteButton.onClick.AddListener(DeleteTransition);
        automaton.OnInputAlphabetUpdated += LoadInputDropdownOptions;
        automaton.OnStackAlphabetUpdated += LoadStackSymbolDropdownOptions;
        automaton.OnStackAlphabetUpdated += LoadPushSymbolDropdownOptions;
        LoadInputDropdownOptions();
        LoadStackSymbolDropdownOptions();
        LoadPushSymbolDropdownOptions();
    }

    private void onInputValueChanged(int index)
    {
        AutomatonError error;
        string symbol = inputDropdown.options[index].text;
        transition.automaton.UpdateTransitionInput(transition.key, symbol, out error);
    }

    private void onStackSymbolChanged(int index)
    {
        AutomatonError error;
        string symbol = inputDropdown.options[index].text;
        transition.automaton.UpdateTransitionStackSymbol(transition.key, symbol, out error);
    }

    private void onPushSymbolChanged(int index)
    {
        AutomatonError error;
        string symbol = inputDropdown.options[index].text;
        transition.automaton.UpdateTransitionPushSymbol(transition.key, symbol, out error);
    }

    private void LoadInputDropdownOptions()
    {
        AutomatonError error;
        string[] alphabet = transition.automaton.GetInputAlphabet(out error);
        var allOptionsList = new List<string> { };
        allOptionsList.AddRange(alphabet);
        inputDropdown.ClearOptions();
        inputDropdown.AddOptions(allOptionsList);
        inputDropdown.interactable = allOptionsList.Count > 0;
    }

    public void LoadStackSymbolDropdownOptions()
    {
        AutomatonError error;
        string[] alphabet = transition.automaton.GetStackAlphabet(out error);
        var allOptionsList = new List<string> { "_" };
        allOptionsList.AddRange(alphabet);
        stackSymbolDropdown.ClearOptions();
        stackSymbolDropdown.AddOptions(allOptionsList);
        stackSymbolDropdown.interactable = allOptionsList.Count > 0;
    }

    public void LoadPushSymbolDropdownOptions()
    {
        AutomatonError error;
        string[] alphabet = transition.automaton.GetStackAlphabet(out error);
        var allOptionsList = new List<string> { "_" };
        allOptionsList.AddRange(alphabet);
        pushSymbolDropdown.ClearOptions();
        pushSymbolDropdown.AddOptions(allOptionsList);
        pushSymbolDropdown.interactable = allOptionsList.Count > 0;
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
