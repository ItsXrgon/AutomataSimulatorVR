using System;
using System.Collections.Generic;
using static AutomataSimulator.TMStateNative;

namespace AutomataSimulator
{
    public class NTM : TM
    {
        public NTM(out AutomatonError error)
        {
            _handle = NTMNative.NTM_create(out error);
            if (_handle == IntPtr.Zero)
            {
                throw new InvalidOperationException("Failed to create NTM");
            }
            type = "NTM";
        }

        internal NTM(IntPtr handle)
        {
            _handle = handle;
        }

        public override string[] GetInput(out AutomatonError error)
        {
            var nativeArray = NTMNative.NTM_getInput(_handle, out error);
            return MarshalStringArray(nativeArray);
        }

        public override void SetInput(string[] input, out AutomatonError error)
        {
            NTMNative.NTM_setInput(_handle, input, (UIntPtr)input.Length, out error);
        }

        public override void AddInput(string[] input, out AutomatonError error)
        {
            NTMNative.NTM_addInput(_handle, input, (UIntPtr)input.Length, out error);
        }

        public override int GetInputHead(out AutomatonError error)
        {
            return NTMNative.NTM_getInputHead(_handle, out error);
        }

        public override void SetInputHead(int head, out AutomatonError error)
        {
            NTMNative.NTM_setInputHead(_handle, head, out error);
        }

        public override bool StateExists(string key, out AutomatonError error)
        {
            return NTMNative.NTM_stateExists(_handle, key, out error);
        }

        public override bool InputAlphabetSymbolExists(string symbol, out AutomatonError error)
        {
            return NTMNative.NTM_inputAlphabetSymbolExists(_handle, symbol, out error);
        }

        public override void AddState(string label, out AutomatonError error)
        {
            NTMNative.NTM_addState(_handle, label, false, out error);
        }

        public override void UpdateStateLabel(string key, string label, out AutomatonError error)
        {
            NTMNative.NTM_updateStateLabel(_handle, key, label, out error);
        }

        public override string GetCurrentState(out AutomatonError error)
        {
            return Util.CopyAndFreeNativeString(NTMNative.NTM_getCurrentState(_handle, out error));
        }

        public override void SetCurrentState(string state, out AutomatonError error)
        {
            NTMNative.NTM_setCurrentState(_handle, state, out error);
        }

        public override State GetState(string key, out AutomatonError error)
        {
            IntPtr stateHandle = NTMNative.NTM_getState(_handle, key, out error);
            if (stateHandle == IntPtr.Zero)
            {
                return null;
            }
            return new TMState(stateHandle, ownsHandle: false);
        }

        public override int GetStatesCount(out AutomatonError error)
        {
            TMStateArray states = NTMNative.NTM_getStates(_handle, out error);
            return (int)states.length;
        }

        public override List<string> GetStatesKeys(out AutomatonError error)
        {
            List<TMState> states = TMState.FromNativeArray(NTMNative.NTM_getStates(_handle, out error));
            List<string> result = new List<string>();

            foreach (TMState state in states)
            {
                result.Add(state.Key);
            }

            return result;
        }

        public string[] GetPossibleCurrentStates(out AutomatonError error)
        {
            var nativeArray = NTMNative.NTM_getPossibleCurrentStates(_handle, out error);
            return MarshalStringArray(nativeArray);
        }

        public override void RemoveState(string key, out AutomatonError error)
        {
            NTMNative.NTM_removeState(_handle, key, false, out error);
        }

        public override void RemoveStates(string[] keys, out AutomatonError error)
        {
            NTMNative.NTM_removeStates(_handle, keys, (UIntPtr)keys.Length, false, out error);
        }

        public override void ClearStates(out AutomatonError error)
        {
            NTMNative.NTM_clearStates(_handle, out error);
        }

        public override void SetInputAlphabet(string[] inputAlphabet, out AutomatonError error)
        {
            NTMNative.NTM_setInputAlphabet(_handle, inputAlphabet, (UIntPtr)inputAlphabet.Length, false, out error);
        }

        public override void AddInputAlphabet(string[] inputAlphabet, out AutomatonError error)
        {
            NTMNative.NTM_addInputAlphabet(_handle, inputAlphabet, (UIntPtr)inputAlphabet.Length, out error);
        }

