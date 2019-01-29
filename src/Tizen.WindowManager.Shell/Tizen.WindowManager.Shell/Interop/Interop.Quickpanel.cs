//Copyright 2018 Samsung Electronics Co., Ltd
//
//Licensed under the Apache License, Version 2.0 (the "License");
//you may not use this file except in compliance with the License.
//You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
//Unless required by applicable law or agreed to in writing, software
//distributed under the License is distributed on an "AS IS" BASIS,
//WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//See the License for the specific language governing permissions and
//limitations under the License.

using System;
using System.Runtime.InteropServices;
using Tizen.WindowManager.Shell;

internal static partial class Interop
{
    internal static partial class Quickpanel
    {
        public const string logTag = "Tizen.WsShell";

        [DllImport(Libraries.Quickpanel, EntryPoint = "tzsh_quickpanel_create")]
        internal static extern SafeQuickpanelHandle Create(SafeShellHandle tzsh, Int32 win);

        [DllImport(Libraries.Quickpanel, EntryPoint = "tzsh_quickpanel_destroy")]
        internal static extern int Destroy(IntPtr quickpanel);

        [DllImport(Libraries.Quickpanel, EntryPoint = "tzsh_quickpanel_show")]
        internal static extern int Show(SafeQuickpanelHandle quickpanel);

        [DllImport(Libraries.Quickpanel, EntryPoint = "tzsh_quickpanel_hide")]
        internal static extern int Hide(SafeQuickpanelHandle quickpanel);

        [DllImport(Libraries.Quickpanel, EntryPoint = "tzsh_quickpanel_visible_get")]
        internal static extern int VisibleGet(SafeQuickpanelHandle quickpanel, out QuickpanelVisibility visible);

        [DllImport(Libraries.Quickpanel, EntryPoint = "tzsh_quickpanel_scrollable_set")]
        internal static extern int ScrollableSet(SafeQuickpanelHandle quickpanel, bool scrollable);

        [DllImport(Libraries.Quickpanel, EntryPoint = "tzsh_quickpanel_scrollable_get")]
        internal static extern int ScrollableGet(SafeQuickpanelHandle quickpanel, out QuickPanelScrollability scrollable);

        [DllImport(Libraries.Quickpanel, EntryPoint = "tzsh_quickpanel_orientation_get")]
        internal static extern int OrientationGet(SafeQuickpanelHandle quickpanel, out QuickpanelOrientation orientation);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool QuickpanelCallback(Int32 type, IntPtr eventInfo, IntPtr data);

        [DllImport(Libraries.Quickpanel, EntryPoint = "tzsh_quickpanel_event_handler_add")]
        internal static extern IntPtr AddEventHandler(SafeQuickpanelHandle quickpanel, Int32 type, QuickpanelCallback func, IntPtr user_data);

        [DllImport(Libraries.Quickpanel, EntryPoint = "tzsh_quickpanel_event_handler_del")]
        internal static extern int DeleteEventHandler(SafeQuickpanelHandle quickpanel, IntPtr eventHandler);

        [DllImport(Libraries.Quickpanel, EntryPoint = "tzsh_quickpanel_event_visible_get")]
        internal static extern int EventInfoGetVisibility(IntPtr eventInfo, out QuickpanelVisibility visible);

        [DllImport(Libraries.Quickpanel, EntryPoint = "tzsh_quickpanel_event_orientation_get")]
        internal static extern int EventInfoGetOrientation(IntPtr eventInfo, out QuickpanelOrientation orientation);

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

    }
}
