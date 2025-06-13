using System;
using System.Runtime.InteropServices;

namespace AutomataSimulator
{
    internal static class DPDANative
    {
        private const string DllName = "AutomataSimulator.dll";

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr DPDA_create(out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DPDA_destroy(IntPtr dpda, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern StringArray DPDA_getInput(IntPtr dpda, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DPDA_setInput(
            IntPtr dpda,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] input,
            UIntPtr length,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DPDA_addInput(
            IntPtr dpda,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] input,
            UIntPtr length,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DPDA_getInputHead(IntPtr dpda, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DPDA_setInputHead(IntPtr dpda, int head, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool DPDA_stateExists(
            IntPtr dpda,
            [MarshalAs(UnmanagedType.LPStr)] string key,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool DPDA_inputAlphabetSymbolExists(
            IntPtr dpda,
            [MarshalAs(UnmanagedType.LPStr)] string symbol,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DPDA_addState(
            IntPtr dpda,
            [MarshalAs(UnmanagedType.LPStr)] string label,
            [MarshalAs(UnmanagedType.I1)] bool isAccept,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DPDA_updateStateLabel(
            IntPtr dpda,
            [MarshalAs(UnmanagedType.LPStr)] string key,
            [MarshalAs(UnmanagedType.LPStr)] string label,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr DPDA_getCurrentState(IntPtr dpda, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DPDA_setCurrentState(
            IntPtr dpda,
            [MarshalAs(UnmanagedType.LPStr)] string state,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr DPDA_getState(
            IntPtr dpda,
            [MarshalAs(UnmanagedType.LPStr)] string key,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern PDAStateNative.PDAStateArray DPDA_getStates(IntPtr dpda, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DPDA_removeState(
            IntPtr dpda,
            [MarshalAs(UnmanagedType.LPStr)] string key,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DPDA_removeStates(
            IntPtr dpda,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] keys,
            UIntPtr length,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DPDA_clearStates(IntPtr dpda, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DPDA_setInputAlphabet(
            IntPtr dpda,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] inputAlphabet,
            UIntPtr length,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DPDA_addInputAlphabet(
            IntPtr dpda,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] inputAlphabet,
            UIntPtr length,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern StringArray DPDA_getInputAlphabet(IntPtr dpda, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DPDA_removeInputAlphabetSymbol(
            IntPtr dpda,
            [MarshalAs(UnmanagedType.LPStr)] string symbol,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DPDA_removeInputAlphabetSymbols(
            IntPtr dpda,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] symbols,
            UIntPtr length,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DPDA_clearInputAlphabet(
            IntPtr dpda,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DPDA_setStackAlphabet(
            IntPtr dpda,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] stackAlphabet,
            UIntPtr length,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DPDA_addStackAlphabet(
            IntPtr dpda,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] stackAlphabet,
            UIntPtr length,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern StringArray DPDA_getStackAlphabet(IntPtr dpda, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DPDA_removeStackAlphabetSymbol(
            IntPtr dpda,
            [MarshalAs(UnmanagedType.LPStr)] string symbol,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DPDA_removeStackAlphabetSymbols(
            IntPtr dpda,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] symbols,
            UIntPtr length,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DPDA_clearStackAlphabet(
            IntPtr dpda,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr DPDA_getStartState(IntPtr dpda, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DPDA_setStartState(
            IntPtr dpda,
            [MarshalAs(UnmanagedType.LPStr)] string key,
            out AutomatonError error);


        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr DPDA_getTransition(IntPtr dpda, string key, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DPDA_addTransition(
            IntPtr dpda,
            [MarshalAs(UnmanagedType.LPStr)] string fromStateKey,
            [MarshalAs(UnmanagedType.LPStr)] string toStateKey,
            [MarshalAs(UnmanagedType.LPStr)] string input,
            [MarshalAs(UnmanagedType.LPStr)] string stackSymbol,
            [MarshalAs(UnmanagedType.LPStr)] string pushSymbol,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DPDA_updateTransitionInput(
            IntPtr dpda,
            [MarshalAs(UnmanagedType.LPStr)] string transitionKey,
            [MarshalAs(UnmanagedType.LPStr)] string input,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DPDA_updateTransitionFromState(
            IntPtr dpda,
            [MarshalAs(UnmanagedType.LPStr)] string transitionKey,
            [MarshalAs(UnmanagedType.LPStr)] string fromStateKey,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DPDA_updateTransitionToState(
            IntPtr dpda,
            [MarshalAs(UnmanagedType.LPStr)] string transitionKey,
            [MarshalAs(UnmanagedType.LPStr)] string toStateKey,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DPDA_updateTransitionStackSymbol(
            IntPtr dpda,
            [MarshalAs(UnmanagedType.LPStr)] string transitionKey,
            [MarshalAs(UnmanagedType.LPStr)] string stackSymbol,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DPDA_updateTransitionPushSymbol(
            IntPtr dpda,
            [MarshalAs(UnmanagedType.LPStr)] string transitionKey,
            [MarshalAs(UnmanagedType.LPStr)] string pushSymbol,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DPDA_removeTransition(
            IntPtr dpda,
            [MarshalAs(UnmanagedType.LPStr)] string transitionKey,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DPDA_clearTransitionsBetween(
            IntPtr dpda,
            [MarshalAs(UnmanagedType.LPStr)] string fromStateKey,
            [MarshalAs(UnmanagedType.LPStr)] string toStateKey,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DPDA_clearStateTransitions(
            IntPtr dpda,
            [MarshalAs(UnmanagedType.LPStr)] string stateKey,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DPDA_clearTransitions(IntPtr dpda, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DPDA_addAcceptState(
            IntPtr dpda,
            [MarshalAs(UnmanagedType.LPStr)] string stateKey,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DPDA_addAcceptStates(
            IntPtr dpda,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] keys,
            UIntPtr length,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DPDA_removeAcceptState(
            IntPtr dpda,
            [MarshalAs(UnmanagedType.LPStr)] string stateKey,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DPDA_removeAcceptStates(
            IntPtr dpda,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] keys,
            UIntPtr length,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DPDA_clearAcceptStates(IntPtr dpda, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern PDAStateNative.PDAStateArray DPDA_getAcceptStates(IntPtr dpda, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DPDA_reset(IntPtr dpda, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool DPDA_isAccepting(IntPtr dpda, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool DPDA_processInput(IntPtr dpda, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool DPDA_simulate(
            IntPtr dpda,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] input,
            UIntPtr length,
            int simulationDepth,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern StringArray DPDA_getStack(IntPtr dpda, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DPDA_setStack(
            IntPtr dpda,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] stack,
            UIntPtr length,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DPDA_pushStack(
            IntPtr dpda,
            [MarshalAs(UnmanagedType.LPStr)] string symbol,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr DPDA_popStack(IntPtr dpda, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr DPDA_peekStack(IntPtr dpda, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool DPDA_checkNextState(IntPtr dpda, [MarshalAs(UnmanagedType.LPStr)] string key, out AutomatonError error);
    }
}