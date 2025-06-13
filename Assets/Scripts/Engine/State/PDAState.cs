using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace AutomataSimulator
{
    public class PDAState : State
    {
        public PDAState(string label, bool isAccept)
        {
            _handle = PDAStateNative.PDAState_create(label, isAccept);
            if (_handle == IntPtr.Zero)
            {
                throw new InvalidOperationException("Failed to create PDAState");
            }
        }

        internal PDAState(IntPtr handle, bool ownsHandle = true)
        {
            _handle = handle;
            _disposed = !ownsHandle;
        }

        public override string Key => Util.CopyAndFreeNativeString(PDAStateNative.PDAState_getKey(_handle));

        public override string Label
        {
            get => Util.CopyAndFreeNativeString(PDAStateNative.PDAState_getLabel(_handle));
            set => PDAStateNative.PDAState_setLabel(_handle, value);
        }

        public override bool IsAccept
        {
            get => PDAStateNative.PDAState_getIsAccept(_handle);
            set => PDAStateNative.PDAState_setIsAccept(_handle, value);
        }

        public bool TransitionExists(string key)
        {
            return PDAStateNative.PDAState_transitionExists(_handle, key);
        }

        public void AddTransition(string toStateKey, string input, string stackSymbol, string pushSymbol)
        {
            PDAStateNative.PDAState_addTransition(_handle, toStateKey, input, stackSymbol, pushSymbol);
        }

        public PDATransition GetTransition(string key)
        {
            IntPtr transitionHandle = PDAStateNative.PDAState_getTransition(_handle, key);
            if (transitionHandle == IntPtr.Zero)
            {
                return null;
            }

            return new PDATransition(transitionHandle);
        }

        public string GetTransitionInput(string transitionKey)
        {
            return Util.CopyAndFreeNativeString(PDAStateNative.PDAState_getTransitionInput(_handle, transitionKey));
        }

        public void SetTransitionInput(string transitionKey, string input)
        {
            PDAStateNative.PDAState_setTransitionInput(_handle, transitionKey, input);
        }

        public string GetTransitionToState(string transitionKey)
        {
            return Util.CopyAndFreeNativeString(PDAStateNative.PDAState_getTransitionToState(_handle, transitionKey));
        }

        public void SetTransitionToState(string transitionKey, string toState)
        {
            PDAStateNative.PDAState_setTransitionToState(_handle, transitionKey, toState);
        }
        public string GetTransitionStackSymbol(string transitionKey)
        {
            return Util.CopyAndFreeNativeString(PDAStateNative.PDAState_getTransitionStackSymbol(_handle, transitionKey));
        }

        public void SetTransitionStackSymbol(string transitionKey, string stackSymbol)
        {
            PDAStateNative.PDAState_setTransitionStackSymbol(_handle, transitionKey, stackSymbol);
        }

        public string GetTransitionPushSymbol(string transitionKey)
        {
            return Util.CopyAndFreeNativeString(PDAStateNative.PDAState_getTransitionPushSymbol(_handle, transitionKey));
        }

        public void SetTransitionPushSymbol(string transitionKey, string pushSymbol)
        {
            PDAStateNative.PDAState_setTransitionPushSymbol(_handle, transitionKey, pushSymbol);
        }

        public void RemoveTransition(string transitionKey)
        {
            PDAStateNative.PDAState_removeTransition(_handle, transitionKey);
        }

        public void ClearTransitionsTo(string toStateKey)
        {
            PDAStateNative.PDAState_clearTransitionsTo(_handle, toStateKey);
        }

        public IReadOnlyList<PDATransition> GetTransitions()
        {
            var nativeArray = PDAStateNative.PDAState_getTransitions(_handle);

            var transitions = new List<PDATransition>((int)nativeArray.length.ToUInt64());

            for (int i = 0; i < (int)nativeArray.length.ToUInt64(); i++)
            {
                IntPtr transitionPtr = Marshal.ReadIntPtr(nativeArray.data, i * IntPtr.Size);
                transitions.Add(new PDATransition(transitionPtr, ownsHandle: false));
            }

            return transitions;
        }

        public void ClearTransitions()
        {
            PDAStateNative.PDAState_clearTransitions(_handle);
        }

        public override string ToString()
        {
            return Util.CopyAndFreeNativeString(PDAStateNative.PDAState_toString(_handle));
        }

        internal static List<PDAState> FromNativeArray(PDAStateNative.PDAStateArray array)
        {
            var result = new List<PDAState>((int)array.length.ToUInt64());

            for (int i = 0; i < (int)array.length.ToUInt64(); i++)
            {
                IntPtr statePtr = Marshal.ReadIntPtr(array.data, i * IntPtr.Size);
                result.Add(new PDAState(statePtr, ownsHandle: false));
            }

            return result;
        }
    }
}