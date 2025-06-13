using System;
namespace AutomataSimulator
{
    public abstract class State : IDisposable
    {
        protected IntPtr _handle;
        protected bool _disposed = false;

        public abstract string Key { get; }
        public abstract string Label { get; set; }
        public abstract bool IsAccept { get; set; }
        internal IntPtr Handle => _handle;

        public abstract override string ToString();

        #region IDisposable Implementation

        ~State()
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