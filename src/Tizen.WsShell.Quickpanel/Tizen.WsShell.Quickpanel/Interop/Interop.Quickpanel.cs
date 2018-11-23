using System;
using System.Runtime.InteropServices;
using Tizen.Internals.Errors;
using Tizen.WsShell;

internal static partial class Interop
{
    internal static partial class Quickpanel
    {
        public enum QuickpanelVisibility : int
        {
            Unknown,
            Shown,
            Hidden,
        }

        public enum QuickPanelScrollability : int
        {
            Unknown,
            Set,
            Unset,
        }

        [DllImport(Libraries.Quickpanel, EntryPoint = "tzsh_quickpanel_create")]
        internal static extern IntPtr Create(IntPtr tzsh, Int32 win);

        [DllImport(Libraries.Quickpanel, EntryPoint = "tzsh_quickpanel_destroy")]
        internal static extern int Destroy(IntPtr quickpanel);

        [DllImport(Libraries.Quickpanel, EntryPoint = "tzsh_quickpanel_show")]
        internal static extern int Show(IntPtr quickpanel);

        [DllImport(Libraries.Quickpanel, EntryPoint = "tzsh_quickpanel_hide")]
        internal static extern int Hide(IntPtr quickpanel);

        [DllImport(Libraries.Quickpanel, EntryPoint = "tzsh_quickpanel_visible_get")]
        internal static extern int VisibleGet(IntPtr quickpanel, out QuickpanelVisibility visible);

        [DllImport(Libraries.Quickpanel, EntryPoint = "tzsh_quickpanel_scrollable_set")]
        internal static extern int ScrollableSet(IntPtr quickpanel, bool scrollable);

        [DllImport(Libraries.Quickpanel, EntryPoint = "tzsh_quickpanel_scrollable_get")]
        internal static extern int ScrollableGet(IntPtr quickpanel, out QuickPanelScrollability scrollable);

        [DllImport(Libraries.Quickpanel, EntryPoint = "tzsh_quickpanel_orientation_get")]
        internal static extern int OrientationGet(IntPtr quickpanel, out QuickpanelOrientation orientation);

        //typedef void(* tzsh_quickpanel_event_cb)(int type, tzsh_quickpanel_event_info_h event_info, void *user_data)
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool QuickpanelCallback(Int32 type, IntPtr eventInfo, IntPtr data);

        //tzsh_quickpanel_event_handler_h tzsh_quickpanel_event_handler_add (tzsh_quickpanel_h quickpanel, int type, tzsh_quickpanel_event_cb func, void *user_data)
        [DllImport(Libraries.Quickpanel, EntryPoint = "tzsh_quickpanel_event_handler_add")]
        internal static extern IntPtr AddEventHandler(IntPtr quickpanel, Int32 type, QuickpanelCallback func, IntPtr user_data);

        //int tzsh_quickpanel_event_handler_del (tzsh_quickpanel_h quickpanel, tzsh_quickpanel_event_handler_h event_handler);
        [DllImport(Libraries.Quickpanel, EntryPoint = "tzsh_quickpanel_event_handler_del")]
        internal static extern int DeleteEventHandler(IntPtr quickpanel, IntPtr eventHandler);

        //int tzsh_quickpanel_event_visible_get (tzsh_quickpanel_event_info_h event_info, tzsh_quickpanel_state_visible_e *visible);
        [DllImport(Libraries.Quickpanel, EntryPoint = "tzsh_quickpanel_event_visible_get")]
        internal static extern int EventInfoGetVisibility(IntPtr eventInfo, out QuickpanelVisibility visible);

        //int tzsh_quickpanel_event_orientation_get (tzsh_quickpanel_event_info_h event_info, tzsh_quickpanel_state_orientation_e *orientation);
        [DllImport(Libraries.Quickpanel, EntryPoint = "tzsh_quickpanel_event_orientation_get")]
        internal static extern int EventInfoGetOrientation(IntPtr eventInfo, out QuickpanelOrientation orientation);
    }
}
