using System;
using System.Runtime.InteropServices;

namespace AutomataSimulator
{
    internal static class PDAStateNative
    {
        private const string DllName = "AutomataSimulator.dll";

        [StructLayout(LayoutKind.Sequential)]
        internal struct PDAStateArray
        {
            public IntPtr data;
            public UIntPtr length;
        }

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr PDAState_create(
            [MarshalAs(UnmanagedType.LPStr)] string label,
            [MarshalAs(UnmanagedType.I1)] bool isAccept);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void PDAState_destroy(IntPtr state);


        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr PDAState_getKey(IntPtr state);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void PDAState_setLabel(
            IntPtr state,
            [MarshalAs(UnmanagedType.LPStr)] string label);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr PDAState_getLabel(IntPtr state);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool PDAState_getIsAccept(IntPtr state);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void PDAState_setIsAccept(
            IntPtr state,
            [MarshalAs(UnmanagedType.I1)] bool isAccept);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool PDAState_transitionExists(
            IntPtr state,
            [MarshalAs(UnmanagedType.LPStr)] string key);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void PDAState_addTransition(
            IntPtr state,
            [MarshalAs(UnmanagedType.LPStr)] string toStateKey,
            [MarshalAs(UnmanagedType.LPStr)] string input,
            [MarshalAs(UnmanagedType.LPStr)] string stackSymbol,
            [MarshalAs(UnmanagedType.LPStr)] string pushSymbol);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr PDAState_getTransition(
            IntPtr state,
            [MarshalAs(UnmanagedType.LPStr)] string key);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr PDAState_getTransitionInput(
            IntPtr state,
            [MarshalAs(UnmanagedType.LPStr)] string transitionKey);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void PDAState_setTransitionInput(
            IntPtr state,
            [MarshalAs(UnmanagedType.LPStr)] string transitionKey,
            [MarshalAs(UnmanagedType.LPStr)] string input);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr PDAState_getTransitionToState(
            IntPtr state,
            [MarshalAs(UnmanagedType.LPStr)] string transitionKey);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void PDAState_setTransitionToState(
            IntPtr state,
            [MarshalAs(UnmanagedType.LPStr)] string transitionKey,
            [MarshalAs(UnmanagedType.LPStr)] string toState);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr PDAState_getTransitionStackSymbol(
        IntPtr state,
        [MarshalAs(UnmanagedType.LPStr)] string transitionKey);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void PDAState_setTransitionStackSymbol(
            IntPtr state,
            [MarshalAs(UnmanagedType.LPStr)] string transitionKey,
            [MarshalAs(UnmanagedType.LPStr)] string stackSymbol);


        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr PDAState_getTransitionPushSymbol(
        IntPtr state,
        [MarshalAs(UnmanagedType.LPStr)] string transitionKey);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void PDAState_setTransitionPushSymbol(
            IntPtr state,
            [MarshalAs(UnmanagedType.LPStr)] string transitionKey,
            [MarshalAs(UnmanagedType.LPStr)] string pushSymbol);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void PDAState_removeTransition(
            IntPtr state,
            [MarshalAs(UnmanagedType.LPStr)] string transitionKey);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void PDAState_clearTransitionsTo(
            IntPtr state,
            [MarshalAs(UnmanagedType.LPStr)] string toStateKey);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern PDATransitionNative.PDATransitionArray PDAState_getTransitions(IntPtr state);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void PDAState_clearTransitions(IntPtr state);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr PDAState_toString(IntPtr state);
    }
}