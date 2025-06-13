using System;
using System.Runtime.InteropServices;

namespace AutomataSimulator
{
    internal static class FATransitionNative
    {
        private const string DllName = "AutomataSimulator.dll";

        [StructLayout(LayoutKind.Sequential)]
        internal struct FATransitionArray
        {
            public IntPtr data; 
            public UIntPtr length;
        }

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr FATransition_create(
            [MarshalAs(UnmanagedType.LPStr)] string fromStateKey,
            [MarshalAs(UnmanagedType.LPStr)] string toStateKey,
            [MarshalAs(UnmanagedType.LPStr)] string input);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void FATransition_destroy(IntPtr transition);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr FATransition_generateTransitionKey(
            [MarshalAs(UnmanagedType.LPStr)] string fromStateKey,
            [MarshalAs(UnmanagedType.LPStr)] string toStateKey,
            [MarshalAs(UnmanagedType.LPStr)] string input);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr FATransition_getFromStateFromKey(
            [MarshalAs(UnmanagedType.LPStr)] string key);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr FATransition_getToStateFromKey(
            [MarshalAs(UnmanagedType.LPStr)] string key);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr FATransition_getInputFromKey(
            [MarshalAs(UnmanagedType.LPStr)] string key);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr FATransition_getKey(IntPtr transition);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void FATransition_setFromStateKey(
            IntPtr transition,
            [MarshalAs(UnmanagedType.LPStr)] string fromStateKey);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr FATransition_getFromStateKey(IntPtr transition);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void FATransition_setToStateKey(
            IntPtr transition,
            [MarshalAs(UnmanagedType.LPStr)] string toStateKey);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr FATransition_getToStateKey(IntPtr transition);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void FATransition_setInput(
            IntPtr transition,
            [MarshalAs(UnmanagedType.LPStr)] string input);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr FATransition_getInput(IntPtr transition);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr FATransition_toString(IntPtr transition);
    }
}