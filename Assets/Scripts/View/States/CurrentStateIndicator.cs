using AutomataSimulator;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrentStateIndicator : MonoBehaviour
{
    private string stateKey;
    public AutomatonNode automaton;

    public void Setup(AutomatonNode automaton, string stateKey)
    {
        this.automaton = automaton;
        this.stateKey = stateKey;
        automaton.OnCurrentStateUpdated += UpdateCurrentStateIndicator;
    }

    private void UpdateCurrentStateIndicator()
    {
        if (this == null || gameObject == null) return;
        AutomatonError error;
        bool isCurrent = automaton.GetCurrentState(out error) == stateKey;
        if (this != null && gameObject != null)
        {
            gameObject.SetActive(isCurrent);
        }
    }

    public void OnDestroy()
    {
        if (automaton != null)
        {
            automaton.OnCurrentStateUpdated -= UpdateCurrentStateIndicator;
        }
    }
}