        public override string[] GetInputAlphabet(out AutomatonError error)
        {
            var nativeArray = NTMNative.NTM_getInputAlphabet(_handle, out error);
            return MarshalStringArray(nativeArray);
        }

        public override void RemoveInputAlphabetSymbol(string symbol, out AutomatonError error)
        {
            NTMNative.NTM_removeInputAlphabetSymbol(_handle, symbol, false, out error);
        }

        public override void RemoveInputAlphabetSymbols(string[] symbols, out AutomatonError error)
        {
            NTMNative.NTM_removeInputAlphabetSymbols(_handle, symbols, (UIntPtr)symbols.Length, false, out error);
        }

        public override void ClearInputAlphabet(out AutomatonError error)
        {
            NTMNative.NTM_clearInputAlphabet(_handle, false, out error);
        }

        public override void SetTapeAlphabet(string[] tapeAlphabet, out AutomatonError error)
        {
            NTMNative.NTM_setTapeAlphabet(_handle, tapeAlphabet, (UIntPtr)tapeAlphabet.Length, false, out error);
        }

        public override void AddTapeAlphabet(string[] tapeAlphabet, out AutomatonError error)
        {
            NTMNative.NTM_addTapeAlphabet(_handle, tapeAlphabet, (UIntPtr)tapeAlphabet.Length, out error);
        }

        public override string[] GetTapeAlphabet(out AutomatonError error)
        {
            var nativeArray = NTMNative.NTM_getTapeAlphabet(_handle, out error);
            return MarshalStringArray(nativeArray);
        }

        public override void RemoveTapeAlphabetSymbol(string symbol, out AutomatonError error)
        {
            NTMNative.NTM_removeTapeAlphabetSymbol(_handle, symbol, false, out error);
        }

        public override void RemoveTapeAlphabetSymbols(string[] symbols, out AutomatonError error)
        {
            NTMNative.NTM_removeTapeAlphabetSymbols(_handle, symbols, (UIntPtr)symbols.Length, false, out error);
        }

        public override void ClearTapeAlphabet(out AutomatonError error)
        {
            NTMNative.NTM_clearTapeAlphabet(_handle, false, out error);
        }
        public override string GetStartState(out AutomatonError error)
        {
            return Util.CopyAndFreeNativeString(NTMNative.NTM_getStartState(_handle, out error));
        }

        public override void SetStartState(string key, out AutomatonError error)
        {
            NTMNative.NTM_setStartState(_handle, key, out error);
        }

        public override Transition GetTransition(string key, out AutomatonError error)
        {
            IntPtr stateHandle = NTMNative.NTM_getTransition(_handle, key, out error);
            if (stateHandle == IntPtr.Zero)
            {
                return null;
            }
            return new TMTransition(stateHandle, ownsHandle: false);
        }

        public override void AddTransition(string[] parameters, out AutomatonError error)
        {
            string fromStateKey = parameters[0];
            string toStateKey = parameters[1];
            string readSymbol = parameters[2];
            string writeSymbol = parameters[3];
            string direction = parameters[4];

            NTMNative.NTM_addTransition(_handle, fromStateKey, toStateKey, readSymbol, writeSymbol, direction, out error);
        }

        public override void UpdateTransitionInput(string transitionKey, string input, out AutomatonError error)
        {
            NTMNative.NTM_updateTransitionReadSymbol(_handle, transitionKey, input, out error);
        }

        public override void UpdateTransitionFromState(string transitionKey, string fromStateKey, out AutomatonError error)
        {
            NTMNative.NTM_updateTransitionFromState(_handle, transitionKey, fromStateKey, out error);
        }

        public override void UpdateTransitionToState(string transitionKey, string toStateKey, out AutomatonError error)
        {
            NTMNative.NTM_updateTransitionToState(_handle, transitionKey, toStateKey, out error);
        }
        public override void UpdateTransitionReadSymbol(string transitionKey, string input, out AutomatonError error)
        {
            NTMNative.NTM_updateTransitionReadSymbol(_handle, transitionKey, input, out error);
        }

        public override void UpdateTransitionWriteSymbol(string transitionKey, string input, out AutomatonError error)
        {
            NTMNative.NTM_updateTransitionWriteSymbol(_handle, transitionKey, input, out error);
        }

