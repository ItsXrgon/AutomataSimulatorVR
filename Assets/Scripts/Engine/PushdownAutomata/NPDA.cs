using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static AutomataSimulator.PDAStateNative;

namespace AutomataSimulator
{
    public class NPDA : PDA
    {
        public NPDA(out AutomatonError error)
        {
            _handle = NPDANative.NPDA_create(out error);
            if (_handle == IntPtr.Zero)
            {
                throw new InvalidOperationException("Failed to create NPDA");
            }
            type = "NPDA";
        }

        internal NPDA(IntPtr handle)
        {
            _handle = handle;
        }

        public override string[] GetInput(out AutomatonError error)
        {
            var nativeArray = NPDANative.NPDA_getInput(_handle, out error);
            return MarshalStringArray(nativeArray);
        }

        public override void SetInput(string[] input, out AutomatonError error)
        {
            NPDANative.NPDA_setInput(_handle, input, (UIntPtr)input.Length, out error);
        }

        public override void AddInput(string[] input, out AutomatonError error)
        {
            NPDANative.NPDA_addInput(_handle, input, (UIntPtr)input.Length, out error);
        }

        public override int GetInputHead(out AutomatonError error)
        {
            return NPDANative.NPDA_getInputHead(_handle, out error);
        }

        public override void SetInputHead(int head, out AutomatonError error)
        {
            NPDANative.NPDA_setInputHead(_handle, head, out error);
        }

        public override bool StateExists(string key, out AutomatonError error)
        {
            return NPDANative.NPDA_stateExists(_handle, key, out error);
        }

        public override bool InputAlphabetSymbolExists(string symbol, out AutomatonError error)
        {
            return NPDANative.NPDA_inputAlphabetSymbolExists(_handle, symbol, out error);
        }

        public override void AddState(string label, out AutomatonError error)
        {
            NPDANative.NPDA_addState(_handle, label, false, out error);
        }

        public override void UpdateStateLabel(string key, string label, out AutomatonError error)
        {
            NPDANative.NPDA_updateStateLabel(_handle, key, label, out error);
        }

        public override string GetCurrentState(out AutomatonError error)
        {
            return NPDANative.NPDA_getCurrentState(_handle, out error);
        }

        public override void SetCurrentState(string state, out AutomatonError error)
        {
            NPDANative.NPDA_setCurrentState(_handle, state, out error);
        }

        public override State GetState(string key, out AutomatonError error)
        {
            IntPtr stateHandle = NPDANative.NPDA_getState(_handle, key, out error);
            if (stateHandle == IntPtr.Zero)
            {
                return null;
            }
            return new PDAState(stateHandle, ownsHandle: false);
        }

        public override int GetStatesCount(out AutomatonError error)
        {
            PDAStateArray states = NPDANative.NPDA_getStates(_handle, out error);
            return (int)states.length;
        }

        public override List<string> GetStatesKeys(out AutomatonError error)
        {
            List<PDAState> states = PDAState.FromNativeArray(NPDANative.NPDA_getStates(_handle, out error));
            List<string> result = new List<string>();

            foreach (PDAState state in states)
            {
                result.Add(state.Key);
            }

            return result;
        }

        public string[] GetPossibleCurrentStates(out AutomatonError error)
        {
            var nativeArray = NPDANative.NPDA_getPossibleCurrentStates(_handle, out error);
            return MarshalStringArray(nativeArray);
        }

        public override void RemoveState(string key, out AutomatonError error)
        {
            NPDANative.NPDA_removeState(_handle, key, false, out error);
        }

        public override void RemoveStates(string[] keys, out AutomatonError error)
        {
            NPDANative.NPDA_removeStates(_handle, keys, (UIntPtr)keys.Length, false, out error);
        }

        public override void ClearStates(out AutomatonError error)
        {
            NPDANative.NPDA_clearStates(_handle, out error);
        }

        public override void SetInputAlphabet(string[] inputAlphabet, out AutomatonError error)
        {
            NPDANative.NPDA_setInputAlphabet(_handle, inputAlphabet, (UIntPtr)inputAlphabet.Length, false, out error);
        }

