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

namespace Tizen.WindowManager.Shell
{
    /// <summary>
    /// An extended EventArgs class contains the Orientation state
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class OrientationEventArgs : EventArgs
    {
        /// <summary>
        /// Current Quickpanel orientation state
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public QuickpanelOrientation Orientation { get; }

        internal OrientationEventArgs(QuickpanelOrientation orientation)
        {
            Orientation = orientation;
        }
    }

    /// <summary>
    /// An extended EventArgs class contains the Visibility state
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class VisibilityEventArgs : EventArgs
    {
        /// <summary>
        /// Indicates whether Quickpanel is currently visible or not
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public bool IsVisible { get; }

        internal VisibilityEventArgs(bool visibility)
        {
            IsVisible = visibility;
        }
    }
}