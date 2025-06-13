using TMPro;
using UnityEngine;

public class ChangeTypeDropdown : MonoBehaviour
{
    public TMP_Dropdown typeDropdown;
    private AutomatonNode automaton;

    public void Setup(AutomatonNode automaton)
    {
        this.automaton = automaton;

        LoadOptions();
        typeDropdown.value = AutomataTypeToOption(automaton.automataType);
        typeDropdown.RefreshShownValue();

        typeDropdown.onValueChanged.AddListener(OnDropdownChanged);
        automaton.OnSimulateModeChange += OnSimulateModeChange;

    }

    void OnSimulateModeChange()
    {
        typeDropdown.interactable = automaton.simulateMode;
    }

    public void LoadOptions()
    {
        string[] dropdownOptions =
        {
            "Deterministic Finite Automata",
            "Nondeterministic Finite Automata",
            "Deterministic Pushdown Automata",
            "Nondeterministic Pushdown Automata",
            "Deterministic Turing Machine",
            "Nondeterministic Turing Machine"
        };

        for (int i = 0; i < dropdownOptions.Length; i++)
        {
            typeDropdown.options.Add(new TMP_Dropdown.OptionData(dropdownOptions[i]));
        }

    }

    public AutomataType DropdownOptionToAutomataType(int index)
    {
        switch (index)
        {
            case 0:
                return AutomataType.DFA;
            case 1:
                return AutomataType.NFA;
            case 2:
                return AutomataType.DPDA;
            case 3:
                return AutomataType.NPDA;
            case 4:
                return AutomataType.DTM;
            case 5:
                return AutomataType.NTM;
            default:
                return AutomataType.DFA;
        }
    }

    public int AutomataTypeToOption(AutomataType automataType)
    {
        switch (automataType)
        {
            case AutomataType.DFA:
                return 0;
            case AutomataType.NFA:
                return 1;
            case AutomataType.DPDA:
                return 2;
            case AutomataType.NPDA:
                return 3;
            case AutomataType.DTM:
                return 4;
            case AutomataType.NTM:
                return 5;
            default:
                return 0;
        }
    }

    void OnDropdownChanged(int index)
    {
        AutomatonError error;
        automaton.ChangeType(DropdownOptionToAutomataType(index), out error);
    }
}