        public override void AddInputAlphabet(string[] inputAlphabet, out AutomatonError error)
        {
            NPDANative.NPDA_addInputAlphabet(_handle, inputAlphabet, (UIntPtr)inputAlphabet.Length, out error);
        }

        public override string[] GetInputAlphabet(out AutomatonError error)
        {
            var nativeArray = NPDANative.NPDA_getInputAlphabet(_handle, out error);
            return MarshalStringArray(nativeArray);
        }

        public override void RemoveInputAlphabetSymbol(string symbol, out AutomatonError error)
        {
            NPDANative.NPDA_removeInputAlphabetSymbol(_handle, symbol, false, out error);
        }

        public override void RemoveInputAlphabetSymbols(string[] symbols, out AutomatonError error)
        {
            NPDANative.NPDA_removeInputAlphabetSymbols(_handle, symbols, (UIntPtr)symbols.Length, false, out error);
        }

        public override void ClearInputAlphabet(out AutomatonError error)
        {
            NPDANative.NPDA_clearInputAlphabet(_handle, false, out error);
        }

        public override void SetStackAlphabet(string[] stackAlphabet, out AutomatonError error)
        {
            NPDANative.NPDA_setStackAlphabet(_handle, stackAlphabet, (UIntPtr)stackAlphabet.Length, false, out error);
        }

        public override void AddStackAlphabet(string[] stackAlphabet, out AutomatonError error)
        {
            NPDANative.NPDA_addStackAlphabet(_handle, stackAlphabet, (UIntPtr)stackAlphabet.Length, out error);
        }

        public override string[] GetStackAlphabet(out AutomatonError error)
        {
            var nativeArray = NPDANative.NPDA_getStackAlphabet(_handle, out error);
            return MarshalStringArray(nativeArray);
        }

        public override void RemoveStackAlphabetSymbol(string symbol, out AutomatonError error)
        {
            NPDANative.NPDA_removeStackAlphabetSymbol(_handle, symbol, false, out error);
        }

        public override void RemoveStackAlphabetSymbols(string[] symbols, out AutomatonError error)
        {
            NPDANative.NPDA_removeStackAlphabetSymbols(_handle, symbols, (UIntPtr)symbols.Length, false, out error);
        }

        public override void ClearStackAlphabet(out AutomatonError error)
        {
            NPDANative.NPDA_clearStackAlphabet(_handle, false, out error);
        }

        public override string GetStartState(out AutomatonError error)
        {
            return NPDANative.NPDA_getStartState(_handle, out error);
        }

        public override void SetStartState(string key, out AutomatonError error)
        {
            NPDANative.NPDA_setStartState(_handle, key, out error);
        }

        public override Transition GetTransition(string key, out AutomatonError error)
        {
            IntPtr stateHandle = NPDANative.NPDA_getTransition(_handle, key, out error);
            if (stateHandle == IntPtr.Zero)
            {
                return null;
            }
            return new PDATransition(stateHandle, ownsHandle: false);
        }

        public override void AddTransition(string[] parameters, out AutomatonError error)
        {
            string fromStateKey = parameters[0];
            string toStateKey = parameters[1];
            string input = parameters[2];
            string stackSymbol = parameters[3];
            string pushSymbol = parameters[4];

            NPDANative.NPDA_addTransition(_handle, fromStateKey, toStateKey, input, stackSymbol, pushSymbol, out error);
        }

        public override void UpdateTransitionInput(string transitionKey, string input, out AutomatonError error)
        {
            NPDANative.NPDA_updateTransitionInput(_handle, transitionKey, input, out error);
        }

        public override void UpdateTransitionFromState(string transitionKey, string fromStateKey, out AutomatonError error)
        {
            NPDANative.NPDA_updateTransitionFromState(_handle, transitionKey, fromStateKey, out error);
        }

        public override void UpdateTransitionToState(string transitionKey, string toStateKey, out AutomatonError error)
        {
            NPDANative.NPDA_updateTransitionToState(_handle, transitionKey, toStateKey, out error);
        }
        public override void UpdateTransitionStackSymbol(string transitionKey, string toStateKey, out AutomatonError error)
        {
            NPDANative.NPDA_updateTransitionStackSymbol(_handle, transitionKey, toStateKey, out error);
        }

