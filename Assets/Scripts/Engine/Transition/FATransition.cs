using AutomataSimulator;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace AutomataSimulator
{
    public class FATransition : Transition
    {
        public FATransition(string fromStateKey, string toStateKey, string input)
        {

            _handle = FATransitionNative.FATransition_create(fromStateKey, toStateKey, input);
            if (_handle == IntPtr.Zero)
            {
                throw new InvalidOperationException("Failed to create FATransition");
            }
        }

        internal FATransition(IntPtr handle, bool ownsHandle = true)
        {
            _handle = handle;
            _disposed = !ownsHandle;
        }

        public override string Key => Util.CopyAndFreeNativeString(FATransitionNative.FATransition_getKey(_handle));

        public override string FromStateKey
        {
            get => Util.CopyAndFreeNativeString(FATransitionNative.FATransition_getFromStateKey(_handle));
            set => FATransitionNative.FATransition_setFromStateKey(_handle, value);
        }

        public override string ToStateKey
        {
            get => Util.CopyAndFreeNativeString(FATransitionNative.FATransition_getToStateKey(_handle));
            set => FATransitionNative.FATransition_setToStateKey(_handle, value);
        }

        public override string ReadSymbol
        {
            get => Util.CopyAndFreeNativeString(FATransitionNative.FATransition_getInput(_handle));
            set => FATransitionNative.FATransition_setInput(_handle, value);
        }

        public static string GenerateTransitionKey(string fromStateKey, string toStateKey, string input)
        {
            return Util.CopyAndFreeNativeString(FATransitionNative.FATransition_generateTransitionKey(fromStateKey, toStateKey, input));
        }

        public static string GetFromStateFromKey(string key)
        {
            return Util.CopyAndFreeNativeString(FATransitionNative.FATransition_getFromStateFromKey(key));
        }

        public static string GetToStateFromKey(string key)
        {
            return Util.CopyAndFreeNativeString(FATransitionNative.FATransition_getToStateFromKey(key));
        }

        public static string GetInputFromKey(string key)
        {
            return Util.CopyAndFreeNativeString(FATransitionNative.FATransition_getInputFromKey(key));
        }

        public override string ToString()
        {
            return Util.CopyAndFreeNativeString(FATransitionNative.FATransition_toString(_handle));
        }

        internal static List<FATransition> FromNativeArray(FATransitionNative.FATransitionArray array)
        {
            var result = new List<FATransition>((int)array.length.ToUInt64());
            for (int i = 0; i < (int)array.length.ToUInt64(); i++)
            {
                IntPtr transitionPtr = Marshal.ReadIntPtr(array.data, i * IntPtr.Size);
                result.Add(new FATransition(transitionPtr, ownsHandle: false));
            }
            return result;
        }
    }
}