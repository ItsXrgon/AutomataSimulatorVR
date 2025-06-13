using System;
using System.Runtime.InteropServices;

namespace AutomataSimulator
{
    internal static class DFANative
    {
        private const string DllName = "AutomataSimulator.dll";

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr DFA_create(out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DFA_destroy(IntPtr dfa, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern StringArray DFA_getInput(IntPtr dfa, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DFA_setInput(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] input,
            UIntPtr length,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DFA_addInput(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] input,
            UIntPtr length,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DFA_getInputHead(IntPtr dfa, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DFA_setInputHead(IntPtr dfa, int head, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool DFA_stateExists(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPStr)] string key,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool DFA_inputAlphabetSymbolExists(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPStr)] string symbol,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DFA_addState(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPStr)] string label,
            [MarshalAs(UnmanagedType.I1)] bool isAccept,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DFA_updateStateLabel(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPStr)] string key,
            [MarshalAs(UnmanagedType.LPStr)] string label,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr DFA_getCurrentState(IntPtr dfa, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DFA_setCurrentState(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPStr)] string state,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr DFA_getState(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPStr)] string key,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern FAStateNative.FAStateArray DFA_getStates(IntPtr dfa, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DFA_removeState(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPStr)] string key,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DFA_removeStates(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] keys,
            UIntPtr length,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DFA_clearStates(IntPtr dfa, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DFA_setInputAlphabet(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] inputAlphabet,
            UIntPtr length,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DFA_addInputAlphabet(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] inputAlphabet,
            UIntPtr length,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern StringArray DFA_getInputAlphabet(IntPtr dfa, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DFA_removeInputAlphabetSymbol(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPStr)] string symbol,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DFA_removeInputAlphabetSymbols(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] symbols,
            UIntPtr length,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DFA_clearInputAlphabet(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr DFA_getStartState(IntPtr dfa, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DFA_setStartState(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPStr)] string key,
            out AutomatonError error);


        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr DFA_getTransition(IntPtr dfa, string key, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DFA_addTransition(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPStr)] string fromStateKey,
            [MarshalAs(UnmanagedType.LPStr)] string toStateKey,
            [MarshalAs(UnmanagedType.LPStr)] string input,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DFA_updateTransitionInput(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPStr)] string transitionKey,
            [MarshalAs(UnmanagedType.LPStr)] string input,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DFA_updateTransitionFromState(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPStr)] string transitionKey,
            [MarshalAs(UnmanagedType.LPStr)] string fromStateKey,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DFA_updateTransitionToState(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPStr)] string transitionKey,
            [MarshalAs(UnmanagedType.LPStr)] string toStateKey,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DFA_removeTransition(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPStr)] string transitionKey,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DFA_clearTransitionsBetween(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPStr)] string fromStateKey,
            [MarshalAs(UnmanagedType.LPStr)] string toStateKey,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DFA_clearStateTransitions(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPStr)] string stateKey,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DFA_clearTransitions(IntPtr dfa, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DFA_addAcceptState(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPStr)] string stateKey,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DFA_addAcceptStates(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] keys,
            UIntPtr length,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DFA_removeAcceptState(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPStr)] string stateKey,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DFA_removeAcceptStates(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] keys,
            UIntPtr length,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DFA_clearAcceptStates(IntPtr dfa, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern FAStateNative.FAStateArray DFA_getAcceptStates(IntPtr dfa, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DFA_reset(IntPtr dfa, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool DFA_isAccepting(IntPtr dfa, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool DFA_processInput(IntPtr dfa, out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool DFA_simulate(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] input,
            UIntPtr length,
            int simulationDepth,
            out AutomatonError error);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool DFA_checkNextState(IntPtr dfa, [MarshalAs(UnmanagedType.LPStr)] string key, out AutomatonError error);
    }
}