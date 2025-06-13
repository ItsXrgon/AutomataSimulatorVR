using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public struct AutomatonError
{
    public AutomatonErrorCode code;
    public IntPtr message;

    public string GetMessage()
    {
        return message != IntPtr.Zero ? Marshal.PtrToStringAnsi(message) : null;
    }

}
