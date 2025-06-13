using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace AutomataSimulator
{
    public class TMState : State
    {
        public TMState(string label, bool isAccept)
        {
            _handle = TMStateNative.TMState_create(label, isAccept);
            if (_handle == IntPtr.Zero)
            {
                throw new InvalidOperationException("Failed to create TMState");
            }
        }

        internal TMState(IntPtr handle, bool ownsHandle = true)
        {
            _handle = handle;
            _disposed = !ownsHandle;
        }

        public override string Key => Util.CopyAndFreeNativeString(TMStateNative.TMState_getKey(_handle));

        public override string Label
        {
            get => Util.CopyAndFreeNativeString(TMStateNative.TMState_getLabel(_handle));
            set => TMStateNative.TMState_setLabel(_handle, value);
        }

        public override bool IsAccept
        {
            get => TMStateNative.TMState_getIsAccept(_handle);
            set => TMStateNative.TMState_setIsAccept(_handle, value);
        }

        public bool TransitionExists(string key)
        {
            return TMStateNative.TMState_transitionExists(_handle, key);
        }

        public void AddTransition(string toStateKey, string input)
        {
            TMStateNative.TMState_addTransition(_handle, toStateKey, input);
        }

        public TMTransition GetTransition(string key)
        {
            IntPtr transitionHandle = TMStateNative.TMState_getTransition(_handle, key);
            if (transitionHandle == IntPtr.Zero)
            {
                return null;
            }

            return new TMTransition(transitionHandle, ownsHandle: false);
        }

        public string GetTransitionInput(string transitionKey)
        {
            return Util.CopyAndFreeNativeString(TMStateNative.TMState_getTransitionInput(_handle, transitionKey));
        }

        public void SetTransitionInput(string transitionKey, string input)
        {
            TMStateNative.TMState_setTransitionInput(_handle, transitionKey, input);
        }

        public string GetTransitionToState(string transitionKey)
        {
            return Util.CopyAndFreeNativeString(TMStateNative.TMState_getTransitionToState(_handle, transitionKey));
        }

        public void SetTransitionToState(string transitionKey, string toState)
        {
            TMStateNative.TMState_setTransitionToState(_handle, transitionKey, toState);
        }

        public void RemoveTransition(string transitionKey)
        {
            TMStateNative.TMState_removeTransition(_handle, transitionKey);
        }

        public void ClearTransitionsTo(string toStateKey)
        {
            TMStateNative.TMState_clearTransitionsTo(_handle, toStateKey);
        }

        public IReadOnlyList<TMTransition> GetTransitions()
        {
            var nativeArray = TMStateNative.TMState_getTransitions(_handle);

            var transitions = new List<TMTransition>((int)nativeArray.length.ToUInt64());

            for (int i = 0; i < (int)nativeArray.length.ToUInt64(); i++)
            {
                IntPtr transitionPtr = Marshal.ReadIntPtr(nativeArray.data, i * IntPtr.Size);
                transitions.Add(new TMTransition(transitionPtr, ownsHandle: false));
            }

            return transitions;
        }

        public void ClearTransitions()
        {
            TMStateNative.TMState_clearTransitions(_handle);
        }

        public override string ToString()
        {
            return Util.CopyAndFreeNativeString(TMStateNative.TMState_toString(_handle));
        }

        internal static List<TMState> FromNativeArray(TMStateNative.TMStateArray array)
        {
            var result = new List<TMState>((int)array.length.ToUInt64());

            for (int i = 0; i < (int)array.length.ToUInt64(); i++)
            {
                IntPtr statePtr = Marshal.ReadIntPtr(array.data, i * IntPtr.Size);
                result.Add(new TMState(statePtr, ownsHandle: false));
            }

            return result;
        }
    }
}