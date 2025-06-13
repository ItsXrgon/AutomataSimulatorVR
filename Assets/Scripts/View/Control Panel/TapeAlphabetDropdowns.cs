using AutomataSimulator;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TapeAlphabetDropdowns : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown allOptionsDropdown;
    [SerializeField] private TMP_Dropdown selectedOptionsDropdown;
    private AutomatonNode automaton;

    private List<string> allCharacters = new List<string>
    {
        "a","b","c","d","e","f","g","h","i","j",
        "k","l","m","n","o","p","q","r","s","t",
        "u","v","w","x","y","z",
        "0","1","2","3","4","5","6","7","8","9",
        "_", "#", "$", "ε", "X", "Y", "Z"
    };

    // Holds only additional (non-input) tape alphabet characters
    private HashSet<string> additionalTapeCharacters = new();

    public void Setup(AutomatonNode automaton)
    {
        this.automaton = automaton;
        RefreshDropdowns();

        allOptionsDropdown.onValueChanged.AddListener(OnAddSymbol);
        selectedOptionsDropdown.onValueChanged.AddListener(OnRemoveSymbol);

        UpdateVisibility();
        automaton.OnTypeChange += UpdateVisibility;
        automaton.OnInputAlphabetUpdated += RefreshDropdowns;
    }

    void OnAddSymbol(int index)
    {
        if (index <= 0) return;
        string symbol = allOptionsDropdown.options[index].text;
        allOptionsDropdown.value = 0;

        if (additionalTapeCharacters.Contains(symbol)) return;

        AutomatonError error;
        additionalTapeCharacters.Add(symbol);
        automaton?.AddTapeAlphabetSymbol(symbol, out error);

        RefreshDropdowns();
    }

    void OnRemoveSymbol(int index)
    {
        if (index <= 0) return;
        string symbol = selectedOptionsDropdown.options[index].text;
        selectedOptionsDropdown.value = 0;

        AutomatonError error;
        HashSet<string> inputAlphabet = new HashSet<string>(automaton.GetInputAlphabet(out error));

        if (inputAlphabet.Contains(symbol))
        {
            Debug.LogWarning($"Cannot remove '{symbol}' because it's part of the input alphabet.");
            return;
        }

        if (additionalTapeCharacters.Remove(symbol))
        {
            automaton?.RemoveTapeAlphabetSymbol(symbol, out error);
        }

        RefreshDropdowns();
    }

    void RefreshDropdowns()
    {
        if (automaton == null) return;

        AutomatonError error;

        HashSet<string> inputAlphabet = new HashSet<string>(automaton.GetInputAlphabet(out error));
        HashSet<string> currentTapeAlphabet = new(inputAlphabet);
        currentTapeAlphabet.UnionWith(additionalTapeCharacters);

        // All options: anything not already in the tape alphabet
        List<string> availableOptions = allCharacters.FindAll(c => !currentTapeAlphabet.Contains(c));
        var allOptionsList = new List<string> { "Add" };
        allOptionsList.AddRange(availableOptions);
        allOptionsDropdown.ClearOptions();
        allOptionsDropdown.AddOptions(allOptionsList);
        allOptionsDropdown.interactable = availableOptions.Count > 0;

        // Selected: only show additional (non-input) symbols for removal
        var selectedOptionsList = new List<string> { "Remove" };
        selectedOptionsList.AddRange(additionalTapeCharacters);
        selectedOptionsDropdown.ClearOptions();
        selectedOptionsDropdown.AddOptions(selectedOptionsList);
        selectedOptionsDropdown.interactable = additionalTapeCharacters.Count > 0;
    }

    void UpdateVisibility()
    {
        if (automaton.automataType == AutomataType.DTM || automaton.automataType == AutomataType.NTM)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
