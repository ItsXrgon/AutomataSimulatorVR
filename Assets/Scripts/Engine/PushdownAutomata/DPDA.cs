using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static AutomataSimulator.PDAStateNative;

namespace AutomataSimulator
{
    public class DPDA : PDA
    {
        public DPDA(out AutomatonError error)
        {
            _handle = DPDANative.DPDA_create(out error);
            if (_handle == IntPtr.Zero)
            {
                throw new InvalidOperationException("Failed to create DPDA");
            }
            type = "DPDA";
        }

        internal DPDA(IntPtr handle)
        {
            _handle = handle;
        }

        public override string[] GetInput(out AutomatonError error)
        {
            var nativeArray = DPDANative.DPDA_getInput(_handle, out error);
            return MarshalStringArray(nativeArray);
        }

        public override void SetInput(string[] input, out AutomatonError error)
        {
            DPDANative.DPDA_setInput(_handle, input, (UIntPtr)input.Length, out error);
        }

        public override void AddInput(string[] input, out AutomatonError error)
        {
            DPDANative.DPDA_addInput(_handle, input, (UIntPtr)input.Length, out error);
        }

        public override int GetInputHead(out AutomatonError error)
        {
            return DPDANative.DPDA_getInputHead(_handle, out error);
        }

        public override void SetInputHead(int head, out AutomatonError error)
        {
            DPDANative.DPDA_setInputHead(_handle, head, out error);
        }

        public override bool StateExists(string key, out AutomatonError error)
        {
            return DPDANative.DPDA_stateExists(_handle, key, out error);
        }

        public override bool InputAlphabetSymbolExists(string symbol, out AutomatonError error)
        {
            return DPDANative.DPDA_inputAlphabetSymbolExists(_handle, symbol, out error);
        }

        public override void AddState(string label, out AutomatonError error)
        {
            DPDANative.DPDA_addState(_handle, label, false, out error);
        }

        public override void UpdateStateLabel(string key, string label, out AutomatonError error)
        {
            DPDANative.DPDA_updateStateLabel(_handle, key, label, out error);
        }

        public override string GetCurrentState(out AutomatonError error)
        {
            return Util.CopyAndFreeNativeString(DPDANative.DPDA_getCurrentState(_handle, out error));
        }

        public override void SetCurrentState(string state, out AutomatonError error)
        {
            DPDANative.DPDA_setCurrentState(_handle, state, out error);
        }

        public override State GetState(string key, out AutomatonError error)
        {
            IntPtr stateHandle = DPDANative.DPDA_getState(_handle, key, out error);
            if (stateHandle == IntPtr.Zero)
            {
                return null;
            }
            return new PDAState(stateHandle, ownsHandle: false);
        }

        public override int GetStatesCount(out AutomatonError error)
        {
            PDAStateArray states = DPDANative.DPDA_getStates(_handle, out error);
            return (int)states.length;
        }

        public override List<string> GetStatesKeys(out AutomatonError error)
        {
            List<PDAState> states = PDAState.FromNativeArray(DPDANative.DPDA_getStates(_handle, out error));
            List<string> result = new List<string>();

            foreach (PDAState state in states)
            {
                result.Add(state.Key);
            }

            return result;
        }

        public override void RemoveState(string key, out AutomatonError error)
        {
            DPDANative.DPDA_removeState(_handle, key, false, out error);
        }

        public override void RemoveStates(string[] keys, out AutomatonError error)
        {
            DPDANative.DPDA_removeStates(_handle, keys, (UIntPtr)keys.Length, false, out error);
        }

        public override void ClearStates(out AutomatonError error)
        {
            DPDANative.DPDA_clearStates(_handle, out error);
        }

        public override void SetInputAlphabet(string[] inputAlphabet, out AutomatonError error)
        {
            DPDANative.DPDA_setInputAlphabet(_handle, inputAlphabet, (UIntPtr)inputAlphabet.Length, false, out error);
        }

