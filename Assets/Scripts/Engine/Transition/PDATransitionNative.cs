using System;
using System.Runtime.InteropServices;

namespace AutomataSimulator
{
    internal static class PDATransitionNative
    {
        private const string DllName = "AutomataSimulator.dll";

        [StructLayout(LayoutKind.Sequential)]
        internal struct PDATransitionArray
        {
            public IntPtr data;
            public UIntPtr length;
        }

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr PDATransition_create(
            [MarshalAs(UnmanagedType.LPStr)] string fromStateKey,
            [MarshalAs(UnmanagedType.LPStr)] string toStateKey,
            [MarshalAs(UnmanagedType.LPStr)] string input,
            [MarshalAs(UnmanagedType.LPStr)] string stackSymbol,
            [MarshalAs(UnmanagedType.LPStr)] string pushSymbol);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void PDATransition_destroy(IntPtr transition);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        internal static extern IntPtr PDATransition_generateTransitionKey(
            [MarshalAs(UnmanagedType.LPStr)] string fromStateKey,
            [MarshalAs(UnmanagedType.LPStr)] string toStateKey,
            [MarshalAs(UnmanagedType.LPStr)] string input,
            [MarshalAs(UnmanagedType.LPStr)] string stackSymbol,
            [MarshalAs(UnmanagedType.LPStr)] string pushSymbol);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        internal static extern IntPtr PDATransition_getFromStateFromKey(
            [MarshalAs(UnmanagedType.LPStr)] string key);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        internal static extern IntPtr PDATransition_getToStateFromKey(
            [MarshalAs(UnmanagedType.LPStr)] string key);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        internal static extern IntPtr PDATransition_getInputFromKey(
            [MarshalAs(UnmanagedType.LPStr)] string key);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        internal static extern IntPtr PDATransition_getStackSymbolFromKey(
        [MarshalAs(UnmanagedType.LPStr)] string key);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        internal static extern IntPtr PDATransition_getPushSymbolFromKey(
        [MarshalAs(UnmanagedType.LPStr)] string key);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        internal static extern IntPtr PDATransition_getKey(IntPtr transition);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void PDATransition_setFromStateKey(
            IntPtr transition,
            [MarshalAs(UnmanagedType.LPStr)] string fromStateKey);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        internal static extern IntPtr PDATransition_getFromStateKey(IntPtr transition);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void PDATransition_setToStateKey(
            IntPtr transition,
            [MarshalAs(UnmanagedType.LPStr)] string toStateKey);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        internal static extern IntPtr PDATransition_getToStateKey(IntPtr transition);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void PDATransition_setInput(
            IntPtr transition,
            [MarshalAs(UnmanagedType.LPStr)] string input);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        internal static extern IntPtr PDATransition_getInput(IntPtr transition);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void PDATransition_setStackSymbol(
         IntPtr transition,
         [MarshalAs(UnmanagedType.LPStr)] string stackSymbol);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        internal static extern IntPtr PDATransition_getStackSymbol(IntPtr transition);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void PDATransition_setPushSymbol(
        IntPtr transition,
        [MarshalAs(UnmanagedType.LPStr)] string pushSymbol);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        internal static extern IntPtr PDATransition_getPushSymbol(IntPtr transition);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        internal static extern IntPtr toString(IntPtr transition);
    }
}