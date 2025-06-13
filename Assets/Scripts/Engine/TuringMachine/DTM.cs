using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static AutomataSimulator.TMStateNative;

namespace AutomataSimulator
{
    public class DTM : TM
    {
        public DTM(out AutomatonError error)
        {
            _handle = DTMNative.DTM_create(out error);
            if (_handle == IntPtr.Zero)
            {
                throw new InvalidOperationException("Failed to create DTM");
            }
            type = "DTM";
        }

        internal DTM(IntPtr handle)
        {
            _handle = handle;
        }

        public override string[] GetInput(out AutomatonError error)
        {
            var nativeArray = DTMNative.DTM_getInput(_handle, out error);
            return MarshalStringArray(nativeArray);
        }

        public override void SetInput(string[] input, out AutomatonError error)
        {
            DTMNative.DTM_setInput(_handle, input, (UIntPtr)input.Length, out error);
        }

        public override void AddInput(string[] input, out AutomatonError error)
        {
            DTMNative.DTM_addInput(_handle, input, (UIntPtr)input.Length, out error);
        }

        public override int GetInputHead(out AutomatonError error)
        {
            return DTMNative.DTM_getInputHead(_handle, out error);
        }

        public override void SetInputHead(int head, out AutomatonError error)
        {
            DTMNative.DTM_setInputHead(_handle, head, out error);
        }

        public override bool StateExists(string key, out AutomatonError error)
        {
            return DTMNative.DTM_stateExists(_handle, key, out error);
        }

        public override bool InputAlphabetSymbolExists(string symbol, out AutomatonError error)
        {
            return DTMNative.DTM_inputAlphabetSymbolExists(_handle, symbol, out error);
        }

        public override void AddState(string label, out AutomatonError error)
        {
            DTMNative.DTM_addState(_handle, label, false, out error);
        }

        public override void UpdateStateLabel(string key, string label, out AutomatonError error)
        {
            DTMNative.DTM_updateStateLabel(_handle, key, label, out error);
        }

        public override string GetCurrentState(out AutomatonError error)
        {
            return Util.CopyAndFreeNativeString(DTMNative.DTM_getCurrentState(_handle, out error));
        }

        public override void SetCurrentState(string state, out AutomatonError error)
        {
            DTMNative.DTM_setCurrentState(_handle, state, out error);
        }

        public override State GetState(string key, out AutomatonError error)
        {
            IntPtr stateHandle = DTMNative.DTM_getState(_handle, key, out error);
            if (stateHandle == IntPtr.Zero)
            {
                return null;
            }
            return new TMState(stateHandle, ownsHandle: false);
        }

        public override int GetStatesCount(out AutomatonError error)
        {
            TMStateArray states = DTMNative.DTM_getStates(_handle, out error);
            return (int)states.length;
        }

        public override List<string> GetStatesKeys(out AutomatonError error)
        {
            List<TMState> states = TMState.FromNativeArray(DTMNative.DTM_getStates(_handle, out error));
            List<string> result = new List<string>();

            foreach (TMState state in states)
            {
                result.Add(state.Key);
            }

            return result;
        }

        public override void RemoveState(string key, out AutomatonError error)
        {
            DTMNative.DTM_removeState(_handle, key, false, out error);
        }

        public override void RemoveStates(string[] keys, out AutomatonError error)
        {
            DTMNative.DTM_removeStates(_handle, keys, (UIntPtr)keys.Length, false, out error);
        }

        public override void ClearStates(out AutomatonError error)
        {
            DTMNative.DTM_clearStates(_handle, out error);
        }

        public override void SetInputAlphabet(string[] inputAlphabet, out AutomatonError error)
        {
            DTMNative.DTM_setInputAlphabet(_handle, inputAlphabet, (UIntPtr)inputAlphabet.Length, false, out error);
        }

        public override void AddInputAlphabet(string[] inputAlphabet, out AutomatonError error)
        {
            DTMNative.DTM_addInputAlphabet(_handle, inputAlphabet, (UIntPtr)inputAlphabet.Length, out error);
        }

