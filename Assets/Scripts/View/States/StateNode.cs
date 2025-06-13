using AutomataSimulator;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StateNode : MonoBehaviour
{
    public string stateKey;
    public TMP_Text label;
    public Renderer stateRenderer;
    public AutomatonNode automaton;
    [SerializeField] public CurrentStateIndicator currentStateIndicator;
    [SerializeField] public StateEditPanel stateEditPanel;
    [SerializeField] private Image labelButtonImage;
    public List<TransitionLine> outgoingTransitions = new();

    public virtual void Initialize(string key, AutomatonNode automatonRef)
    {
        stateKey = key;
        automaton = automatonRef;
        label.text = key;
        currentStateIndicator.Setup(automaton, key);
        stateEditPanel.Setup(automaton);

        automaton.OnStateUpdated += UpdateStateObject;
        automaton.OnStartStateUpdated += UpdateStartStateIndicator;
        UpdateStateObject();
        UpdateStartStateIndicator();
    }

    public void RegisterOutgoing(TransitionLine line)
    {
        outgoingTransitions.Add(line);
    }

    public void UnregisterOutgoing(TransitionLine line)
    {
        outgoingTransitions.Remove(line);
    }

    public void SetLabel(string newLabel)
    {
        AutomatonError error;
        automaton.UpdateStateLabel(stateKey, newLabel, out error);

        if (error.code != AutomatonErrorCode.OK) return;

        label.text = newLabel;
    }

    private void UpdateStateObject()
    {

        AutomatonError error;
        State state = automaton.GetState(stateKey, out error);


        if (error.code != AutomatonErrorCode.OK) return;

        if (state.IsAccept)
        {
            stateRenderer.material.color = Color.green;
        }
        else
        {
            stateRenderer.material.color = Color.gray;
        }
    }


    private void UpdateStartStateIndicator()
    {

        AutomatonError error;
        string startKey = automaton.GetStartState(out error);
        if (error.code == AutomatonErrorCode.OK)
        {
            if (startKey == stateKey)
            {
                labelButtonImage.color = new Color(0f, 0f, 1f, 0.66f);
            }
            else
            {
                labelButtonImage.color = new Color(0f, 0f, 0f, 0.33f); // Black, 33% opacity
            }
        }
    }

    public void OnDestroy()
    {
        automaton.OnStateUpdated -= UpdateStateObject;

        foreach (var transition in outgoingTransitions)
        {
            Destroy(transition.gameObject);
        }
    }
}
