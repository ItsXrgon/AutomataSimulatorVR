using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static AutomataSimulator.FAStateNative;

namespace AutomataSimulator
{
    public class NFA : Automaton
    {
        public NFA(out AutomatonError error)
        {
            _handle = NFANative.NFA_create(out error);
            if (_handle == IntPtr.Zero)
            {
                throw new InvalidOperationException("Failed to create NFA");
            }
            type = "NFA";
        }

        internal NFA(IntPtr handle)
        {
            _handle = handle;
        }

        public override string[] GetInput(out AutomatonError error)
        {
            var nativeArray = NFANative.NFA_getInput(_handle, out error);
            return MarshalStringArray(nativeArray);
        }

        public override void SetInput(string[] input, out AutomatonError error)
        {
            NFANative.NFA_setInput(_handle, input, (UIntPtr)input.Length, out error);
        }

        public override void AddInput(string[] input, out AutomatonError error)
        {
            NFANative.NFA_addInput(_handle, input, (UIntPtr)input.Length, out error);
        }

        public override int GetInputHead(out AutomatonError error)
        {
            return NFANative.NFA_getInputHead(_handle, out error);
        }

        public override void SetInputHead(int head, out AutomatonError error)
        {
            NFANative.NFA_setInputHead(_handle, head, out error);
        }

        public override bool StateExists(string key, out AutomatonError error)
        {
            return NFANative.NFA_stateExists(_handle, key, out error);
        }

        public override bool InputAlphabetSymbolExists(string symbol, out AutomatonError error)
        {
            return NFANative.NFA_inputAlphabetSymbolExists(_handle, symbol, out error);
        }

        public override void AddState(string label, out AutomatonError error)
        {
            NFANative.NFA_addState(_handle, label, false, out error);
        }

        public override void UpdateStateLabel(string key, string label, out AutomatonError error)
        {
            NFANative.NFA_updateStateLabel(_handle, key, label, out error);
        }

        public override string GetCurrentState(out AutomatonError error)
        {
            return Util.CopyAndFreeNativeString(NFANative.NFA_getCurrentState(_handle, out error));
        }

        public override void SetCurrentState(string state, out AutomatonError error)
        {
            NFANative.NFA_setCurrentState(_handle, state, out error);
        }

        public override State GetState(string key, out AutomatonError error)
        {
            IntPtr stateHandle = NFANative.NFA_getState(_handle, key, out error);
            if (stateHandle == IntPtr.Zero)
            {
                return null;
            }

            return new FAState(stateHandle, ownsHandle: false);
        }

        public override int GetStatesCount(out AutomatonError error)
        {
            FAStateArray states = NFANative.NFA_getStates(_handle, out error);
            return (int)states.length;
        }

        public override List<string> GetStatesKeys(out AutomatonError error)
        {
            List<FAState> states = FAState.FromNativeArray(NFANative.NFA_getStates(_handle, out error));
            List<string> result = new List<string>();

            foreach (FAState state in states)
            {
                result.Add(state.Key);
            }

            return result;
        }
        
        public string[] GetPossibleCurrentStates(out AutomatonError error)
        {
            var nativeArray = NFANative.NFA_getPossibleCurrentStates(_handle, out error);
            return MarshalStringArray(nativeArray);
        }

        public override void RemoveState(string key, out AutomatonError error)
        {
            NFANative.NFA_removeState(_handle, key, false, out error);
        }

        public override void RemoveStates(string[] keys, out AutomatonError error)
        {
            NFANative.NFA_removeStates(_handle, keys, (UIntPtr)keys.Length, false, out error);
        }

        public override void ClearStates(out AutomatonError error)
        {
            NFANative.NFA_clearStates(_handle, out error);
        }

        public override void SetInputAlphabet(string[] inputAlphabet, out AutomatonError error)
        {
            NFANative.NFA_setInputAlphabet(_handle, inputAlphabet, (UIntPtr)inputAlphabet.Length, false, out error);
        }

        public override void AddInputAlphabet(string[] inputAlphabet, out AutomatonError error)
        {
            NFANative.NFA_addInputAlphabet(_handle, inputAlphabet, (UIntPtr)inputAlphabet.Length, out error);
        }

        public override string[] GetInputAlphabet(out AutomatonError error)
        {
            var nativeArray = NFANative.NFA_getInputAlphabet(_handle, out error);
            return MarshalStringArray(nativeArray);
        }

