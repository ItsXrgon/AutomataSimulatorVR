using AutomataSimulator;
using System;
using UnityEngine;

public enum AutomataType
{
    DFA,
    NFA,
    DPDA,
    NPDA,
    DTM,
    NTM
}

public class AutomatonNode : MonoBehaviour
{
    public Automaton automaton;
    [SerializeField] private int id;
    [SerializeField] public AutomataType automataType;
    [SerializeField] private GameObject statePrefab;
    [SerializeField] private Transform cylinderBoundary;
    [SerializeField] public ErrorDisplay errorDisplay;
    [SerializeField] public ControlPanel controlPanel;
    [SerializeField] public Stack stack;
    [SerializeField] public Tape tape;
    [SerializeField] public bool simulateMode;

    // Listeners
    public event Action OnAutomatonReset;
    public event Action OnStateAdded;
    public event Action OnStateRemoved;
    public event Action OnStateUpdated;
    public event Action OnTransitionAdded;
    public event Action OnTransitionRemoved;
    public event Action OnTransitionUpdated;
    public event Action OnInputAdded;
    public event Action OnInputRemoved;
    public event Action OnInputUpdated;
    public event Action OnInputHeadUpdated;
    public event Action OnInputProcessed;
    public event Action OnInputSimulated;
    public event Action OnInputAlphabetUpdated;
    public event Action OnStackAlphabetUpdated;
    public event Action OnTapeAlphabetUpdated;
    public event Action OnAutomatonCleared;
    public event Action OnTypeChange;
    public event Action OnStackUpdated;
    public event Action OnTapeUpdated;
    public event Action OnCurrentStateUpdated;
    public event Action OnStartStateUpdated;
    public event Action OnSimulateModeChange;

    public void Start()
    {
        AutomatonError error;
        ChangeType(automataType, out error);
        controlPanel.Setup(this);
        stack.Setup(this);
        tape.Setup(this);
        simulateMode = false;
    }

    public void ChangeType(AutomataType newType, out AutomatonError error)
    {
        automataType = newType;
        CreateAutomaton(newType, out error);
        OnTypeChange?.Invoke();
    }

    public void SetSimulateMode(bool value)
    {
        simulateMode = value;
    }

    private void CreateAutomaton(AutomataType automataType, out AutomatonError error)
    {
        switch (automataType)
        {
            case AutomataType.DFA:
                automaton = new DFA(out error);
                break;
            case AutomataType.NFA:
                automaton = new NFA(out error);
                break;
            case AutomataType.DPDA:
                automaton = new DPDA(out error);
                break;
            case AutomataType.NPDA:
                automaton = new NPDA(out error);
                break;
            case AutomataType.DTM:
                automaton = new DTM(out error);
                break;
            case AutomataType.NTM:
                automaton = new NTM(out error);
                break;
        }
        string[] defaultAlphabet = { "a" };
        automaton.AddInputAlphabet(defaultAlphabet, out error);

        // Get All StateNodes and remove them
        StateNode[] stateNodes = GetComponentsInChildren<StateNode>();
        foreach (StateNode stateNode in stateNodes)
        {
            Destroy(stateNode.gameObject);
        }
        AddState(out error);
        AddState(out error);
    }

    public int GetInputHead(out AutomatonError error)
    {
        if (automaton.type == "DTM" || automaton.type == "NTM")
        {
            error = default;
            return -1;
        }
        int head = automaton.GetInputHead(out error);
        if (error.code != AutomatonErrorCode.OK)

        {
            ShowError(error);
            return -1;
        }
        return head;
    }

    public void SetInputHead(int head, out AutomatonError error)
    {
        automaton.SetInputHead(head, out error);

        OnInputHeadUpdated?.Invoke();
    }

    public void AddInput(string[] input, out AutomatonError error)
    {
        automaton.AddInput(input, out error);

        OnInputAdded?.Invoke();
    }

    public void SetInput(string[] input, out AutomatonError error)
    {
        automaton.SetInput(input, out error);

        OnInputUpdated?.Invoke();
    }

