using AutomataSimulator;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StackControlPanel : MonoBehaviour
{
    [SerializeField] private Button pushButton;
    [SerializeField] private Button popButton;
    [SerializeField] private TMP_Dropdown pushSymbolDropdown;
    [SerializeField] private Stack stack;

    public AutomatonNode automaton;

    public void Setup(AutomatonNode automaton)
    {
        this.automaton = automaton;
        pushButton.onClick.AddListener(OnPushButton);
        popButton.onClick.AddListener(OnPopButton);
        
        automaton.OnStackAlphabetUpdated += RefreshDropdowns;
        RefreshDropdowns();
    }

    private void OnPushButton()
    {
        int index = pushSymbolDropdown.value;

        string symbol = pushSymbolDropdown.options[index].text;
        stack.Push(symbol);
    }

    private void OnPopButton()
    {
        stack.Pop();
    }


    private void RefreshDropdowns()
    {
        AutomatonError error;
        string[] stackAlphabet = automaton.GetStackAlphabet(out error);

        if (error.code != AutomatonErrorCode.OK)
        {
            Debug.LogWarning("Failed to retrieve stack alphabet.");
            return;
        }

        List<string> dropdownOptions = new List<string> {};
        dropdownOptions.AddRange(stackAlphabet);

        pushSymbolDropdown.ClearOptions();
        pushSymbolDropdown.AddOptions(dropdownOptions);
        pushSymbolDropdown.interactable = dropdownOptions.Count > 0;
    }

}
