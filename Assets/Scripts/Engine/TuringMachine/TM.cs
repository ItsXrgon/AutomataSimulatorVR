using UnityEngine.Rendering;

namespace AutomataSimulator
{
    public abstract class TM : Automaton
    {
        public abstract void SetTapeAlphabet(string[] tapeAlphabet, out AutomatonError error);

        public abstract void AddTapeAlphabet(string[] tapeAlphabet, out AutomatonError error);

        public abstract string[] GetTapeAlphabet(out AutomatonError error);

        public abstract void RemoveTapeAlphabetSymbol(string symbol, out AutomatonError error);

        public abstract void RemoveTapeAlphabetSymbols(string[] symbols, out AutomatonError error);

        public abstract void ClearTapeAlphabet(out AutomatonError error);

        public abstract void UpdateTransitionReadSymbol(string transitionKey, string input, out AutomatonError error);

        public abstract void UpdateTransitionWriteSymbol(string transitionKey, string input, out AutomatonError error);

        public abstract void UpdateTransitionDirection(string transitionKey, string input, out AutomatonError error);

        public abstract void SetTape(string[] tape, out AutomatonError error);

        public abstract string[] getTape(out AutomatonError error);

        public abstract void SetTapeHead(int headIndex, out AutomatonError error);

        public abstract int GetTapehead(out AutomatonError error);

        public abstract void ResetTape(out AutomatonError error);

        public abstract void MoveTapeHead(string direction, out AutomatonError error);

        public abstract void WriteTape(string symbol, out AutomatonError error);

        public abstract string ReadTape(out AutomatonError error);
    }
}