        public override string[] GetInputAlphabet(out AutomatonError error)
        {
            var nativeArray = DTMNative.DTM_getInputAlphabet(_handle, out error);
            return MarshalStringArray(nativeArray);
        }

        public override void RemoveInputAlphabetSymbol(string symbol, out AutomatonError error)
        {
            DTMNative.DTM_removeInputAlphabetSymbol(_handle, symbol, false, out error);
        }

        public override void RemoveInputAlphabetSymbols(string[] symbols, out AutomatonError error)
        {
            DTMNative.DTM_removeInputAlphabetSymbols(_handle, symbols, (UIntPtr)symbols.Length, false, out error);
        }

        public override void ClearInputAlphabet(out AutomatonError error)
        {
            DTMNative.DTM_clearInputAlphabet(_handle, false, out error);
        }

        public override void SetTapeAlphabet(string[] tapeAlphabet, out AutomatonError error)
        {
            DTMNative.DTM_setTapeAlphabet(_handle, tapeAlphabet, (UIntPtr)tapeAlphabet.Length, false, out error);
        }

        public override void AddTapeAlphabet(string[] tapeAlphabet, out AutomatonError error)
        {
            DTMNative.DTM_addTapeAlphabet(_handle, tapeAlphabet, (UIntPtr)tapeAlphabet.Length, out error);
        }

        public override string[] GetTapeAlphabet(out AutomatonError error)
        {
            var nativeArray = DTMNative.DTM_getTapeAlphabet(_handle, out error);
            return MarshalStringArray(nativeArray);
        }

        public override void RemoveTapeAlphabetSymbol(string symbol, out AutomatonError error)
        {
            DTMNative.DTM_removeTapeAlphabetSymbol(_handle, symbol, false, out error);
        }

        public override void RemoveTapeAlphabetSymbols(string[] symbols, out AutomatonError error)
        {
            DTMNative.DTM_removeTapeAlphabetSymbols(_handle, symbols, (UIntPtr)symbols.Length, false, out error);
        }

        public override void ClearTapeAlphabet(out AutomatonError error)
        {
            DTMNative.DTM_clearTapeAlphabet(_handle, false, out error);
        }

        public override string GetStartState(out AutomatonError error)
        {
            return Util.CopyAndFreeNativeString(DTMNative.DTM_getStartState(_handle, out error));
        }

        public override void SetStartState(string key, out AutomatonError error)
        {
            DTMNative.DTM_setStartState(_handle, key, out error);
        }

        public override Transition GetTransition(string key, out AutomatonError error)
        {
            IntPtr stateHandle = DTMNative.DTM_getTransition(_handle, key, out error);
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

            DTMNative.DTM_addTransition(_handle, fromStateKey, toStateKey, readSymbol, writeSymbol, direction, out error);
        }

        public override void UpdateTransitionInput(string transitionKey, string input, out AutomatonError error)
        {
            DTMNative.DTM_updateTransitionReadSymbol(_handle, transitionKey, input, out error);
        }

        public override void UpdateTransitionFromState(string transitionKey, string fromStateKey, out AutomatonError error)
        {
            DTMNative.DTM_updateTransitionFromState(_handle, transitionKey, fromStateKey, out error);
        }

        public override void UpdateTransitionToState(string transitionKey, string toStateKey, out AutomatonError error)
        {
            DTMNative.DTM_updateTransitionToState(_handle, transitionKey, toStateKey, out error);
        }

        public override void UpdateTransitionReadSymbol(string transitionKey, string input, out AutomatonError error)
        {
            DTMNative.DTM_updateTransitionReadSymbol(_handle, transitionKey, input, out error);
        }

        public override void UpdateTransitionWriteSymbol(string transitionKey, string input, out AutomatonError error)
        {
            DTMNative.DTM_updateTransitionWriteSymbol(_handle, transitionKey, input, out error);
        }

        public override void UpdateTransitionDirection(string transitionKey, string input, out AutomatonError error)
        {
            DTMNative.DTM_updateTransitionDirection(_handle, transitionKey, input, out error);
        }

