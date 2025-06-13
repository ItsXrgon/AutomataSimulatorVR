using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace AutomataSimulator
{
    public class FAState : State
    {
        public FAState(string label, bool isAccept)
        {
            _handle = FAStateNative.FAState_create(label, isAccept);
            if (_handle == IntPtr.Zero)
            {
                throw new InvalidOperationException("Failed to create FAState");
            }
        }

        internal FAState(IntPtr handle, bool ownsHandle = true)
        {
            _handle = handle;
            _disposed = !ownsHandle;
        }

        public override string Key => Util.CopyAndFreeNativeString(FAStateNative.FAState_getKey(_handle));

        public override string Label
        {
            get => Util.CopyAndFreeNativeString(FAStateNative.FAState_getLabel(_handle));
            set => FAStateNative.FAState_setLabel(_handle, value);
        }

        public override bool IsAccept
        {
            get => FAStateNative.FAState_getIsAccept(_handle);
            set => FAStateNative.FAState_setIsAccept(_handle, value);
        }

        public bool TransitionExists(string key)
        {
            return FAStateNative.FAState_transitionExists(_handle, key);
        }

        public void AddTransition(string toStateKey, string input)
        {
            FAStateNative.FAState_addTransition(_handle, toStateKey, input);
        }

        public FATransition GetTransition(string key)
        {
            IntPtr transitionHandle = FAStateNative.FAState_getTransition(_handle, key);
            if (transitionHandle == IntPtr.Zero)
            {
                return null;
            }

            return new FATransition(transitionHandle, ownsHandle: false);
        }

        public string GetTransitionInput(string transitionKey)
        {
            return Util.CopyAndFreeNativeString(FAStateNative.FAState_getTransitionInput(_handle, transitionKey));
        }

        public void SetTransitionInput(string transitionKey, string input)
        {
            FAStateNative.FAState_setTransitionInput(_handle, transitionKey, input);
        }

        public string GetTransitionToState(string transitionKey)
        {
            return Util.CopyAndFreeNativeString(FAStateNative.FAState_getTransitionToState(_handle, transitionKey));
        }

        public void SetTransitionToState(string transitionKey, string toState)
        {
            FAStateNative.FAState_setTransitionToState(_handle, transitionKey, toState);
        }

        public void RemoveTransition(string transitionKey)
        {
            FAStateNative.FAState_removeTransition(_handle, transitionKey);
        }

        public void ClearTransitionsTo(string toStateKey)
        {
            FAStateNative.FAState_clearTransitionsTo(_handle, toStateKey);
        }

        public IReadOnlyList<FATransition> GetTransitions()
        {
            var nativeArray = FAStateNative.FAState_getTransitions(_handle);

            var transitions = new List<FATransition>((int)nativeArray.length.ToUInt64());

            for (int i = 0; i < (int)nativeArray.length.ToUInt64(); i++)
            {
                IntPtr transitionPtr = Marshal.ReadIntPtr(nativeArray.data, i * IntPtr.Size);
                transitions.Add(new FATransition(transitionPtr, ownsHandle: false));
            }

            return transitions;
        }

        public void ClearTransitions()
        {
            FAStateNative.FAState_clearTransitions(_handle);
        }

        public override string ToString()
        {
            return Util.CopyAndFreeNativeString(FAStateNative.FAState_toString(_handle));
        }

        internal static List<FAState> FromNativeArray(FAStateNative.FAStateArray array)
        {
            var result = new List<FAState>((int)array.length.ToUInt64());

            for (int i = 0; i < (int)array.length.ToUInt64(); i++)
            {
                IntPtr statePtr = Marshal.ReadIntPtr(array.data, i * IntPtr.Size);
                result.Add(new FAState(statePtr, ownsHandle: false));
            }

            return result;
        }
    }
}