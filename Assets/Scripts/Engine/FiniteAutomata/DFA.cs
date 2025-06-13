using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static AutomataSimulator.FAStateNative;

namespace AutomataSimulator
{
    public class DFA : Automaton
    {
        public DFA(out AutomatonError error)
        {
            _handle = DFANative.DFA_create(out error);
            if (_handle == IntPtr.Zero)
            {
                throw new InvalidOperationException("Failed to create DFA");
            }
            type = "DFA";
        }

        internal DFA(IntPtr handle)
        {
            _handle = handle;
        }

        public override string[] GetInput(out AutomatonError error)
        {
            var nativeArray = DFANative.DFA_getInput(_handle, out error);
            return MarshalStringArray(nativeArray);
        }

        public override void SetInput(string[] input, out AutomatonError error)
        {
            DFANative.DFA_setInput(_handle, input, (UIntPtr)input.Length, out error);
        }

        public override void AddInput(string[] input, out AutomatonError error)
        {
            DFANative.DFA_addInput(_handle, input, (UIntPtr)input.Length, out error);
        }

        public override int GetInputHead(out AutomatonError error)
        {
            return DFANative.DFA_getInputHead(_handle, out error);
        }

        public override void SetInputHead(int head, out AutomatonError error)
        {
            DFANative.DFA_setInputHead(_handle, head, out error);
        }

        public override bool StateExists(string key, out AutomatonError error)
        {
            return DFANative.DFA_stateExists(_handle, key, out error);
        }

        public override bool InputAlphabetSymbolExists(string symbol, out AutomatonError error)
        {
            return DFANative.DFA_inputAlphabetSymbolExists(_handle, symbol, out error);
        }

        public override void AddState(string label, out AutomatonError error)
        {
            DFANative.DFA_addState(_handle, label, false, out error);
        }

        public override void UpdateStateLabel(string key, string label, out AutomatonError error)
        {
            DFANative.DFA_updateStateLabel(_handle, key, label, out error);
        }

        public override string GetCurrentState(out AutomatonError error)
        {
            return Util.CopyAndFreeNativeString(DFANative.DFA_getCurrentState(_handle, out error));
        }

        public override void SetCurrentState(string state, out AutomatonError error)
        {
            DFANative.DFA_setCurrentState(_handle, state, out error);
        }

        public override State GetState(string key, out AutomatonError error)
        {
            IntPtr stateHandle = DFANative.DFA_getState(_handle, key, out error);
            if (stateHandle == IntPtr.Zero)
            {
                return null;
            }

            return new FAState(stateHandle, ownsHandle: false);
        }

        public override int GetStatesCount(out AutomatonError error)
        {
            FAStateArray states = DFANative.DFA_getStates(_handle, out error);
            return (int)states.length;
        }

        public override List<string> GetStatesKeys(out AutomatonError error)
        {
            List<FAState> states = FAState.FromNativeArray(DFANative.DFA_getStates(_handle, out error));
            List<string> result = new List<string>();

            foreach (FAState state in states)
            {
                result.Add(state.Key);
            }

            return result;
        }

        public override void RemoveState(string key, out AutomatonError error)
        {
            DFANative.DFA_removeState(_handle, key, false, out error);
        }

        public override void RemoveStates(string[] keys, out AutomatonError error)
        {
            DFANative.DFA_removeStates(_handle, keys, (UIntPtr)keys.Length, false, out error);
        }

        public override void ClearStates(out AutomatonError error)
        {
            DFANative.DFA_clearStates(_handle, out error);
        }

        public override void SetInputAlphabet(string[] inputAlphabet, out AutomatonError error)
        {
            DFANative.DFA_setInputAlphabet(_handle, inputAlphabet, (UIntPtr)inputAlphabet.Length, false, out error);
        }

        public override void AddInputAlphabet(string[] inputAlphabet, out AutomatonError error)
        {
            DFANative.DFA_addInputAlphabet(_handle, inputAlphabet, (UIntPtr)inputAlphabet.Length, out error);
        }

        public override string[] GetInputAlphabet(out AutomatonError error)
        {
            var nativeArray = DFANative.DFA_getInputAlphabet(_handle, out error);
            return MarshalStringArray(nativeArray);
        }

        public override void RemoveInputAlphabetSymbol(string symbol, out AutomatonError error)
        {
            DFANative.DFA_removeInputAlphabetSymbol(_handle, symbol, false, out error);
        }

        public override void RemoveInputAlphabetSymbols(string[] symbols, out AutomatonError error)
        {
            DFANative.DFA_removeInputAlphabetSymbols(_handle, symbols, (UIntPtr)symbols.Length, false, out error);
        }

