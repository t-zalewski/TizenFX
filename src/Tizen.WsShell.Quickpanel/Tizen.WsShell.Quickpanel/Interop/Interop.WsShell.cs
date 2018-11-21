using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;


internal static partial class Interop
{
    internal static partial class WsShell
    {
        [DllImport(Libraries.Quickpanel, EntryPoint = "tzsh_create")]
        internal static extern IntPtr Create(IntPtr type);

        [DllImport(Libraries.Quickpanel, EntryPoint = "tzsh_quickpanel_create")]
        internal static extern int Destroy(IntPtr tzsh);
    }
}

