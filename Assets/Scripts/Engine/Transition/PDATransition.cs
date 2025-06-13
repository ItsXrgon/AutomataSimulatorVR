using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace AutomataSimulator
{
    public class PDATransition : Transition
    {
        public PDATransition(string fromStateKey, string toStateKey, string input, string stackSymbol, string pushSymbol)
        {
            _handle = PDATransitionNative.PDATransition_create(fromStateKey, toStateKey, input, stackSymbol, pushSymbol);
            if (_handle == IntPtr.Zero)
            {
                throw new InvalidOperationException("Failed to create PDATransition");
            }
        }

        internal PDATransition(IntPtr handle, bool ownsHandle = true)
        {
            _handle = handle;
            _disposed = !ownsHandle;
        }

        public override string Key => Util.CopyAndFreeNativeString(PDATransitionNative.PDATransition_getKey(_handle));

        public override string FromStateKey
        {
            get => Util.CopyAndFreeNativeString(PDATransitionNative.PDATransition_getFromStateKey(_handle));
            set => PDATransitionNative.PDATransition_setFromStateKey(_handle, value);
        }

        public override string ToStateKey
        {
            get => Util.CopyAndFreeNativeString(PDATransitionNative.PDATransition_getToStateKey(_handle));
            set => PDATransitionNative.PDATransition_setToStateKey(_handle, value);
        }

        public override string ReadSymbol
        {
            get => Util.CopyAndFreeNativeString(PDATransitionNative.PDATransition_getInput(_handle));
            set => PDATransitionNative.PDATransition_setInput(_handle, value);
        }

        public string StackSymbol
        {
            get => Util.CopyAndFreeNativeString(PDATransitionNative.PDATransition_getStackSymbol(_handle));
            set => PDATransitionNative.PDATransition_setStackSymbol(_handle, value);
        }

        public string PushSymbol
        {
            get => Util.CopyAndFreeNativeString(PDATransitionNative.PDATransition_getPushSymbol(_handle));
            set => PDATransitionNative.PDATransition_setPushSymbol(_handle, value);
        }

        public static string GenerateTransitionKey(string fromStateKey, string toStateKey, string input, string stackSymbol, string pushSymbol)
        {
            return Util.CopyAndFreeNativeString(
                PDATransitionNative.PDATransition_generateTransitionKey(fromStateKey, toStateKey, input, stackSymbol, pushSymbol)
            );
        }

        public static string GetFromStateFromKey(string key)
        {
            return Util.CopyAndFreeNativeString(PDATransitionNative.PDATransition_getFromStateFromKey(key));
        }

        public static string GetToStateFromKey(string key)
        {
            return Util.CopyAndFreeNativeString(PDATransitionNative.PDATransition_getToStateFromKey(key));
        }

        public static string GetInputFromKey(string key)
        {
            return Util.CopyAndFreeNativeString(PDATransitionNative.PDATransition_getInputFromKey(key));
        }

        public static string GetStackSymbolFromKey(string key)
        {
            return Util.CopyAndFreeNativeString(PDATransitionNative.PDATransition_getStackSymbolFromKey(key));
        }

        public static string GetPushSymbolFromKey(string key)
        {
            return Util.CopyAndFreeNativeString(PDATransitionNative.PDATransition_getPushSymbolFromKey(key));
        }

        public override string ToString()
        {
            return Util.CopyAndFreeNativeString(PDATransitionNative.toString(_handle));
        }

        internal static List<PDATransition> FromNativeArray(PDATransitionNative.PDATransitionArray array)
        {
            var result = new List<PDATransition>((int)array.length.ToUInt64());

            for (int i = 0; i < (int)array.length.ToUInt64(); i++)
            {
                IntPtr transitionPtr = Marshal.ReadIntPtr(array.data, i * IntPtr.Size);
                result.Add(new PDATransition(transitionPtr, ownsHandle: false));
            }

            return result;
        }
    }
}