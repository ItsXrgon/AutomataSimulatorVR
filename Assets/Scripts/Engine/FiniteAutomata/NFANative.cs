using System;
using System.Runtime.InteropServices;

namespace AutomataSimulator
{
    /// <summary>
    /// Contains the native P/Invoke declarations for the NFA C library
    /// </summary>
    internal static class NFANative
    {
        // The name of the DLL containing the native functions
        private const string DllName = "AutomataSimulator.dll";

        // Native function imports
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr NFA_create(out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NFA_destroy(IntPtr dfa, out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern StringArray NFA_getInput(IntPtr dfa, out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NFA_setInput(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] input,
            UIntPtr length,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NFA_addInput(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] input,
            UIntPtr length,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int NFA_getInputHead(IntPtr dfa, out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NFA_setInputHead(IntPtr dfa, int head, out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool NFA_stateExists(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPStr)] string key,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool NFA_inputAlphabetSymbolExists(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPStr)] string symbol,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NFA_addState(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPStr)] string label,
            [MarshalAs(UnmanagedType.I1)] bool isAccept,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NFA_updateStateLabel(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPStr)] string key,
            [MarshalAs(UnmanagedType.LPStr)] string label,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr NFA_getCurrentState(IntPtr dfa, out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NFA_setCurrentState(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPStr)] string state,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr NFA_getState(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPStr)] string key,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern FAStateNative.FAStateArray NFA_getStates(IntPtr dfa, out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern StringArray NFA_getPossibleCurrentStates(IntPtr dfa, out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NFA_removeState(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPStr)] string key,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NFA_removeStates(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] keys,
            UIntPtr length,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NFA_clearStates(IntPtr dfa, out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NFA_setInputAlphabet(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] inputAlphabet,
            UIntPtr length,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NFA_addInputAlphabet(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] inputAlphabet,
            UIntPtr length,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern StringArray NFA_getInputAlphabet(IntPtr dfa, out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NFA_removeInputAlphabetSymbol(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPStr)] string symbol,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NFA_removeInputAlphabetSymbols(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] symbols,
            UIntPtr length,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NFA_clearInputAlphabet(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.I1)] bool strict,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr NFA_getStartState(IntPtr dfa, out AutomatonError errorr);


        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr NFA_getTransition(IntPtr nfa, string key, out AutomatonError error);
        
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NFA_setStartState(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPStr)] string key,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NFA_addTransition(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPStr)] string fromStateKey,
            [MarshalAs(UnmanagedType.LPStr)] string toStateKey,
            [MarshalAs(UnmanagedType.LPStr)] string input,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NFA_updateTransitionInput(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPStr)] string transitionKey,
            [MarshalAs(UnmanagedType.LPStr)] string input,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NFA_updateTransitionFromState(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPStr)] string transitionKey,
            [MarshalAs(UnmanagedType.LPStr)] string fromStateKey,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NFA_updateTransitionToState(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPStr)] string transitionKey,
            [MarshalAs(UnmanagedType.LPStr)] string toStateKey,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NFA_removeTransition(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPStr)] string transitionKey,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NFA_clearTransitionsBetween(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPStr)] string fromStateKey,
            [MarshalAs(UnmanagedType.LPStr)] string toStateKey,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NFA_clearStateTransitions(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPStr)] string stateKey,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NFA_clearTransitions(IntPtr dfa, out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NFA_addAcceptState(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPStr)] string stateKey,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NFA_addAcceptStates(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] keys,
            UIntPtr length,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NFA_removeAcceptState(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPStr)] string stateKey,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NFA_removeAcceptStates(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] keys,
            UIntPtr length,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NFA_clearAcceptStates(IntPtr dfa, out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern FAStateNative.FAStateArray NFA_getAcceptStates(IntPtr dfa, out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void NFA_reset(IntPtr dfa, out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool NFA_isAccepting(IntPtr dfa, out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool NFA_processInput(IntPtr dfa, out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool NFA_simulate(
            IntPtr dfa,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] input,
            UIntPtr length,
            int simulationDepth,
            out AutomatonError errorr);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool NFA_checkNextState(IntPtr dfa, [MarshalAs(UnmanagedType.LPStr)] string key, out AutomatonError error);
    }
}