        public override void ClearInputAlphabet(out AutomatonError error)
        {
            DFANative.DFA_clearInputAlphabet(_handle, false, out error);
        }

        public override string GetStartState(out AutomatonError error)
        {
            return Util.CopyAndFreeNativeString(DFANative.DFA_getStartState(_handle, out error));
        }

        public override void SetStartState(string key, out AutomatonError error)
        {
            DFANative.DFA_setStartState(_handle, key, out error);
        }

        public override Transition GetTransition(string key, out AutomatonError error)
        {
            IntPtr stateHandle = DFANative.DFA_getTransition(_handle, key, out error);
            if (stateHandle == IntPtr.Zero)
            {
                return null;
            }

            return new FATransition(stateHandle, ownsHandle: false);
        }

        public override void AddTransition(string[] parameters, out AutomatonError error)
        {
            string fromStateKey = parameters[0];
            string toStateKey = parameters[1];
            string input = parameters[2];

            DFANative.DFA_addTransition(_handle, fromStateKey, toStateKey, input, out error);
        }

        public override void UpdateTransitionInput(string transitionKey, string input, out AutomatonError error)
        {
            DFANative.DFA_updateTransitionInput(_handle, transitionKey, input, out error);
        }

        public override void UpdateTransitionFromState(string transitionKey, string fromStateKey, out AutomatonError error)
        {
            DFANative.DFA_updateTransitionFromState(_handle, transitionKey, fromStateKey, out error);
        }

        public override void UpdateTransitionToState(string transitionKey, string toStateKey, out AutomatonError error)
        {
            DFANative.DFA_updateTransitionToState(_handle, transitionKey, toStateKey, out error);
        }

        public override void RemoveTransition(string transitionKey, out AutomatonError error)
        {
            DFANative.DFA_removeTransition(_handle, transitionKey, out error);
        }

        public override void ClearTransitionsBetween(string fromStateKey, string toStateKey, out AutomatonError error)
        {
            DFANative.DFA_clearTransitionsBetween(_handle, fromStateKey, toStateKey, out error);
        }

        public override void ClearStateTransitions(string stateKey, out AutomatonError error)
        {
            DFANative.DFA_clearStateTransitions(_handle, stateKey, out error);
        }

        public override void ClearTransitions(out AutomatonError error)
        {
            DFANative.DFA_clearTransitions(_handle, out error);
        }

        public override void AddAcceptState(string stateKey, out AutomatonError error)
        {
            DFANative.DFA_addAcceptState(_handle, stateKey, out error);
        }

        public override void AddAcceptStates(string[] keys, out AutomatonError error)
        {
            DFANative.DFA_addAcceptStates(_handle, keys, (UIntPtr)keys.Length, out error);
        }

        public override void RemoveAcceptState(string stateKey, out AutomatonError error)
        {
            DFANative.DFA_removeAcceptState(_handle, stateKey, out error);
        }

        public override void RemoveAcceptStates(string[] keys, out AutomatonError error)
        {
            DFANative.DFA_removeAcceptStates(_handle, keys, (UIntPtr)keys.Length, out error);
        }

        public override void ClearAcceptStates(out AutomatonError error)
        {
            DFANative.DFA_clearAcceptStates(_handle, out error);
        }

        public override List<string> GetAcceptStates(out AutomatonError error)
        {
            List<FAState> states = FAState.FromNativeArray(DFANative.DFA_getAcceptStates(_handle, out error));
            List<string> keys = new List<string>();

            foreach (FAState state in states)
            {
                keys.Add(state.Key);
            }

            return keys;
        }

        public override void Reset(out AutomatonError error)
        {
            DFANative.DFA_reset(_handle, out error);
        }

        public override bool IsAccepting(out AutomatonError error)
        {
            return DFANative.DFA_isAccepting(_handle, out error);
        }

        public override bool ProcessInput(out AutomatonError error)
        {
            return DFANative.DFA_processInput(_handle, out error);
        }

        public override bool Simulate(string[] input, int depth, out AutomatonError error)
        {
            return DFANative.DFA_simulate(_handle, input, (UIntPtr)input.Length, depth, out error);
        }

        public override bool CheckState(string key, out AutomatonError error)
        {
            return DFANative.DFA_checkNextState(_handle, key, out error);
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (_handle != IntPtr.Zero)
                {
                    DFANative.DFA_destroy(_handle, out AutomatonError error);
                    _handle = IntPtr.Zero;
                }

                _disposed = true;
            }
        }
    }
}