        public override void AddInputAlphabet(string[] inputAlphabet, out AutomatonError error)
        {
            DPDANative.DPDA_addInputAlphabet(_handle, inputAlphabet, (UIntPtr)inputAlphabet.Length, out error);
        }

        public override string[] GetInputAlphabet(out AutomatonError error)
        {
            var nativeArray = DPDANative.DPDA_getInputAlphabet(_handle, out error);
            return MarshalStringArray(nativeArray);
        }

        public override void RemoveInputAlphabetSymbol(string symbol, out AutomatonError error)
        {
            DPDANative.DPDA_removeInputAlphabetSymbol(_handle, symbol, false, out error);
        }

        public override void RemoveInputAlphabetSymbols(string[] symbols, out AutomatonError error)
        {
            DPDANative.DPDA_removeInputAlphabetSymbols(_handle, symbols, (UIntPtr)symbols.Length, false, out error);
        }

        public override void ClearInputAlphabet(out AutomatonError error)
        {
            DPDANative.DPDA_clearInputAlphabet(_handle, false, out error);
        }

        public override void SetStackAlphabet(string[] stackAlphabet, out AutomatonError error)
        {
            DPDANative.DPDA_setStackAlphabet(_handle, stackAlphabet, (UIntPtr)stackAlphabet.Length, false, out error);
        }

        public override void AddStackAlphabet(string[] stackAlphabet, out AutomatonError error)
        {
            DPDANative.DPDA_addStackAlphabet(_handle, stackAlphabet, (UIntPtr)stackAlphabet.Length, out error);
        }

        public override string[] GetStackAlphabet(out AutomatonError error)
        {
            var nativeArray = DPDANative.DPDA_getStackAlphabet(_handle, out error);
            return MarshalStringArray(nativeArray);
        }

        public override void RemoveStackAlphabetSymbol(string symbol, out AutomatonError error)
        {
            DPDANative.DPDA_removeStackAlphabetSymbol(_handle, symbol, false, out error);
        }

        public override void RemoveStackAlphabetSymbols(string[] symbols, out AutomatonError error)
        {
            DPDANative.DPDA_removeStackAlphabetSymbols(_handle, symbols, (UIntPtr)symbols.Length, false, out error);
        }

        public override void ClearStackAlphabet(out AutomatonError error)
        {
            DPDANative.DPDA_clearStackAlphabet(_handle, false, out error);
        }

        public override string GetStartState(out AutomatonError error)
        {
            return Util.CopyAndFreeNativeString(DPDANative.DPDA_getStartState(_handle, out error));
        }

        public override void SetStartState(string key, out AutomatonError error)
        {
            DPDANative.DPDA_setStartState(_handle, key, out error);
        }

        public override Transition GetTransition(string key, out AutomatonError error)
        {
            IntPtr stateHandle = DPDANative.DPDA_getTransition(_handle, key, out error);
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

            DPDANative.DPDA_addTransition(_handle, fromStateKey, toStateKey, input, stackSymbol, pushSymbol, out error);
        }

        public override void UpdateTransitionInput(string transitionKey, string input, out AutomatonError error)
        {
            DPDANative.DPDA_updateTransitionInput(_handle, transitionKey, input, out error);
        }

        public override void UpdateTransitionFromState(string transitionKey, string fromStateKey, out AutomatonError error)
        {
            DPDANative.DPDA_updateTransitionFromState(_handle, transitionKey, fromStateKey, out error);
        }

        public override void UpdateTransitionToState(string transitionKey, string toStateKey, out AutomatonError error)
        {
            DPDANative.DPDA_updateTransitionToState(_handle, transitionKey, toStateKey, out error);
        }

        public override void UpdateTransitionStackSymbol(string transitionKey, string toStateKey, out AutomatonError error)
        {
            DPDANative.DPDA_updateTransitionStackSymbol(_handle, transitionKey, toStateKey, out error);
        }

