using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tape : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] tapeLabels = new TextMeshProUGUI[9];
    [SerializeField] private TMP_Dropdown symbolDropdown;
    [SerializeField] private Button writeButton;
    [SerializeField] private Button moveRightButton;
    [SerializeField] private Button moveLeftButton;
    [SerializeField] private Image arrow;

    private List<string> tape = new List<string>();
    private int headPosition = 0;

    private const string BlankSymbol = "_";
    public AutomatonNode automaton;

    public void Setup(AutomatonNode automaton)
    {
        this.automaton = automaton;

        // Set up button and dropdown
        writeButton.onClick.AddListener(WriteAtHead);
        moveRightButton.onClick.AddListener(MoveRight);
        moveLeftButton.onClick.AddListener(MoveLeft);

        automaton.OnTapeAlphabetUpdated += RefreshSymbolDropdown;
        automaton.OnTapeUpdated += UpdateTape;
        automaton.OnTypeChange += UpdateVisibility;
        RefreshSymbolDropdown();
        UpdateTape();
        UpdateHeadArrow();
        UpdateVisibility();
    }

    public void UpdateTape()
    {
        AutomatonError error;
        headPosition = automaton.GetTapeHead(out error);
        tape = new List<string>(automaton.GetTape(out error));
        UpdateDisplay();
        UpdateHeadArrow();
    }

    private void UpdateDisplay()
    {
        int startDisplayAt = Math.Max(headPosition - 4, 0);

        for (int i = 0; i < tapeLabels.Length; i++)
        {
            int tapeIndex = startDisplayAt + i;

            string symbol = "";

            try
            {
                symbol = tape[tapeIndex];
            }
            catch
            {
                symbol = BlankSymbol;
            }

            tapeLabels[i].text = symbol;
        }
    }

    private void UpdateHeadArrow()
    {
        int arrowIndex = Math.Min(headPosition, 8);
        // Match the X position of the label at the head index
        Vector3 labelPosition = tapeLabels[arrowIndex].transform.position;
        Vector3 arrowPosition = arrow.transform.position;
        arrow.transform.position = new Vector3(labelPosition.x, arrowPosition.y, arrowPosition.z);
    }

    private void WriteAtHead()
    {
        string symbolToWrite = symbolDropdown.options[symbolDropdown.value].text;
        AutomatonError error;

        automaton.WriteTape(symbolToWrite, out error);
    }

    private void MoveLeft()
    {
        AutomatonError error;

        automaton.MoveTape("LEFT", out error);
    }

    private void MoveRight()
    {
        AutomatonError error;

        automaton.MoveTape("RIGHT", out error);
    }

    private void RefreshSymbolDropdown()
    {
        AutomatonError error;
        string[] stackAlphabet = automaton.GetTapeAlphabet(out error);

        if (error.code != AutomatonErrorCode.OK)
        {
            Debug.LogWarning("Failed to retrieve stack alphabet.");
            return;
        }

        List<string> dropdownOptions = new List<string> { };
        dropdownOptions.AddRange(stackAlphabet);

        symbolDropdown.ClearOptions();
        symbolDropdown.AddOptions(dropdownOptions);
        symbolDropdown.interactable = dropdownOptions.Count > 0;
    }

    private void UpdateVisibility()
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
