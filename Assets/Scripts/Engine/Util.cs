using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AutomataSimulator
{
    internal class Util
    {
        private const string DllName = "AutomataSimulator.dll";

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern void free_c_string(IntPtr str);

        public static string CopyAndFreeNativeString(IntPtr nativeStr)
        {
            if (nativeStr == IntPtr.Zero)
                return null;

            try
            {
                return Marshal.PtrToStringAnsi(nativeStr);
            }
            finally
            {
                free_c_string(nativeStr);
            }
        }
    }
}