        public override void UpdateTransitionPushSymbol(string transitionKey, string toStateKey, out AutomatonError error)
        {
            DPDANative.DPDA_updateTransitionPushSymbol(_handle, transitionKey, toStateKey, out error);
        }

        public override void RemoveTransition(string transitionKey, out AutomatonError error)
        {
            DPDANative.DPDA_removeTransition(_handle, transitionKey, out error);
        }

        public override void ClearTransitionsBetween(string fromStateKey, string toStateKey, out AutomatonError error)
        {
            DPDANative.DPDA_clearTransitionsBetween(_handle, fromStateKey, toStateKey, out error);
        }

        public override void ClearStateTransitions(string stateKey, out AutomatonError error)
        {
            DPDANative.DPDA_clearStateTransitions(_handle, stateKey, out error);
        }

        public override void ClearTransitions(out AutomatonError error)
        {
            DPDANative.DPDA_clearTransitions(_handle, out error);
        }

        public override void AddAcceptState(string stateKey, out AutomatonError error)
        {
            DPDANative.DPDA_addAcceptState(_handle, stateKey, out error);
        }

        public override void AddAcceptStates(string[] keys, out AutomatonError error)
        {
            DPDANative.DPDA_addAcceptStates(_handle, keys, (UIntPtr)keys.Length, out error);
        }

        public override void RemoveAcceptState(string stateKey, out AutomatonError error)
        {
            DPDANative.DPDA_removeAcceptState(_handle, stateKey, out error);
        }

        public override void RemoveAcceptStates(string[] keys, out AutomatonError error)
        {
            DPDANative.DPDA_removeAcceptStates(_handle, keys, (UIntPtr)keys.Length, out error);
        }

        public override void ClearAcceptStates(out AutomatonError error)
        {
            DPDANative.DPDA_clearAcceptStates(_handle, out error);
        }

        public override List<string> GetAcceptStates(out AutomatonError error)
        {
            List<PDAState> states = PDAState.FromNativeArray(DPDANative.DPDA_getAcceptStates(_handle, out error));
            List<string> keys = new List<string>();

            foreach (PDAState state in states)
            {
                keys.Add(state.Key);
            }

            return keys;
        }

        public override void Reset(out AutomatonError error)
        {
            DPDANative.DPDA_reset(_handle, out error);
        }

        public override bool IsAccepting(out AutomatonError error)
        {
            return DPDANative.DPDA_isAccepting(_handle, out error);
        }

        public override bool ProcessInput(out AutomatonError error)
        {
            return DPDANative.DPDA_processInput(_handle, out error);
        }

        public override bool Simulate(string[] input, int depth, out AutomatonError error)
        {
            return DPDANative.DPDA_simulate(_handle, input, (UIntPtr)input.Length, depth, out error);
        }

        public override string[] GetStack(out AutomatonError error)
        {
            var nativeArray = DPDANative.DPDA_getStack(_handle, out error);
            return MarshalStringArray(nativeArray);
        }

        public override void SetStack(string[] stack, out AutomatonError error)
        {
            DPDANative.DPDA_setStack(_handle, stack, (UIntPtr)stack.Length, out error);
        }

        public override void PushStack(string symbol, out AutomatonError error)
        {
            DPDANative.DPDA_pushStack(_handle, symbol, out error);
        }

        public override string PopStack(out AutomatonError error)
        {
            return Util.CopyAndFreeNativeString(DPDANative.DPDA_popStack(_handle, out error));
        }

        public override string PeekStack(out AutomatonError error)
        {
            return Util.CopyAndFreeNativeString(DPDANative.DPDA_peekStack(_handle, out error));
        }

        public override bool CheckState(string key, out AutomatonError error)
        {
            return DPDANative.DPDA_checkNextState(_handle, key, out error);
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (_handle != IntPtr.Zero)
                {
                    DPDANative.DPDA_destroy(_handle, out _);
                    _handle = IntPtr.Zero;
                }
                _disposed = true;
            }
        }
    }
}
