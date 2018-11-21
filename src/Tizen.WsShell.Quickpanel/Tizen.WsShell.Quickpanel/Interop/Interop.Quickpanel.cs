using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using Tizen.WsShell;

internal static partial class Interop
{
    internal static partial class Quickpanel
    {
        [DllImport(Libraries.Quickpanel, EntryPoint = "tzsh_quickpanel_create")]
        internal static extern IntPtr Create(IntPtr tzsh, IntPtr win);

        [DllImport(Libraries.Quickpanel, EntryPoint = "tzsh_quickpanel_destroy")]
        internal static extern int Destroy(IntPtr quickpanel);

        [DllImport(Libraries.Quickpanel, EntryPoint = "tzsh_quickpanel_show")]
        internal static extern int Show(IntPtr quickpanel);

        [DllImport(Libraries.Quickpanel, EntryPoint = "tzsh_quickpanel_hide")]
        internal static extern int Hide(IntPtr quickpanel);

        [DllImport(Libraries.Quickpanel, EntryPoint = "tzsh_quickpanel_visible_get")]
        internal static extern int VisibleGet(IntPtr quickpanel, out Int32 visibleState);

        [DllImport(Libraries.Quickpanel, EntryPoint = "tzsh_quickpanel_scrollable_set")]
        internal static extern int ScrollableSet(IntPtr quickpanel, bool scrollable);

        [DllImport(Libraries.Quickpanel, EntryPoint = "tzsh_quickpanel_scrollable_get")]
        internal static extern int ScrollableGet(IntPtr quickpanel, out IntPtr scrollable);

        [DllImport(Libraries.Quickpanel, EntryPoint = "tzsh_quickpanel_orientation_get")]
        internal static extern int OrientationGet(IntPtr quickpanel, out IntPtr orientation);


        //TODO: EVENTS

        //[DllImport(Libraries.Quickpanel, EntryPoint = "tzsh_quickpanel_destroy")]
        //internal static extern int ScrollableSet(IntPtr quickpanel, bool scrollable);
        //[DllImport(Libraries.Quickpanel, EntryPoint = "tzsh_quickpanel_destroy")]
        //internal static extern int ScrollableSet(IntPtr quickpanel, bool scrollable);
        //[DllImport(Libraries.Quickpanel, EntryPoint = "tzsh_quickpanel_destroy")]
        //internal static extern int ScrollableSet(IntPtr quickpanel, bool scrollable);
        //[DllImport(Libraries.Quickpanel, EntryPoint = "tzsh_quickpanel_destroy")]
        //internal static extern int ScrollableSet(IntPtr quickpanel, bool scrollable);
    }
}
