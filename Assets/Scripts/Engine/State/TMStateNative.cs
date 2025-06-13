using System;
using System.Runtime.InteropServices;

namespace AutomataSimulator
{
    internal static class TMStateNative
    {
        private const string DllName = "AutomataSimulator.dll";

        [StructLayout(LayoutKind.Sequential)]
        internal struct TMStateArray
        {
            public IntPtr data;
            public UIntPtr length;
        }

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr TMState_create(
            [MarshalAs(UnmanagedType.LPStr)] string label,
            [MarshalAs(UnmanagedType.I1)] bool isAccept);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void TMState_destroy(IntPtr state);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr TMState_getKey(IntPtr state);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void TMState_setLabel(
            IntPtr state,
            [MarshalAs(UnmanagedType.LPStr)] string label);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr TMState_getLabel(IntPtr state);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool TMState_getIsAccept(IntPtr state);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void TMState_setIsAccept(
            IntPtr state,
            [MarshalAs(UnmanagedType.I1)] bool isAccept);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool TMState_transitionExists(
            IntPtr state,
            [MarshalAs(UnmanagedType.LPStr)] string key);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void TMState_addTransition(
            IntPtr state,
            [MarshalAs(UnmanagedType.LPStr)] string toStateKey,
            [MarshalAs(UnmanagedType.LPStr)] string input);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr TMState_getTransition(
            IntPtr state,
            [MarshalAs(UnmanagedType.LPStr)] string key);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr TMState_getTransitionInput(
            IntPtr state,
            [MarshalAs(UnmanagedType.LPStr)] string transitionKey);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void TMState_setTransitionInput(
            IntPtr state,
            [MarshalAs(UnmanagedType.LPStr)] string transitionKey,
            [MarshalAs(UnmanagedType.LPStr)] string input);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr TMState_getTransitionToState(
            IntPtr state,
            [MarshalAs(UnmanagedType.LPStr)] string transitionKey);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void TMState_setTransitionToState(
            IntPtr state,
            [MarshalAs(UnmanagedType.LPStr)] string transitionKey,
            [MarshalAs(UnmanagedType.LPStr)] string toState);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void TMState_removeTransition(
            IntPtr state,
            [MarshalAs(UnmanagedType.LPStr)] string transitionKey);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void TMState_clearTransitionsTo(
            IntPtr state,
            [MarshalAs(UnmanagedType.LPStr)] string toStateKey);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern TMTransitionNative.TMTransitionArray TMState_getTransitions(IntPtr state);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void TMState_clearTransitions(IntPtr state);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr TMState_toString(IntPtr state);
    }
}