        public override void RemoveTransition(string transitionKey, out AutomatonError error)
        {
            DTMNative.DTM_removeTransition(_handle, transitionKey, out error);
        }

        public override void ClearTransitionsBetween(string fromStateKey, string toStateKey, out AutomatonError error)
        {
            DTMNative.DTM_clearTransitionsBetween(_handle, fromStateKey, toStateKey, out error);
        }

        public override void ClearStateTransitions(string stateKey, out AutomatonError error)
        {
            DTMNative.DTM_clearStateTransitions(_handle, stateKey, out error);
        }

        public override void ClearTransitions(out AutomatonError error)
        {
            DTMNative.DTM_clearTransitions(_handle, out error);
        }

        public override void AddAcceptState(string stateKey, out AutomatonError error)
        {
            DTMNative.DTM_addAcceptState(_handle, stateKey, out error);
        }

        public override void AddAcceptStates(string[] keys, out AutomatonError error)
        {
            DTMNative.DTM_addAcceptStates(_handle, keys, (UIntPtr)keys.Length, out error);
        }

        public override void RemoveAcceptState(string stateKey, out AutomatonError error)
        {
            DTMNative.DTM_removeAcceptState(_handle, stateKey, out error);
        }

        public override void RemoveAcceptStates(string[] keys, out AutomatonError error)
        {
            DTMNative.DTM_removeAcceptStates(_handle, keys, (UIntPtr)keys.Length, out error);
        }

        public override void ClearAcceptStates(out AutomatonError error)
        {
            DTMNative.DTM_clearAcceptStates(_handle, out error);
        }

        public override List<string> GetAcceptStates(out AutomatonError error)
        {
            List<TMState> states = TMState.FromNativeArray(DTMNative.DTM_getAcceptStates(_handle, out error));
            List<string> keys = new List<string>();

            foreach (TMState state in states)
            {
                keys.Add(state.Key);
            }

            return keys;
        }

        public override void Reset(out AutomatonError error)
        {
            DTMNative.DTM_reset(_handle, out error);
        }

        public override bool IsAccepting(out AutomatonError error)
        {
            return DTMNative.DTM_isAccepting(_handle, out error);
        }

        public override bool ProcessInput(out AutomatonError error)
        {
            return DTMNative.DTM_processInput(_handle, out error);
        }

        public override bool Simulate(string[] input, int depth, out AutomatonError error)
        {
            return DTMNative.DTM_simulate(_handle, input, (UIntPtr)input.Length, depth, out error);
        }

        public override void SetTape(string[] tape, out AutomatonError error)
        {
            DTMNative.DTM_setTape(_handle, tape, (UIntPtr)tape.Length, out error);
        }
        public override string[] getTape(out AutomatonError error)
        {
            return MarshalStringArray(DTMNative.DTM_getTape(_handle, out error));
        }

        public override void SetTapeHead(int headIndex, out AutomatonError error)
        {
            DTMNative.DTM_setTapeHead(_handle, headIndex, out error);
        }

        public override int GetTapehead(out AutomatonError error)
        {
            return DTMNative.DTM_getTapeHead(_handle, out error);
        }

        public override void ResetTape(out AutomatonError error)
        {
            DTMNative.DTM_resetTape(_handle, out error);
        }

        public override void MoveTapeHead(string direction, out AutomatonError error)
        {
            DTMNative.DTM_moveTapeHead(_handle, direction, out error);
        }

        public override void WriteTape(string symbol, out AutomatonError error)
        {
            DTMNative.DTM_writeTape(_handle, symbol, out error);
        }

        public override string ReadTape(out AutomatonError error)
        {
            return Util.CopyAndFreeNativeString(DTMNative.DTM_readTape(_handle, out error));

        }

        public override bool CheckState(string key, out AutomatonError error)
        {
            return DTMNative.DTM_checkNextState(_handle, key, out error);
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (_handle != IntPtr.Zero)
                {
                    DTMNative.DTM_destroy(_handle, out _);
                    _handle = IntPtr.Zero;
                }
                _disposed = true;
            }
        }
    }
}
