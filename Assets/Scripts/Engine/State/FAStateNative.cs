using System;
using System.Runtime.InteropServices;

namespace AutomataSimulator
{
    internal static class FAStateNative
    {
        private const string DllName = "AutomataSimulator.dll";

        [StructLayout(LayoutKind.Sequential)]
        internal struct FAStateArray
        {
            public IntPtr data;
            public UIntPtr length;
        }

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr FAState_create(
            [MarshalAs(UnmanagedType.LPStr)] string label,
            [MarshalAs(UnmanagedType.I1)] bool isAccept);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void FAState_destroy(IntPtr state);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr FAState_getKey(IntPtr state);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void FAState_setLabel(
            IntPtr state,
            [MarshalAs(UnmanagedType.LPStr)] string label);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr FAState_getLabel(IntPtr state);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool FAState_getIsAccept(IntPtr state);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void FAState_setIsAccept(
            IntPtr state,
            [MarshalAs(UnmanagedType.I1)] bool isAccept);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool FAState_transitionExists(
            IntPtr state,
            [MarshalAs(UnmanagedType.LPStr)] string key);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void FAState_addTransition(
            IntPtr state,
            [MarshalAs(UnmanagedType.LPStr)] string toStateKey,
            [MarshalAs(UnmanagedType.LPStr)] string input);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr FAState_getTransition(
            IntPtr state,
            [MarshalAs(UnmanagedType.LPStr)] string key);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr FAState_getTransitionInput(
            IntPtr state,
            [MarshalAs(UnmanagedType.LPStr)] string transitionKey);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void FAState_setTransitionInput(
            IntPtr state,
            [MarshalAs(UnmanagedType.LPStr)] string transitionKey,
            [MarshalAs(UnmanagedType.LPStr)] string input);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr FAState_getTransitionToState(
            IntPtr state,
            [MarshalAs(UnmanagedType.LPStr)] string transitionKey);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void FAState_setTransitionToState(
            IntPtr state,
            [MarshalAs(UnmanagedType.LPStr)] string transitionKey,
            [MarshalAs(UnmanagedType.LPStr)] string toState);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void FAState_removeTransition(
            IntPtr state,
            [MarshalAs(UnmanagedType.LPStr)] string transitionKey);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void FAState_clearTransitionsTo(
            IntPtr state,
            [MarshalAs(UnmanagedType.LPStr)] string toStateKey);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern FATransitionNative.FATransitionArray FAState_getTransitions(IntPtr state);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void FAState_clearTransitions(IntPtr state);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr FAState_toString(IntPtr state);
    }
}