    public State GetState(string key, out AutomatonError error)
    {
        State state = automaton.GetState(key, out error);

        if (error.code != AutomatonErrorCode.OK)
        {
            ShowError(error);
        }

        return state;
    }
    public void SetStartState(string key, out AutomatonError error)
    {
        automaton.SetStartState(key, out error);

        if (error.code != AutomatonErrorCode.OK)
        {
            ShowError(error);
        }

        OnStartStateUpdated?.Invoke();
    }

    public string GetStartState(out AutomatonError error)
    {
        string state = automaton.GetStartState(out error);

        if (error.code != AutomatonErrorCode.OK)
        {
            ShowError(error);
            return null;
        }

        return state;
    }

    public void AddState(out AutomatonError error)
    {
        int currentStateCount = automaton.GetStatesCount(out error);
        string key = "State " + (currentStateCount + 1);
        automaton.AddState(key, out error);

        if (error.code != AutomatonErrorCode.OK) return;

        Vector3 centerAboveCylinder = cylinderBoundary.position;
        centerAboveCylinder.y = 2.5f;
        GameObject newState = Instantiate(statePrefab, centerAboveCylinder, Quaternion.identity);
        // Don't parent yet
        newState.transform.localScale = Vector3.one * 0.5f; // Fix scale
        newState.transform.SetParent(cylinderBoundary, worldPositionStays: true);
        StateNode node = newState.GetComponent<StateNode>();

        if (node != null)
        {
            node.Initialize(key, this);
        }


        OnCurrentStateUpdated?.Invoke();
        OnStartStateUpdated?.Invoke();
        OnStateAdded?.Invoke();
    }

    public void RemoveState(string stateKey, out AutomatonError error)
    {
        automaton.RemoveState(stateKey, out error);

        if (error.code != AutomatonErrorCode.OK) return;

        OnStateRemoved?.Invoke();
    }

    public void UpdateStateLabel(string stateKey, string newLabel, out AutomatonError error)
    {
        automaton.UpdateStateLabel(stateKey, newLabel, out error);
        OnStateUpdated?.Invoke();
    }

    public string GetCurrentState(out AutomatonError error)
    {
        return automaton.GetCurrentState(out error);
    }

    public void ClearStateTransitions(string stateKey, out AutomatonError error)
    {
        automaton.ClearStateTransitions(stateKey, out error);
    }

    public string[] GetInputAlphabet(out AutomatonError error)
    {
        return automaton.GetInputAlphabet(out error);
    }

    public void AddInputAlphabetSymbol(string symbol, out AutomatonError error)
    {
        string[] strings = { symbol };
        automaton.AddInputAlphabet(strings, out error);

        if (error.code != AutomatonErrorCode.OK)
        {
            ShowError(error);
            return;
        }

        OnInputAlphabetUpdated?.Invoke();
    }

    public void RemoveInputAlphabetSymbol(string symbol, out AutomatonError error)
    {
        automaton.RemoveInputAlphabetSymbol(symbol, out error);

        if (error.code != AutomatonErrorCode.OK)
        {
            ShowError(error);
            return;
        }

        OnInputAlphabetUpdated?.Invoke();
    }

    public void UpdateTransitionInput(string key, string symbol, out AutomatonError error)
    {
        automaton.UpdateTransitionInput(key, symbol, out error);

        if (error.code != AutomatonErrorCode.OK)
        {
            ShowError(error);
            return;
        }
    }

    public void UpdateTransitionStackSymbol(string key, string symbol, out AutomatonError error)
    {
        if (automataType != AutomataType.DPDA && automataType != AutomataType.NPDA)
        {
            error = default;
            return;
        }
        
        ((PDA) automaton).UpdateTransitionStackSymbol(key, symbol, out error);

        if (error.code != AutomatonErrorCode.OK)
        {
            ShowError(error);
            return;
        }
    }

    public void UpdateTransitionPushSymbol(string key, string symbol, out AutomatonError error)
    {
        if (automataType != AutomataType.DPDA && automataType != AutomataType.NPDA)
        {
            error = default;
            return;
        }

        ((PDA)automaton).UpdateTransitionPushSymbol(key, symbol, out error);

        if (error.code != AutomatonErrorCode.OK)
        {
            ShowError(error);
            return;
        }
    }

