using System;
using System.Runtime.InteropServices;

namespace AutomataSimulator
{
    internal static class NTMNative
    {
        private const string DllName = "AutomataSimulator.dll";

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr NTM_create(out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NTM_destroy(IntPtr ntm, out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern StringArray NTM_getInput(IntPtr ntm, out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NTM_setInput(
            IntPtr ntm,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] input,
            UIntPtr length,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NTM_addInput(
            IntPtr ntm,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] input,
            UIntPtr length,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int NTM_getInputHead(IntPtr ntm, out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NTM_setInputHead(IntPtr ntm, int head, out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool NTM_stateExists(
            IntPtr ntm,
            [MarshalAs(UnmanagedType.LPStr)] string key,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool NTM_inputAlphabetSymbolExists(
            IntPtr ntm,
            [MarshalAs(UnmanagedType.LPStr)] string symbol,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NTM_addState(
            IntPtr ntm,
            [MarshalAs(UnmanagedType.LPStr)] string label,
            [MarshalAs(UnmanagedType.I1)] bool isAccept,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NTM_updateStateLabel(
            IntPtr ntm,
            [MarshalAs(UnmanagedType.LPStr)] string key,
            [MarshalAs(UnmanagedType.LPStr)] string label,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr NTM_getCurrentState(IntPtr ntm, out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NTM_setCurrentState(
            IntPtr ntm,
            [MarshalAs(UnmanagedType.LPStr)] string state,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr NTM_getState(
            IntPtr ntm,
            [MarshalAs(UnmanagedType.LPStr)] string key,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern TMStateNative.TMStateArray NTM_getStates(IntPtr ntm, out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern StringArray NTM_getPossibleCurrentStates(IntPtr ntm, out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NTM_removeState(
            IntPtr ntm,
            [MarshalAs(UnmanagedType.LPStr)] string key,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NTM_removeStates(
            IntPtr ntm,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] keys,
            UIntPtr length,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NTM_clearStates(IntPtr ntm, out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NTM_setInputAlphabet(
            IntPtr ntm,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] inputAlphabet,
            UIntPtr length,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NTM_addInputAlphabet(
            IntPtr ntm,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] inputAlphabet,
            UIntPtr length,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern StringArray NTM_getInputAlphabet(IntPtr ntm, out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NTM_removeInputAlphabetSymbol(
            IntPtr ntm,
            [MarshalAs(UnmanagedType.LPStr)] string symbol,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NTM_removeInputAlphabetSymbols(
            IntPtr ntm,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] symbols,
            UIntPtr length,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NTM_clearInputAlphabet(
            IntPtr ntm,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NTM_setTapeAlphabet(
        IntPtr ntm,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] tapeAlphabet,
            UIntPtr length,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NTM_addTapeAlphabet(
            IntPtr ntm,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] tapeAlphabet,
            UIntPtr length,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern StringArray NTM_getTapeAlphabet(IntPtr ntm, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NTM_removeTapeAlphabetSymbol(
            IntPtr ntm,
            [MarshalAs(UnmanagedType.LPStr)] string symbol,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NTM_removeTapeAlphabetSymbols(
            IntPtr ntm,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] symbols,
            UIntPtr length,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NTM_clearTapeAlphabet(
            IntPtr ntm,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr NTM_getStartState(IntPtr ntm, out AutomatonError errorr);


        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr NTM_getTransition(IntPtr nTM, string key, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NTM_setStartState(
            IntPtr ntm,
            [MarshalAs(UnmanagedType.LPStr)] string key,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NTM_addTransition(
            IntPtr ntm,
            [MarshalAs(UnmanagedType.LPStr)] string fromStateKey,
            [MarshalAs(UnmanagedType.LPStr)] string toStateKey,
            [MarshalAs(UnmanagedType.LPStr)] string input,
            [MarshalAs(UnmanagedType.LPStr)] string tapeSymbol,
            [MarshalAs(UnmanagedType.LPStr)] string pushSymbol,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NTM_updateTransitionReadSymbol(
            IntPtr ntm,
            [MarshalAs(UnmanagedType.LPStr)] string transitionKey,
            [MarshalAs(UnmanagedType.LPStr)] string input,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NTM_updateTransitionFromState(
            IntPtr ntm,
            [MarshalAs(UnmanagedType.LPStr)] string transitionKey,
            [MarshalAs(UnmanagedType.LPStr)] string fromStateKey,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NTM_updateTransitionToState(
            IntPtr ntm,
            [MarshalAs(UnmanagedType.LPStr)] string transitionKey,
            [MarshalAs(UnmanagedType.LPStr)] string toStateKey,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NTM_updateTransitionWriteSymbol(
        IntPtr ntm,
        [MarshalAs(UnmanagedType.LPStr)] string transitionKey,
        [MarshalAs(UnmanagedType.LPStr)] string tapeSymbol,
        out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NTM_updateTransitionDirection(
            IntPtr ntm,
            [MarshalAs(UnmanagedType.LPStr)] string transitionKey,
            [MarshalAs(UnmanagedType.LPStr)] string pushSymbol,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NTM_removeTransition(
            IntPtr ntm,
            [MarshalAs(UnmanagedType.LPStr)] string transitionKey,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NTM_clearTransitionsBetween(
            IntPtr ntm,
            [MarshalAs(UnmanagedType.LPStr)] string fromStateKey,
            [MarshalAs(UnmanagedType.LPStr)] string toStateKey,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NTM_clearStateTransitions(
            IntPtr ntm,
            [MarshalAs(UnmanagedType.LPStr)] string stateKey,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NTM_clearTransitions(IntPtr ntm, out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NTM_addAcceptState(
            IntPtr ntm,
            [MarshalAs(UnmanagedType.LPStr)] string stateKey,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NTM_addAcceptStates(
            IntPtr ntm,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] keys,
            UIntPtr length,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NTM_removeAcceptState(
            IntPtr ntm,
            [MarshalAs(UnmanagedType.LPStr)] string stateKey,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NTM_removeAcceptStates(
            IntPtr ntm,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] keys,
            UIntPtr length,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NTM_clearAcceptStates(IntPtr ntm, out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern TMStateNative.TMStateArray NTM_getAcceptStates(IntPtr ntm, out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NTM_reset(IntPtr ntm, out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool NTM_isAccepting(IntPtr ntm, out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool NTM_processInput(IntPtr ntm, out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool NTM_simulate(
            IntPtr ntm,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] input,
            UIntPtr length,
            int simulationDepth,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NTM_setTape(
        IntPtr ntm,
        [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] tape,
        UIntPtr length,
        out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern StringArray NTM_getTape(IntPtr ntm, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NTM_setTapeHead(IntPtr ntm, int headIndex, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int NTM_getTapeHead(IntPtr ntm, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NTM_resetTape(IntPtr ntm, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NTM_moveTapeHead(
            IntPtr ntm,
            [MarshalAs(UnmanagedType.LPStr)] string direction,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NTM_writeTape(
            IntPtr ntm,
            [MarshalAs(UnmanagedType.LPStr)] string symbol,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr NTM_readTape(IntPtr ntm, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool NTM_checkNextState(IntPtr ntm, [MarshalAs(UnmanagedType.LPStr)] string key, out AutomatonError error);
    }
}