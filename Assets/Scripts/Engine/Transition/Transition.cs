using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace AutomataSimulator
{
    public abstract class Transition : IDisposable
    {
        protected IntPtr _handle;
        protected bool _disposed = false;

        public abstract string Key { get; }
        public abstract string FromStateKey { get; set; }
        public abstract string ToStateKey { get; set; }
        public abstract string ReadSymbol { get; set; }
        internal IntPtr Handle => _handle;

        public abstract override string ToString();

        #region IDisposable Implementation

        ~Transition()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (_handle != IntPtr.Zero)
                {
                    _handle = IntPtr.Zero;
                }
                _disposed = true;
            }
        }

        #endregion
    }
}