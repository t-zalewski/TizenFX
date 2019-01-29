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
    internal static partial class WindowManagerShell
    {
        [DllImport(Libraries.Quickpanel, EntryPoint = "tzsh_create")]
        internal static extern SafeShellHandle Create(Int32 type);

        [DllImport(Libraries.Quickpanel, EntryPoint = "tzsh_destroy")]
        internal static extern int Destroy(IntPtr tzsh);

        [DllImport(Libraries.Elementary, EntryPoint = "elm_win_window_id_get")]
        internal static extern int GetElmWindowId(IntPtr win);
    }
}

