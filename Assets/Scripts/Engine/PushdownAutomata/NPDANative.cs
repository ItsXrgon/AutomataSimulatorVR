using System;
using System.Runtime.InteropServices;

namespace AutomataSimulator
{
    internal static class NPDANative
    {
        private const string DllName = "AutomataSimulator.dll";

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr NPDA_create(out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NPDA_destroy(IntPtr npda, out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern StringArray NPDA_getInput(IntPtr npda, out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NPDA_setInput(
            IntPtr npda,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] input,
            UIntPtr length,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NPDA_addInput(
            IntPtr npda,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] input,
            UIntPtr length,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int NPDA_getInputHead(IntPtr npda, out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NPDA_setInputHead(IntPtr npda, int head, out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool NPDA_stateExists(
            IntPtr npda,
            [MarshalAs(UnmanagedType.LPStr)] string key,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool NPDA_inputAlphabetSymbolExists(
            IntPtr npda,
            [MarshalAs(UnmanagedType.LPStr)] string symbol,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NPDA_addState(
            IntPtr npda,
            [MarshalAs(UnmanagedType.LPStr)] string label,
            [MarshalAs(UnmanagedType.I1)] bool isAccept,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NPDA_updateStateLabel(
            IntPtr npda,
            [MarshalAs(UnmanagedType.LPStr)] string key,
            [MarshalAs(UnmanagedType.LPStr)] string label,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        internal static extern string NPDA_getCurrentState(IntPtr npda, out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NPDA_setCurrentState(
            IntPtr npda,
            [MarshalAs(UnmanagedType.LPStr)] string state,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr NPDA_getState(
            IntPtr npda,
            [MarshalAs(UnmanagedType.LPStr)] string key,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern PDAStateNative.PDAStateArray NPDA_getStates(IntPtr npda, out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern StringArray NPDA_getPossibleCurrentStates(IntPtr npda, out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NPDA_removeState(
            IntPtr npda,
            [MarshalAs(UnmanagedType.LPStr)] string key,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NPDA_removeStates(
            IntPtr npda,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] keys,
            UIntPtr length,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NPDA_clearStates(IntPtr npda, out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NPDA_setInputAlphabet(
            IntPtr npda,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] inputAlphabet,
            UIntPtr length,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NPDA_addInputAlphabet(
            IntPtr npda,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] inputAlphabet,
            UIntPtr length,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern StringArray NPDA_getInputAlphabet(IntPtr npda, out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NPDA_removeInputAlphabetSymbol(
            IntPtr npda,
            [MarshalAs(UnmanagedType.LPStr)] string symbol,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NPDA_removeInputAlphabetSymbols(
            IntPtr npda,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] symbols,
            UIntPtr length,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NPDA_clearInputAlphabet(
            IntPtr npda,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NPDA_setStackAlphabet(
        IntPtr npda,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] stackAlphabet,
            UIntPtr length,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NPDA_addStackAlphabet(
            IntPtr npda,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] stackAlphabet,
            UIntPtr length,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern StringArray NPDA_getStackAlphabet(IntPtr npda, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NPDA_removeStackAlphabetSymbol(
            IntPtr npda,
            [MarshalAs(UnmanagedType.LPStr)] string symbol,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NPDA_removeStackAlphabetSymbols(
            IntPtr npda,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] symbols,
            UIntPtr length,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NPDA_clearStackAlphabet(
            IntPtr npda,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        internal static extern string NPDA_getStartState(IntPtr npda, out AutomatonError errorr);


        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr NPDA_getTransition(IntPtr nPDA, string key, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NPDA_setStartState(
            IntPtr npda,
            [MarshalAs(UnmanagedType.LPStr)] string key,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NPDA_addTransition(
            IntPtr npda,
            [MarshalAs(UnmanagedType.LPStr)] string fromStateKey,
            [MarshalAs(UnmanagedType.LPStr)] string toStateKey,
            [MarshalAs(UnmanagedType.LPStr)] string input,
            [MarshalAs(UnmanagedType.LPStr)] string stackSymbol,
            [MarshalAs(UnmanagedType.LPStr)] string pushSymbol,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NPDA_updateTransitionInput(
            IntPtr npda,
            [MarshalAs(UnmanagedType.LPStr)] string transitionKey,
            [MarshalAs(UnmanagedType.LPStr)] string input,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NPDA_updateTransitionFromState(
            IntPtr npda,
            [MarshalAs(UnmanagedType.LPStr)] string transitionKey,
            [MarshalAs(UnmanagedType.LPStr)] string fromStateKey,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NPDA_updateTransitionToState(
            IntPtr npda,
            [MarshalAs(UnmanagedType.LPStr)] string transitionKey,
            [MarshalAs(UnmanagedType.LPStr)] string toStateKey,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NPDA_updateTransitionStackSymbol(
        IntPtr npda,
        [MarshalAs(UnmanagedType.LPStr)] string transitionKey,
        [MarshalAs(UnmanagedType.LPStr)] string stackSymbol,
        out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NPDA_updateTransitionPushSymbol(
            IntPtr npda,
            [MarshalAs(UnmanagedType.LPStr)] string transitionKey,
            [MarshalAs(UnmanagedType.LPStr)] string pushSymbol,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NPDA_removeTransition(
            IntPtr npda,
            [MarshalAs(UnmanagedType.LPStr)] string transitionKey,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NPDA_clearTransitionsBetween(
            IntPtr npda,
            [MarshalAs(UnmanagedType.LPStr)] string fromStateKey,
            [MarshalAs(UnmanagedType.LPStr)] string toStateKey,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NPDA_clearStateTransitions(
            IntPtr npda,
            [MarshalAs(UnmanagedType.LPStr)] string stateKey,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NPDA_clearTransitions(IntPtr npda, out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NPDA_addAcceptState(
            IntPtr npda,
            [MarshalAs(UnmanagedType.LPStr)] string stateKey,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NPDA_addAcceptStates(
            IntPtr npda,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] keys,
            UIntPtr length,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NPDA_removeAcceptState(
            IntPtr npda,
            [MarshalAs(UnmanagedType.LPStr)] string stateKey,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NPDA_removeAcceptStates(
            IntPtr npda,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] keys,
            UIntPtr length,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NPDA_clearAcceptStates(IntPtr npda, out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern PDAStateNative.PDAStateArray NPDA_getAcceptStates(IntPtr npda, out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NPDA_reset(IntPtr npda, out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool NPDA_isAccepting(IntPtr npda, out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool NPDA_processInput(IntPtr npda, out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool NPDA_simulate(
            IntPtr npda,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] input,
            UIntPtr length,
            int simulationDepth,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern StringArray NPDA_getStack(IntPtr npda, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NPDA_setStack(
            IntPtr npda,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] stack,
            UIntPtr length,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NPDA_pushStack(
            IntPtr npda,
            [MarshalAs(UnmanagedType.LPStr)] string symbol,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr NPDA_popStack(IntPtr npda, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr NPDA_peekStack(IntPtr npda, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool NPDA_checkNextState(IntPtr npda, [MarshalAs(UnmanagedType.LPStr)] string key, out AutomatonError error);
    }
}