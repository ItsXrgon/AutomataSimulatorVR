using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class StackAlphabetDropdowns : MonoBehaviour
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
        "$", "#", "@", "&", "*", "ε"
    };

    private HashSet<string> selectedCharacters = new HashSet<string>();

    public void Setup(AutomatonNode automaton)
    {
        this.automaton = automaton;
        RefreshDropdowns();

        allOptionsDropdown.onValueChanged.AddListener(OnAddSymbol);
        selectedOptionsDropdown.onValueChanged.AddListener(OnRemoveSymbol);

        UpdateVisibility();
        automaton.OnTypeChange += UpdateVisibility;
    }

    void OnAddSymbol(int index)
    {
        if (index <= 0) return; // 0 is the label

        AutomatonError error;

        string symbol = allOptionsDropdown.options[index].text;
        automaton.AddStackAlphabetSymbol(symbol, out error);

        if (error.code != AutomatonErrorCode.OK) return;

        selectedCharacters.Add(symbol);
        RefreshDropdowns();
        allOptionsDropdown.value = 0;
    }

    void OnRemoveSymbol(int index)
    {
        if (index <= 0) return; // 0 is the label

        AutomatonError error;

        string symbol = selectedOptionsDropdown.options[index].text;

        automaton.RemoveStackAlphabetSymbol(symbol, out error);

        if (error.code != AutomatonErrorCode.OK) return;

        selectedCharacters.Remove(symbol);
        RefreshDropdowns();
        selectedOptionsDropdown.value = 0;
    }

    void RefreshDropdowns()
    {
        List<string> availableOptions = allCharacters.FindAll(c => !selectedCharacters.Contains(c));

        // Add label + available
        var allOptionsList = new List<string> { "Add" };
        allOptionsList.AddRange(availableOptions);
        allOptionsDropdown.ClearOptions();
        allOptionsDropdown.AddOptions(allOptionsList);
        allOptionsDropdown.interactable = availableOptions.Count > 0;

        // Add label + selected
        var selectedOptionsList = new List<string> { "Remove" };
        selectedOptionsList.AddRange(selectedCharacters);
        selectedOptionsDropdown.ClearOptions();
        selectedOptionsDropdown.AddOptions(selectedOptionsList);
        selectedOptionsDropdown.interactable = selectedCharacters.Count > 0;
    }

    void UpdateVisibility()
    {
        if (automaton.automataType == AutomataType.DPDA || automaton.automataType == AutomataType.NPDA)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
