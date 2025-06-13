using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace AutomataSimulator
{
    public class TMTransition : Transition
    {
        public TMTransition(string fromStateKey, string toStateKey, string readSymbol, string writeSymbol, string direction)
        {
            _handle = TMTransitionNative.TMTransition_create(fromStateKey, toStateKey, readSymbol, writeSymbol, direction);
            if (_handle == IntPtr.Zero)
            {
                throw new InvalidOperationException("Failed to create TMTransition");
            }
        }

        internal TMTransition(IntPtr handle, bool ownsHandle = true)
        {
            _handle = handle;
            _disposed = !ownsHandle;
        }

        public override string Key => Util.CopyAndFreeNativeString(TMTransitionNative.TMTransition_getKey(_handle));

        public override string FromStateKey
        {
            get => Util.CopyAndFreeNativeString(TMTransitionNative.TMTransition_getFromStateKey(_handle));
            set => TMTransitionNative.TMTransition_setFromStateKey(_handle, value);
        }

        public override string ToStateKey
        {
            get => Util.CopyAndFreeNativeString(TMTransitionNative.TMTransition_getToStateKey(_handle));
            set => TMTransitionNative.TMTransition_setToStateKey(_handle, value);
        }

        public override string ReadSymbol
        {
            get => Util.CopyAndFreeNativeString(TMTransitionNative.TMTransition_getReadSymbol(_handle));
            set => TMTransitionNative.TMTransition_setReadSymbol(_handle, value);
        }

        public string WriteSymbol
        {
            get => Util.CopyAndFreeNativeString(TMTransitionNative.TMTransition_getWriteSymbol(_handle));
            set => TMTransitionNative.TMTransition_setWriteSymbol(_handle, value);
        }

        public string Direction
        {
            get => Util.CopyAndFreeNativeString(TMTransitionNative.TMTransition_getDirection(_handle));
            set => TMTransitionNative.TMTransition_setDirection(_handle, value);
        }

        public static string GenerateTransitionKey(string fromStateKey, string toStateKey, string readSymbol, string writeSymbol, string direction)
        {
            return Util.CopyAndFreeNativeString(
                TMTransitionNative.TMTransition_generateTransitionKey(fromStateKey, toStateKey, readSymbol, writeSymbol, direction)
            );
        }

        public static string GetFromStateFromKey(string key)
        {
            return Util.CopyAndFreeNativeString(TMTransitionNative.TMTransition_getFromStateFromKey(key));
        }

        public static string GetToStateFromKey(string key)
        {
            return Util.CopyAndFreeNativeString(TMTransitionNative.TMTransition_getToStateFromKey(key));
        }

        public static string GetReadSymbolFromKey(string key)
        {
            return Util.CopyAndFreeNativeString(TMTransitionNative.TMTransition_getReadSymbolFromKey(key));
        }

        public static string GetWriteSymbolFromKey(string key)
        {
            return Util.CopyAndFreeNativeString(TMTransitionNative.TMTransition_getWriteSymbolFromKey(key));
        }

        public static string GetDirectionFromKey(string key)
        {
            return Util.CopyAndFreeNativeString(TMTransitionNative.TMTransition_getDirectionFromKey(key));
        }

        public override string ToString()
        {
            return Util.CopyAndFreeNativeString(TMTransitionNative.toString(_handle));
        }

        internal static List<TMTransition> FromNativeArray(TMTransitionNative.TMTransitionArray array)
        {
            var result = new List<TMTransition>((int)array.length.ToUInt64());

            for (int i = 0; i < (int)array.length.ToUInt64(); i++)
            {
                IntPtr transitionPtr = Marshal.ReadIntPtr(array.data, i * IntPtr.Size);
                result.Add(new TMTransition(transitionPtr, ownsHandle: false));
            }

            return result;
        }
    }
}
