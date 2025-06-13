using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartStateDropdown : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown startStateDropdown;
    private AutomatonNode automaton;

    public void Setup(AutomatonNode automaton)
    {
        this.automaton = automaton;

        startStateDropdown.onValueChanged.AddListener(OnDropdownChanged);

        automaton.OnStateAdded += LoadOptions;
        automaton.OnStateRemoved += LoadOptions;

        LoadOptions();
    }

    void OnDropdownChanged(int index)
    {
        if (index < 0 || index >= startStateDropdown.options.Count)
            return;

        AutomatonError error;
        string key = startStateDropdown.options[index].text;
        automaton.SetStartState(key, out error);
    }

    public void LoadOptions()
    {
        if (automaton == null || automaton.automaton == null)
            return;

        AutomatonError error;
        List<string> stateKeys = automaton.automaton.GetStatesKeys(out error);
        if (error.code != AutomatonErrorCode.OK)
        {
            return;
        }

        // Get current selected start state (if any)
        string currentStart = automaton.automaton.GetStartState(out error);
        if (error.code != AutomatonErrorCode.OK)
            currentStart = null;

        // Clear and repopulate
        startStateDropdown.ClearOptions();
        startStateDropdown.AddOptions(stateKeys);

        // Restore selection if it still exists
        int newIndex = stateKeys.IndexOf(currentStart);
        if (newIndex >= 0)
        {
            startStateDropdown.SetValueWithoutNotify(newIndex);
        }
        else if (stateKeys.Count > 0)
        {
            startStateDropdown.SetValueWithoutNotify(0);
            OnDropdownChanged(0);
        }
    }
}