    public void UpdateTransitionWriteSymbol(string key, string symbol, out AutomatonError error)
    {
        if (automataType != AutomataType.DTM && automataType != AutomataType.NTM)
        {
            error = default;
            return;
        }

        ((TM)automaton).UpdateTransitionWriteSymbol(key, symbol, out error);

        if (error.code != AutomatonErrorCode.OK)
        {
            ShowError(error);
            return;
        }
    }
    public void UpdateTransitionDirection(string key, string symbol, out AutomatonError error)
    {
        if (automataType != AutomataType.DTM && automataType != AutomataType.NTM)
        {
            error = default;
            return;
        }

        ((TM)automaton).UpdateTransitionDirection(key, symbol, out error);

        if (error.code != AutomatonErrorCode.OK)
        {
            ShowError(error);
            return;
        }
    }

    public string[] GetStack(out AutomatonError error)
    {
        if (automataType != AutomataType.DPDA && automataType != AutomataType.NPDA)
        {
            error = default;
            return new string[0];
        }

        string[] stack = ((PDA)automaton).GetStack(out error);

        if (error.code != AutomatonErrorCode.OK)
        {
            ShowError(error);
            return new string[0];
        }

        return stack;
    }

    public void PushStack(string symbol, out AutomatonError error)
    {
        if (automataType != AutomataType.DPDA && automataType != AutomataType.NPDA)
        {
            error = default;
            return;
        }

        ((PDA)automaton).PushStack(symbol, out error);

        if (error.code != AutomatonErrorCode.OK)
        {
            ShowError(error);
        }
    }


    public void PopStack(out AutomatonError error)
    {
        if (automataType != AutomataType.DPDA && automataType != AutomataType.NPDA)
        {
            error = default;
            return;
        }

        ((PDA)automaton).PopStack(out error);

        if (error.code != AutomatonErrorCode.OK)
        {
            ShowError(error);
        }
    }


    public string[] GetStackAlphabet(out AutomatonError error)
    {
        if (automataType != AutomataType.DPDA && automataType != AutomataType.NPDA)
        {
            error = default;
            return new string[0];
        }

        string[] alphabet = ((PDA)automaton).GetStackAlphabet(out error);

        if (error.code != AutomatonErrorCode.OK)
        {
            ShowError(error);
            return new string[0];
        }

        return alphabet;

    }

    public void AddStackAlphabetSymbol(string symbol, out AutomatonError error)
    {
        string[] strings = { symbol };
        if (automataType != AutomataType.DPDA && automataType != AutomataType.NPDA)
        {
            error = default;
            return;
        }

        ((PDA)automaton).AddStackAlphabet(strings, out error);

        if (error.code != AutomatonErrorCode.OK)
        {
            ShowError(error);
            return;
        }

        OnStackAlphabetUpdated?.Invoke();
    }

    public void RemoveStackAlphabetSymbol(string symbol, out AutomatonError error)
    {
        if (automataType != AutomataType.DPDA && automataType != AutomataType.NPDA)
        {
            error = default;
            return;
        }


        ((PDA)automaton).RemoveStackAlphabetSymbol(symbol, out error);


        if (error.code != AutomatonErrorCode.OK) return;

        OnStackAlphabetUpdated?.Invoke();
    }

    public string[] GetTapeAlphabet(out AutomatonError error)
    {
        if (automaton.type != "DTM" && automaton.type != "NTM")
        {
            error = default;
            return new string[0];
        }

        string[] alphabet = ((TM)automaton).GetTapeAlphabet(out error);

        if (error.code != AutomatonErrorCode.OK)
        {
            ShowError(error);
            return new string[0];
        }

        return alphabet;
    }

    public void AddTapeAlphabetSymbol(string symbol, out AutomatonError error)
    {
        string[] strings = { symbol };
        if (automaton.type != "DTM" && automaton.type != "NTM")
        {
            error = default;
            return;
        }

        ((TM)automaton).AddTapeAlphabet(strings, out error);

        if (error.code != AutomatonErrorCode.OK)
        {
            ShowError(error);
            return;
        }

        OnTapeAlphabetUpdated?.Invoke();
    }

