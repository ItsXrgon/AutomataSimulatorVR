using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace AutomataSimulator
{
    public abstract class PDA : Automaton
    {
        public abstract void SetStackAlphabet(string[] stackAlphabet, out AutomatonError error);

        public abstract void AddStackAlphabet(string[] stackAlphabet, out AutomatonError error);

        public abstract string[] GetStackAlphabet(out AutomatonError error);

        public abstract void UpdateTransitionStackSymbol(string transitionKey, string input, out AutomatonError error);

        public abstract void UpdateTransitionPushSymbol(string transitionKey, string input, out AutomatonError error);

        public abstract void RemoveStackAlphabetSymbol(string symbol, out AutomatonError error);

        public abstract void RemoveStackAlphabetSymbols(string[] symbols, out AutomatonError error);

        public abstract void ClearStackAlphabet(out AutomatonError error);

        public abstract string[] GetStack(out AutomatonError error);

        public abstract void SetStack(string[] stack, out AutomatonError error);

        public abstract void PushStack(string symbol, out AutomatonError error);

        public abstract string PopStack(out AutomatonError error);

        public abstract string PeekStack(out AutomatonError error);
    }
}