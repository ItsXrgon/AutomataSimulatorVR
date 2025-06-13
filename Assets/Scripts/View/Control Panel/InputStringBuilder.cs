using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputStringBuilder : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown symbolDropdown;
    [SerializeField] private TextMeshProUGUI inputTextDisplay;
    [SerializeField] private Button clearButton;
    [SerializeField] private Button backspaceButton;

    private AutomatonNode automaton;
    private List<string> inputSymbols = new();
    private readonly List<string> currentInputString = new();

    public void Setup(AutomatonNode automaton)
    {
        this.automaton = automaton;

        symbolDropdown.onValueChanged.AddListener(OnSymbolSelected);
        clearButton.onClick.AddListener(ClearInput);
        backspaceButton.onClick.AddListener(RemoveLastSymbol);

        RefreshDropdown();
        automaton.OnInputAlphabetUpdated += RefreshDropdown;
        automaton.OnInputHeadUpdated += UpdateInputDisplay;
    }

    void OnSymbolSelected(int index)
    {
        if (index <= 0) return;

        string symbol = symbolDropdown.options[index].text;
        var tempInput = new List<string>(currentInputString) { symbol };

        AutomatonError error;
        automaton.SetInput(tempInput.ToArray(), out error);

        if (error.code == AutomatonErrorCode.OK)
        {
            currentInputString.Add(symbol);
            UpdateInputDisplay();
        }

        symbolDropdown.value = 0;
    }

    void ClearInput()
    {
        AutomatonError error;
        automaton.SetInput(Array.Empty<string>(), out error);

        if (error.code == AutomatonErrorCode.OK)
        {
            currentInputString.Clear();
            UpdateInputDisplay();
        }
    }

    void RemoveLastSymbol()
    {
        if (currentInputString.Count == 0) return;

        var tempInput = new List<string>(currentInputString);
        tempInput.RemoveAt(tempInput.Count - 1);

        AutomatonError error;
        automaton.SetInput(tempInput.ToArray(), out error);

        if (error.code == AutomatonErrorCode.OK)
        {
            currentInputString.RemoveAt(currentInputString.Count - 1);
            UpdateInputDisplay();
        }
    }

    void RefreshDropdown()
    {
        AutomatonError error;
        inputSymbols = new List<string>(automaton.GetInputAlphabet(out error));

        if (error.code != AutomatonErrorCode.OK)
            return;

        var dropdownOptions = new List<string> { "Select Symbol" };
        dropdownOptions.AddRange(inputSymbols);

        symbolDropdown.ClearOptions();
        symbolDropdown.AddOptions(dropdownOptions);
        symbolDropdown.value = 0;

        currentInputString.RemoveAll(symbol => !inputSymbols.Contains(symbol));
    }

    void UpdateInputDisplay()
    {
        AutomatonError error;
        int headPosition = automaton.GetInputHead(out error);
        Debug.Log(automaton.GetCurrentState(out error));

        if (error.code != AutomatonErrorCode.OK)
        {
            inputTextDisplay.text = "[Error fetching input head]";
            return;
        }

        var sb = new System.Text.StringBuilder();
        for (int i = 0; i < currentInputString.Count; i++)
        {
            if (i == headPosition)
                sb.Append($"<mark=#ffff00aa><b>{currentInputString[i]}</b></mark>");
            else
                sb.Append(currentInputString[i]);
        }

        inputTextDisplay.text = sb.ToString();
    }

    public string[] GetCurrentInputString()
    {
        return currentInputString.ToArray();
    }
}