        public override void UpdateTransitionDirection(string transitionKey, string input, out AutomatonError error)
        {
            NTMNative.NTM_updateTransitionDirection(_handle, transitionKey, input, out error);
        }

        public override void RemoveTransition(string transitionKey, out AutomatonError error)
        {
            NTMNative.NTM_removeTransition(_handle, transitionKey, out error);
        }

        public override void ClearTransitionsBetween(string fromStateKey, string toStateKey, out AutomatonError error)
        {
            NTMNative.NTM_clearTransitionsBetween(_handle, fromStateKey, toStateKey, out error);
        }

        public override void ClearStateTransitions(string stateKey, out AutomatonError error)
        {
            NTMNative.NTM_clearStateTransitions(_handle, stateKey, out error);
        }

        public override void ClearTransitions(out AutomatonError error)
        {
            NTMNative.NTM_clearTransitions(_handle, out error);
        }

        public override void AddAcceptState(string stateKey, out AutomatonError error)
        {
            NTMNative.NTM_addAcceptState(_handle, stateKey, out error);
        }

        public override void AddAcceptStates(string[] keys, out AutomatonError error)
        {
            NTMNative.NTM_addAcceptStates(_handle, keys, (UIntPtr)keys.Length, out error);
        }

        public override void RemoveAcceptState(string stateKey, out AutomatonError error)
        {
            NTMNative.NTM_removeAcceptState(_handle, stateKey, out error);
        }

        public override void RemoveAcceptStates(string[] keys, out AutomatonError error)
        {
            NTMNative.NTM_removeAcceptStates(_handle, keys, (UIntPtr)keys.Length, out error);
        }

        public override void ClearAcceptStates(out AutomatonError error)
        {
            NTMNative.NTM_clearAcceptStates(_handle, out error);
        }

        public override List<string> GetAcceptStates(out AutomatonError error)
        {
            List<TMState> states = TMState.FromNativeArray(NTMNative.NTM_getAcceptStates(_handle, out error));
            List<string> keys = new List<string>();

            foreach (TMState state in states)
            {
                keys.Add(state.Key);
            }

            return keys;
        }
        public override void Reset(out AutomatonError error)
        {
            NTMNative.NTM_reset(_handle, out error);
        }

        public override bool IsAccepting(out AutomatonError error)
        {
            return NTMNative.NTM_isAccepting(_handle, out error);
        }

        public override bool ProcessInput(out AutomatonError error)
        {
            return NTMNative.NTM_processInput(_handle, out error);
        }

        public override bool Simulate(string[] input, int depth, out AutomatonError error)
        {
            return NTMNative.NTM_simulate(_handle, input, (UIntPtr)input.Length, depth, out error);
        }


        public override void SetTape(string[] tape, out AutomatonError error)
        {
            NTMNative.NTM_setTape(_handle, tape, (UIntPtr)tape.Length, out error);
        }
        public override string[] getTape(out AutomatonError error)
        {
            return MarshalStringArray(NTMNative.NTM_getTape(_handle, out error));
        }

        public override void SetTapeHead(int headIndex, out AutomatonError error)
        {
            NTMNative.NTM_setTapeHead(_handle, headIndex, out error);

        }

        public override int GetTapehead(out AutomatonError error)
        {
            return NTMNative.NTM_getTapeHead(_handle, out error);
        }

        public override void ResetTape(out AutomatonError error)
        {
            NTMNative.NTM_resetTape(_handle, out error);
        }

        public override void MoveTapeHead(string direction, out AutomatonError error)
        {
            NTMNative.NTM_moveTapeHead(_handle, direction, out error);
        }

        public override void WriteTape(string symbol, out AutomatonError error)
        {
            NTMNative.NTM_writeTape(_handle, symbol, out error);
        }

        public override string ReadTape(out AutomatonError error)
        {
            return Util.CopyAndFreeNativeString(NTMNative.NTM_readTape(_handle, out error));
        }

        public override bool CheckState(string key, out AutomatonError error)
        {
            return NTMNative.NTM_checkNextState(_handle, key, out error);
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (_handle != IntPtr.Zero)
                {
                    NTMNative.NTM_destroy(_handle, out AutomatonError error);
                    _handle = IntPtr.Zero;
                }
                _disposed = true;
            }
        }
    }
}