    public void RemoveTapeAlphabetSymbol(string symbol, out AutomatonError error)
    {
        if (automaton.type != "DTM" && automaton.type != "NTM")
        {
            error = default;
            return;
        }


        ((TM)automaton).RemoveTapeAlphabetSymbol(symbol, out error);

        if (error.code != AutomatonErrorCode.OK)
        {
            ShowError(error);
            return;
        }

        OnTapeAlphabetUpdated?.Invoke();
    }

    public void WriteTape(string symbol, out AutomatonError error)
    {
        if (automaton.type != "DTM" && automaton.type != "NTM")
        {
            error = default;
            return;
        }

        ((TM)automaton).WriteTape(symbol, out error);
        OnTapeUpdated?.Invoke();
    }

    public void MoveTape(string direction, out AutomatonError error)
    {
        if (automaton.type != "DTM" && automaton.type != "NTM")
        {
            error = default;
            return;
        }

        ((TM)automaton).MoveTapeHead(direction, out error);

        if (error.code != AutomatonErrorCode.OK)
        {
            ShowError(error);
            return;
        }

        OnTapeUpdated?.Invoke();
    }

    public string[] GetTape(out AutomatonError error)
    {
        if (automaton.type != "DTM" && automaton.type != "NTM")
        {
            error = default;
            return new string[0];
        }


        string[] tape = ((TM)automaton).getTape(out error);

        if (error.code != AutomatonErrorCode.OK)
        {
            ShowError(error);
            return new string[0];
        }

        return tape;
    }

    public int GetTapeHead(out AutomatonError error)
    {
        if (automaton.type != "DTM" && automaton.type != "NTM")
        {
            error = default;
            return 0;
        }


        int head = ((TM)automaton).GetTapehead(out error);

        if (error.code != AutomatonErrorCode.OK)
        {
            ShowError(error);
            return 0;
        }

        return head;
    }

    public void AddTransition(string[] parameters, out AutomatonError error)
    {
        automaton.AddTransition(parameters, out error);


        if (error.code != AutomatonErrorCode.OK)
        {
            ShowError(error);
            return;
        }

        OnTransitionAdded?.Invoke();
    }

    public void RemoveTransition(string key, out AutomatonError error)
    {
        automaton.RemoveTransition(key, out error);


        if (error.code != AutomatonErrorCode.OK)
        {
            ShowError(error);
            return;
        }

        OnTransitionRemoved?.Invoke();
    }

    public void ClearInputAlphabet(out AutomatonError error)
    {
        automaton.ClearInputAlphabet(out error);

        OnInputAlphabetUpdated?.Invoke();
    }

    public void ResetAutomata(out AutomatonError error)
    {
        automaton.Reset(out error);

        if (error.code != AutomatonErrorCode.OK)
        {
            ShowError(error);
            return;
        }

        OnAutomatonReset?.Invoke();
        OnCurrentStateUpdated?.Invoke();
        OnStackUpdated?.Invoke();
        OnTapeUpdated?.Invoke();
    }

    public void ClearAutomata(out AutomatonError error)
    {
        CreateAutomaton(automataType, out error);
        OnAutomatonCleared?.Invoke();
    }

    public void ProcessInput(out AutomatonError error)
    {
        automaton.ProcessInput(out error);

        if (error.code != AutomatonErrorCode.OK)
        {
            ShowError(error);
            return;
        }

        OnInputProcessed?.Invoke();
        OnInputHeadUpdated?.Invoke();
        OnCurrentStateUpdated?.Invoke();
        OnStackUpdated?.Invoke();
        OnTapeUpdated?.Invoke();
    }

    public void CheckNextState(string key, out AutomatonError error)
    {
        bool flag = automaton.CheckState(key, out error);

        if (error.code != AutomatonErrorCode.OK)
        {
            ShowError(error);
            return;
        }

        if (!flag)
        {
            errorDisplay.ShowError("Incorrect next state");
        }
    }

    public void UpdateStateAccept(string key, bool accept, out AutomatonError error)
    {
        if (accept)
        {
            automaton.AddAcceptState(key, out error);
        }
        else
        {
            automaton.RemoveAcceptState(key, out error);
        }

        if (error.code != AutomatonErrorCode.OK)
        {
            ShowError(error);
            return;
        }

        OnStateUpdated?.Invoke();
    }

    public void ShowError(AutomatonError error)
    {
        errorDisplay.ShowError(error.GetMessage());
    }
}