        public override void RemoveInputAlphabetSymbol(string symbol, out AutomatonError error)
        {
            NFANative.NFA_removeInputAlphabetSymbol(_handle, symbol, false, out error);
        }

        public override void RemoveInputAlphabetSymbols(string[] symbols, out AutomatonError error)
        {
            NFANative.NFA_removeInputAlphabetSymbols(_handle, symbols, (UIntPtr)symbols.Length, false, out error);
        }

        public override void ClearInputAlphabet(out AutomatonError error)
        {
            NFANative.NFA_clearInputAlphabet(_handle, false, out error);
        }
        public override string GetStartState(out AutomatonError error)
        {
            return Util.CopyAndFreeNativeString(NFANative.NFA_getStartState(_handle, out error));
        }

        public override void SetStartState(string key, out AutomatonError error)
        {
            NFANative.NFA_setStartState(_handle, key, out error);
        }

        public override Transition GetTransition(string key, out AutomatonError error)
        {
            IntPtr stateHandle = NFANative.NFA_getTransition(_handle, key, out error);
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

            NFANative.NFA_addTransition(_handle, fromStateKey, toStateKey, input, out error);
        }

        public override void UpdateTransitionInput(string transitionKey, string input, out AutomatonError error)
        {
            NFANative.NFA_updateTransitionInput(_handle, transitionKey, input, out error);
        }

        public override void UpdateTransitionFromState(string transitionKey, string fromStateKey, out AutomatonError error)
        {
            NFANative.NFA_updateTransitionFromState(_handle, transitionKey, fromStateKey, out error);
        }

        public override void UpdateTransitionToState(string transitionKey, string toStateKey, out AutomatonError error)
        {
            NFANative.NFA_updateTransitionToState(_handle, transitionKey, toStateKey, out error);
        }

        public override void RemoveTransition(string transitionKey, out AutomatonError error)
        {
            NFANative.NFA_removeTransition(_handle, transitionKey, out error);
        }

        public override void ClearTransitionsBetween(string fromStateKey, string toStateKey, out AutomatonError error)
        {
            NFANative.NFA_clearTransitionsBetween(_handle, fromStateKey, toStateKey, out error);
        }

        public override void ClearStateTransitions(string stateKey, out AutomatonError error)
        {
            NFANative.NFA_clearStateTransitions(_handle, stateKey, out error);
        }

        public override void ClearTransitions(out AutomatonError error)
        {
            NFANative.NFA_clearTransitions(_handle, out error);
        }

        public override void AddAcceptState(string stateKey, out AutomatonError error)
        {
            NFANative.NFA_addAcceptState(_handle, stateKey, out error);
        }

        public override void AddAcceptStates(string[] keys, out AutomatonError error)
        {
            NFANative.NFA_addAcceptStates(_handle, keys, (UIntPtr)keys.Length, out error);
        }

        public override void RemoveAcceptState(string stateKey, out AutomatonError error)
        {
            NFANative.NFA_removeAcceptState(_handle, stateKey, out error);
        }

        public override void RemoveAcceptStates(string[] keys, out AutomatonError error)
        {
            NFANative.NFA_removeAcceptStates(_handle, keys, (UIntPtr)keys.Length, out error);
        }

        public override void ClearAcceptStates(out AutomatonError error)
        {
            NFANative.NFA_clearAcceptStates(_handle, out error);
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
            NFANative.NFA_reset(_handle, out error);
        }

        public override bool IsAccepting(out AutomatonError error)
        {
            return NFANative.NFA_isAccepting(_handle, out error);
        }

        public override bool ProcessInput(out AutomatonError error)
        {
            return NFANative.NFA_processInput(_handle, out error);
        }

        public override bool Simulate(string[] input, int depth, out AutomatonError error)
        {
            return NFANative.NFA_simulate(_handle, input, (UIntPtr)input.Length, depth, out error);
        }

        public override bool CheckState(string key, out AutomatonError error)
        {
            return NFANative.NFA_checkNextState(_handle, key, out error);
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (_handle != IntPtr.Zero)
                {
                    NFANative.NFA_destroy(_handle, out AutomatonError error);
                    _handle = IntPtr.Zero;
                }

                _disposed = true;
            }
        }
    }
}