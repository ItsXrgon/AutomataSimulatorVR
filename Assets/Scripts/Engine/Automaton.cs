using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace AutomataSimulator
{
    public abstract class Automaton : IDisposable
    {
        protected IntPtr _handle;
        protected bool _disposed = false;
        public string type;

        #region Input Management

        public abstract string[] GetInput(out AutomatonError error);

        public abstract void SetInput(string[] input, out AutomatonError error);

        public abstract void AddInput(string[] input, out AutomatonError error);

        public abstract int GetInputHead(out AutomatonError error);

        public abstract void SetInputHead(int head, out AutomatonError error);

        #endregion

        #region State Management

        public abstract bool StateExists(string key, out AutomatonError error);

        public abstract void AddState(string label, out AutomatonError error);

        public abstract void UpdateStateLabel(string key, string label, out AutomatonError error);

        public abstract string GetCurrentState(out AutomatonError error);

        public abstract void SetCurrentState(string state, out AutomatonError error);

        public abstract State GetState(string key, out AutomatonError error);

        public abstract int GetStatesCount(out AutomatonError error);

        public abstract List<string> GetStatesKeys(out AutomatonError error);

        public abstract void RemoveState(string key, out AutomatonError error);

        public abstract void RemoveStates(string[] keys, out AutomatonError error);

        public abstract void ClearStates(out AutomatonError error);

        #endregion

        #region Input Alphabet Management

        public abstract bool InputAlphabetSymbolExists(string symbol, out AutomatonError error);

        public abstract void SetInputAlphabet(string[] inputAlphabet, out AutomatonError error);

        public abstract void AddInputAlphabet(string[] inputAlphabet, out AutomatonError error);

        public abstract string[] GetInputAlphabet(out AutomatonError error);

        public abstract void RemoveInputAlphabetSymbol(string symbol, out AutomatonError error);

        public abstract void RemoveInputAlphabetSymbols(string[] symbols, out AutomatonError error);

        public abstract void ClearInputAlphabet(out AutomatonError error);

        #endregion

        #region Start State Management

        public abstract string GetStartState(out AutomatonError error);

        public abstract void SetStartState(string key, out AutomatonError error);

        #endregion

        #region Transition Management

        public abstract Transition GetTransition(string key, out AutomatonError error);

        public abstract void AddTransition(string[] paramters, out AutomatonError error);

        public abstract void UpdateTransitionInput(string transitionKey, string input, out AutomatonError error);

        public abstract void UpdateTransitionFromState(string transitionKey, string fromStateKey, out AutomatonError error);

        public abstract void UpdateTransitionToState(string transitionKey, string toStateKey, out AutomatonError error);

        public abstract void RemoveTransition(string transitionKey, out AutomatonError error);

        public abstract void ClearTransitionsBetween(string fromStateKey, string toStateKey, out AutomatonError error);

        public abstract void ClearStateTransitions(string stateKey, out AutomatonError error);

        public abstract void ClearTransitions(out AutomatonError error);

        #endregion

        #region Accept State Management

        public abstract void AddAcceptState(string stateKey, out AutomatonError error);

        public abstract void AddAcceptStates(string[] keys, out AutomatonError error);

        public abstract void RemoveAcceptState(string stateKey, out AutomatonError error);

        public abstract void RemoveAcceptStates(string[] keys, out AutomatonError error);

        public abstract void ClearAcceptStates(out AutomatonError error);

        public abstract List<string> GetAcceptStates(out AutomatonError error);

        #endregion

        #region Simulation

        public abstract void Reset(out AutomatonError error);

        public abstract bool IsAccepting(out AutomatonError error);

        public abstract bool ProcessInput(out AutomatonError error);

        public abstract bool Simulate(string[] input, int depth, out AutomatonError error);

        public abstract bool CheckState(string key, out AutomatonError error);

        #endregion

        protected string[] MarshalStringArray(StringArray nativeArray)
        {
            if (nativeArray.data == IntPtr.Zero || nativeArray.length == UIntPtr.Zero)
            {
                return Array.Empty<string>();
            }

            var result = new string[(int)nativeArray.length];
            for (int i = 0; i < result.Length; i++)
            {
                IntPtr stringPtr = Marshal.ReadIntPtr(nativeArray.data, i * IntPtr.Size);
                result[i] = Marshal.PtrToStringAnsi(stringPtr);
            }

            return result;
        }

        #region IDisposable Implementation

        ~Automaton()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected abstract void Dispose(bool disposing);

        #endregion
    }
}