using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;


internal static partial class Interop
{
    internal static partial class WsShell
    {
        [DllImport(Libraries.Quickpanel, EntryPoint = "tzsh_create")]
        internal static extern IntPtr Create(Int32 type);

        [DllImport(Libraries.Quickpanel, EntryPoint = "tzsh_quickpanel_create")]
        internal static extern int Destroy(IntPtr tzsh);

        //TODO: FIND BETTER PLACE FOR THIS
        [DllImport("libelementary.so.1", EntryPoint = "elm_win_window_id_get")]
        internal static extern int GetElmWindowId(IntPtr win);
    }
}

