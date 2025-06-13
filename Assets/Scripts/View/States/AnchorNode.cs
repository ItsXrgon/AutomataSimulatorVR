using AutomataSimulator;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR.Interaction.Toolkit;

public class AnchorNode : MonoBehaviour
{
    [Header("Connections")]
    public List<AnchorNode> connectedAnchors = new List<AnchorNode>();

    public StateNode stateNode;

    [Header("Visuals")]
    public Renderer anchorRenderer;
    private Color originalColor = Color.white;
    private Color highlightColor = Color.yellow;
    public GameObject transitionLinePrefab;

    private List<TransitionLine> transitions = new List<TransitionLine>();

    private void Awake()
    {
        if (anchorRenderer == null)
        {
            anchorRenderer = GetComponent<Renderer>();
        }

        anchorRenderer.material.color = originalColor;
    }

    public void ConnectTo(AnchorNode otherAnchor)
    {
        if (otherAnchor == null || otherAnchor == this) return;

        // Check if already connected
        if (connectedAnchors.Contains(otherAnchor)) return;

        AutomatonError error;
        string key = RegisterTransition(otherAnchor.stateNode, stateNode, out error);


        if (error.code != AutomatonErrorCode.OK)
        {
            stateNode.automaton.ShowError(error);
            return;
        }

        GameObject newLine = Instantiate(transitionLinePrefab);
        TransitionLine line = newLine.GetComponent<TransitionLine>();

        line.Initialize(otherAnchor, this, stateNode.automaton, key);

        transitions.Add(line);
    }

    private string RegisterTransition(StateNode startState, StateNode endState, out AutomatonError error)
    {
        string key = "";
        string[] parameters = new string[5];
        parameters[0] = startState.stateKey;
        parameters[1] = endState.stateKey;
        parameters[2] = stateNode.automaton.GetInputAlphabet(out error)[0];

        if (error.code != AutomatonErrorCode.OK) return key;

        switch (stateNode.automaton.automataType)
        {
            case AutomataType.DFA:
            case AutomataType.NFA:
                stateNode.automaton.AddTransition(parameters, out error);
                if (error.code != AutomatonErrorCode.OK) return key;

                key = FATransition.GenerateTransitionKey(startState.stateKey, endState.stateKey, parameters[2]);
                break;
            case AutomataType.DPDA:
            case AutomataType.NPDA:
                parameters[3] = "";
                if (error.code != AutomatonErrorCode.OK) return key;

                parameters[4] = "";
                if (error.code != AutomatonErrorCode.OK) return key;

                stateNode.automaton.AddTransition(parameters, out error);
                if (error.code != AutomatonErrorCode.OK) return key;

                key = PDATransition.GenerateTransitionKey(startState.stateKey, endState.stateKey, parameters[2], parameters[3], parameters[4]);
                break;
            case AutomataType.DTM:
            case AutomataType.NTM:
                parameters[2] = "";
                if (error.code != AutomatonErrorCode.OK) return key;

                parameters[3] = "";
                if (error.code != AutomatonErrorCode.OK) return key;

                parameters[4] = "STAY";
                stateNode.automaton.AddTransition(parameters, out error);
                if (error.code != AutomatonErrorCode.OK) return key;

                key = TMTransition.GenerateTransitionKey(startState.stateKey, endState.stateKey, parameters[2], parameters[3], parameters[4]);
                break;
            default:
                break;
        }
        return key;
    }

    public void DisconnectFrom(AnchorNode otherAnchor)
    {
        if (otherAnchor == null) return;

        connectedAnchors.Remove(otherAnchor);
        otherAnchor.connectedAnchors.Remove(this);
    }

    public void DisconnectAll()
    {
        // Create a copy to avoid modification during iteration
        var anchorsToDisconnect = new List<AnchorNode>(connectedAnchors);

        foreach (var anchor in anchorsToDisconnect)
        {
            DisconnectFrom(anchor);
        }
    }

    public void OnHoverEnter(HoverEnterEventArgs args)
    {
        anchorRenderer.material.color = highlightColor;
    }

    public void OnHoverExit(HoverExitEventArgs args)
    {
        anchorRenderer.material.color = originalColor;
    }

    public void OnSelectEnter(SelectEnterEventArgs args)
    {
        anchorRenderer.material.color = highlightColor;
    }

    public void OnSelectExit(SelectExitEventArgs args)
    {
        anchorRenderer.material.color = originalColor;
    }
}