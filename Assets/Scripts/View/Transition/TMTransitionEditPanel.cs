using AutomataSimulator;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TMTransitionEditPanel : MonoBehaviour
{
    private TransitionLine transition;
    private AutomatonNode automaton;

    public TMP_Dropdown readSymbolDropdown;
    public TMP_Dropdown writeSymbolDropdown;
    public TMP_Dropdown directionDropdown;
    [SerializeField] Button deleteButton;

    public void Setup(TransitionLine transitionLine)
    {
        transition = transitionLine;
        automaton = transition.automaton;
        readSymbolDropdown.onValueChanged.AddListener(onInputValueChanged);
        writeSymbolDropdown.onValueChanged.AddListener(onWriteSymbolChanged);
        directionDropdown.onValueChanged.AddListener(onDirectionChanged);
        deleteButton.onClick.AddListener(DeleteTransition);
        automaton.OnTapeAlphabetUpdated += LoadReadSymbolDropdownOptions;
        automaton.OnTapeAlphabetUpdated += LoadWriteSymbolDropdownOptions;
        LoadReadSymbolDropdownOptions();
        LoadWriteSymbolDropdownOptions();
        LoadDirectionDropdown();
    }

    private void onInputValueChanged(int index)
    {
        AutomatonError error;
        string symbol = readSymbolDropdown.options[index].text;
        transition.automaton.UpdateTransitionInput(transition.key, symbol, out error);
    }
    private void onWriteSymbolChanged(int index)
    {
        AutomatonError error;
        string symbol = writeSymbolDropdown.options[index].text;
        transition.automaton.UpdateTransitionWriteSymbol(transition.key, symbol, out error);
    }

    private void onDirectionChanged(int index)
    {
        AutomatonError error;
        string symbol = directionDropdown.options[index].text;
        transition.automaton.UpdateTransitionDirection(transition.key, symbol, out error);
    }

    private void LoadReadSymbolDropdownOptions()
    {
        AutomatonError error;
        string[] alphabet = transition.automaton.GetInputAlphabet(out error);
        var allOptionsList = new List<string> { };
        allOptionsList.AddRange(alphabet);
        readSymbolDropdown.ClearOptions();
        readSymbolDropdown.AddOptions(allOptionsList);
        readSymbolDropdown.interactable = allOptionsList.Count > 0;
    }

    public void LoadWriteSymbolDropdownOptions()
    {
        AutomatonError error;
        string[] alphabet = transition.automaton.GetTapeAlphabet(out error);
        var allOptionsList = new List<string> { "_" };
        allOptionsList.AddRange(alphabet);
        writeSymbolDropdown.ClearOptions();
        writeSymbolDropdown.AddOptions(allOptionsList);
        writeSymbolDropdown.interactable = allOptionsList.Count > 0;
    }

    public void LoadPushSymbolDropdownOptions()
    {
        AutomatonError error;
        string[] alphabet = transition.automaton.GetTapeAlphabet(out error);
        var allOptionsList = new List<string> { "_" };
        allOptionsList.AddRange(alphabet);
        directionDropdown.ClearOptions();
        directionDropdown.AddOptions(allOptionsList);
        directionDropdown.interactable = allOptionsList.Count > 0;
    }
    public void LoadDirectionDropdown()
    {
        var allOptionsList = new List<string> { "R", "L", "S" };
        directionDropdown.ClearOptions();
        directionDropdown.AddOptions(allOptionsList);
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
