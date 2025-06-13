using System;
using System.Runtime.InteropServices;

namespace AutomataSimulator
{
    internal static class DTMNative
    {
        private const string DllName = "AutomataSimulator.dll";

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr DTM_create(out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DTM_destroy(IntPtr dtm, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern StringArray DTM_getInput(IntPtr dtm, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DTM_setInput(
            IntPtr dtm,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] input,
            UIntPtr length,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DTM_addInput(
            IntPtr dtm,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] input,
            UIntPtr length,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DTM_getInputHead(IntPtr dtm, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DTM_setInputHead(IntPtr dtm, int head, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool DTM_stateExists(
            IntPtr dtm,
            [MarshalAs(UnmanagedType.LPStr)] string key,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool DTM_inputAlphabetSymbolExists(
            IntPtr dtm,
            [MarshalAs(UnmanagedType.LPStr)] string symbol,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DTM_addState(
            IntPtr dtm,
            [MarshalAs(UnmanagedType.LPStr)] string label,
            [MarshalAs(UnmanagedType.I1)] bool isAccept,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DTM_updateStateLabel(
            IntPtr dtm,
            [MarshalAs(UnmanagedType.LPStr)] string key,
            [MarshalAs(UnmanagedType.LPStr)] string label,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr DTM_getCurrentState(IntPtr dtm, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DTM_setCurrentState(
            IntPtr dtm,
            [MarshalAs(UnmanagedType.LPStr)] string state,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr DTM_getState(
            IntPtr dtm,
            [MarshalAs(UnmanagedType.LPStr)] string key,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern TMStateNative.TMStateArray DTM_getStates(IntPtr dtm, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DTM_removeState(
            IntPtr dtm,
            [MarshalAs(UnmanagedType.LPStr)] string key,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DTM_removeStates(
            IntPtr dtm,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] keys,
            UIntPtr length,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DTM_clearStates(IntPtr dtm, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DTM_setInputAlphabet(
            IntPtr dtm,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] inputAlphabet,
            UIntPtr length,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DTM_addInputAlphabet(
            IntPtr dtm,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] inputAlphabet,
            UIntPtr length,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern StringArray DTM_getInputAlphabet(IntPtr dtm, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DTM_removeInputAlphabetSymbol(
            IntPtr dtm,
            [MarshalAs(UnmanagedType.LPStr)] string symbol,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DTM_removeInputAlphabetSymbols(
            IntPtr dtm,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] symbols,
            UIntPtr length,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DTM_clearInputAlphabet(
            IntPtr dtm,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DTM_setTapeAlphabet(
            IntPtr dtm,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] tapeAlphabet,
            UIntPtr length,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DTM_addTapeAlphabet(
            IntPtr dtm,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] tapeAlphabet,
            UIntPtr length,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern StringArray DTM_getTapeAlphabet(IntPtr dtm, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DTM_removeTapeAlphabetSymbol(
            IntPtr dtm,
            [MarshalAs(UnmanagedType.LPStr)] string symbol,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DTM_removeTapeAlphabetSymbols(
            IntPtr dtm,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] symbols,
            UIntPtr length,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DTM_clearTapeAlphabet(
            IntPtr dtm,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr DTM_getStartState(IntPtr dtm, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DTM_setStartState(
            IntPtr dtm,
            [MarshalAs(UnmanagedType.LPStr)] string key,
            out AutomatonError error);


        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr DTM_getTransition(IntPtr dtm, string key, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DTM_addTransition(
            IntPtr dtm,
            [MarshalAs(UnmanagedType.LPStr)] string fromStateKey,
            [MarshalAs(UnmanagedType.LPStr)] string toStateKey,
            [MarshalAs(UnmanagedType.LPStr)] string input,
            [MarshalAs(UnmanagedType.LPStr)] string tapeSymbol,
            [MarshalAs(UnmanagedType.LPStr)] string pushSymbol,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DTM_updateTransitionReadSymbol(
            IntPtr dtm,
            [MarshalAs(UnmanagedType.LPStr)] string transitionKey,
            [MarshalAs(UnmanagedType.LPStr)] string input,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DTM_updateTransitionFromState(
            IntPtr dtm,
            [MarshalAs(UnmanagedType.LPStr)] string transitionKey,
            [MarshalAs(UnmanagedType.LPStr)] string fromStateKey,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DTM_updateTransitionToState(
            IntPtr dtm,
            [MarshalAs(UnmanagedType.LPStr)] string transitionKey,
            [MarshalAs(UnmanagedType.LPStr)] string toStateKey,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DTM_updateTransitionWriteSymbol(
            IntPtr dtm,
            [MarshalAs(UnmanagedType.LPStr)] string transitionKey,
            [MarshalAs(UnmanagedType.LPStr)] string tapeSymbol,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DTM_updateTransitionDirection(
            IntPtr dtm,
            [MarshalAs(UnmanagedType.LPStr)] string transitionKey,
            [MarshalAs(UnmanagedType.LPStr)] string pushSymbol,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DTM_removeTransition(
            IntPtr dtm,
            [MarshalAs(UnmanagedType.LPStr)] string transitionKey,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DTM_clearTransitionsBetween(
            IntPtr dtm,
            [MarshalAs(UnmanagedType.LPStr)] string fromStateKey,
            [MarshalAs(UnmanagedType.LPStr)] string toStateKey,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DTM_clearStateTransitions(
            IntPtr dtm,
            [MarshalAs(UnmanagedType.LPStr)] string stateKey,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DTM_clearTransitions(IntPtr dtm, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DTM_addAcceptState(
            IntPtr dtm,
            [MarshalAs(UnmanagedType.LPStr)] string stateKey,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DTM_addAcceptStates(
            IntPtr dtm,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] keys,
            UIntPtr length,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DTM_removeAcceptState(
            IntPtr dtm,
            [MarshalAs(UnmanagedType.LPStr)] string stateKey,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DTM_removeAcceptStates(
            IntPtr dtm,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] keys,
            UIntPtr length,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DTM_clearAcceptStates(IntPtr dtm, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern TMStateNative.TMStateArray DTM_getAcceptStates(IntPtr dtm, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DTM_reset(IntPtr dtm, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool DTM_isAccepting(IntPtr dtm, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool DTM_processInput(IntPtr dtm, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool DTM_simulate(
            IntPtr dtm,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] input,
            UIntPtr length,
            int simulationDepth,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DTM_setTape(
        IntPtr dtm,
        [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] tape,
        UIntPtr length,
        out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern StringArray DTM_getTape(IntPtr dtm, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DTM_setTapeHead(IntPtr dtm, int headIndex, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DTM_getTapeHead(IntPtr dtm, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DTM_resetTape(IntPtr dtm, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DTM_moveTapeHead(
            IntPtr dtm,
            [MarshalAs(UnmanagedType.LPStr)] string direction,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DTM_writeTape(
            IntPtr dtm,
            [MarshalAs(UnmanagedType.LPStr)] string symbol,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr DTM_readTape(IntPtr dtm, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool DTM_checkNextState(IntPtr dtm, [MarshalAs(UnmanagedType.LPStr)] string key, out AutomatonError error);
    }
}