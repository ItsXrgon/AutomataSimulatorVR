using System;
using System.Runtime.InteropServices;

namespace AutomataSimulator
{
    internal static class TMTransitionNative
    {
        private const string DllName = "AutomataSimulator.dll";

        [StructLayout(LayoutKind.Sequential)]
        internal struct TMTransitionArray
        {
            public IntPtr data;
            public UIntPtr length;
        }

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr TMTransition_create(
            [MarshalAs(UnmanagedType.LPStr)] string fromStateKey,
            [MarshalAs(UnmanagedType.LPStr)] string toStateKey,
            [MarshalAs(UnmanagedType.LPStr)] string readSymbol,
            [MarshalAs(UnmanagedType.LPStr)] string writeSymbol,
            [MarshalAs(UnmanagedType.LPStr)] string direction);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void TMTransition_destroy(IntPtr transition);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr TMTransition_generateTransitionKey(
            [MarshalAs(UnmanagedType.LPStr)] string fromStateKey,
            [MarshalAs(UnmanagedType.LPStr)] string toStateKey,
            [MarshalAs(UnmanagedType.LPStr)] string readSymbol,
            [MarshalAs(UnmanagedType.LPStr)] string writeSymbol,
            [MarshalAs(UnmanagedType.LPStr)] string direction);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr TMTransition_getFromStateFromKey(
            [MarshalAs(UnmanagedType.LPStr)] string key);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr TMTransition_getToStateFromKey(
            [MarshalAs(UnmanagedType.LPStr)] string key);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr TMTransition_getReadSymbolFromKey(
            [MarshalAs(UnmanagedType.LPStr)] string key);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr TMTransition_getWriteSymbolFromKey(
        [MarshalAs(UnmanagedType.LPStr)] string key);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr TMTransition_getDirectionFromKey(
        [MarshalAs(UnmanagedType.LPStr)] string key);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr TMTransition_getKey(IntPtr transition);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void TMTransition_setFromStateKey(
            IntPtr transition,
            [MarshalAs(UnmanagedType.LPStr)] string fromStateKey);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr TMTransition_getFromStateKey(IntPtr transition);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void TMTransition_setToStateKey(
            IntPtr transition,
            [MarshalAs(UnmanagedType.LPStr)] string toStateKey);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr TMTransition_getToStateKey(IntPtr transition);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void TMTransition_setReadSymbol(
            IntPtr transition,
            [MarshalAs(UnmanagedType.LPStr)] string readSymbol);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr TMTransition_getReadSymbol(IntPtr transition);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void TMTransition_setWriteSymbol(
         IntPtr transition,
         [MarshalAs(UnmanagedType.LPStr)] string writeSymbol);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr TMTransition_getWriteSymbol(IntPtr transition);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void TMTransition_setDirection(
        IntPtr transition,
        [MarshalAs(UnmanagedType.LPStr)] string direction);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr TMTransition_getDirection(IntPtr transition);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr toString(IntPtr transition);
    }
}