        public override void UpdateTransitionPushSymbol(string transitionKey, string toStateKey, out AutomatonError error)
        {
            NPDANative.NPDA_updateTransitionPushSymbol(_handle, transitionKey, toStateKey, out error);
        }

        public override void RemoveTransition(string transitionKey, out AutomatonError error)
        {
            NPDANative.NPDA_removeTransition(_handle, transitionKey, out error);
        }

        public override void ClearTransitionsBetween(string fromStateKey, string toStateKey, out AutomatonError error)
        {
            NPDANative.NPDA_clearTransitionsBetween(_handle, fromStateKey, toStateKey, out error);
        }

        public override void ClearStateTransitions(string stateKey, out AutomatonError error)
        {
            NPDANative.NPDA_clearStateTransitions(_handle, stateKey, out error);
        }

        public override void ClearTransitions(out AutomatonError error)
        {
            NPDANative.NPDA_clearTransitions(_handle, out error);
        }

        public override void AddAcceptState(string stateKey, out AutomatonError error)
        {
            NPDANative.NPDA_addAcceptState(_handle, stateKey, out error);
        }

        public override void AddAcceptStates(string[] keys, out AutomatonError error)
        {
            NPDANative.NPDA_addAcceptStates(_handle, keys, (UIntPtr)keys.Length, out error);
        }

        public override void RemoveAcceptState(string stateKey, out AutomatonError error)
        {
            NPDANative.NPDA_removeAcceptState(_handle, stateKey, out error);
        }

        public override void RemoveAcceptStates(string[] keys, out AutomatonError error)
        {
            NPDANative.NPDA_removeAcceptStates(_handle, keys, (UIntPtr)keys.Length, out error);
        }

        public override void ClearAcceptStates(out AutomatonError error)
        {
            NPDANative.NPDA_clearAcceptStates(_handle, out error);
        }

        public override List<string> GetAcceptStates(out AutomatonError error)
        {
            List<PDAState> states = PDAState.FromNativeArray(NPDANative.NPDA_getAcceptStates(_handle, out error));
            List<string> keys = new List<string>();

            foreach (PDAState state in states)
            {
                keys.Add(state.Key);
            }

            return keys;
        }

        public override void Reset(out AutomatonError error)
        {
            NPDANative.NPDA_reset(_handle, out error);
        }

        public override bool IsAccepting(out AutomatonError error)
        {
            return NPDANative.NPDA_isAccepting(_handle, out error);
        }

        public override bool ProcessInput(out AutomatonError error)
        {
            return NPDANative.NPDA_processInput(_handle, out error);
        }

        public override bool Simulate(string[] input, int depth, out AutomatonError error)
        {
            return NPDANative.NPDA_simulate(_handle, input, (UIntPtr)input.Length, depth, out error);
        }

        public override string[] GetStack(out AutomatonError error)
        {
            var nativeArray = NPDANative.NPDA_getStack(_handle, out error);
            return MarshalStringArray(nativeArray);
        }

        public override void SetStack(string[] stack, out AutomatonError error)
        {
            NPDANative.NPDA_setStack(_handle, stack, (UIntPtr)stack.Length, out error);
        }

        public override void PushStack(string symbol, out AutomatonError error)
        {
            NPDANative.NPDA_pushStack(_handle, symbol, out error);
        }

        public override string PopStack(out AutomatonError error)
        {
            return Util.CopyAndFreeNativeString(NPDANative.NPDA_popStack(_handle, out error));
        }

        public override string PeekStack(out AutomatonError error)
        {
            return Util.CopyAndFreeNativeString(NPDANative.NPDA_peekStack(_handle, out error));
        }

        public override bool CheckState(string key, out AutomatonError error)
        {
            return NPDANative.NPDA_checkNextState(_handle, key, out error);
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (_handle != IntPtr.Zero)
                {
                    NPDANative.NPDA_destroy(_handle, out AutomatonError error);
                    _handle = IntPtr.Zero;
                }
                _disposed = true;
            }
        }
    }
}
