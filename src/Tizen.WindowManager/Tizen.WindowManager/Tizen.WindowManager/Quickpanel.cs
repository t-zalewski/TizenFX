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
using static Interop.Quickpanel;

namespace Tizen.WindowManager
{
    /// <summary>
    /// Class used to control the Quickpanel
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class Quickpanel : IDisposable
    {
        private SafeQuickpanelHandle _qpHandler;
        private Shell _shell;
        private IntPtr _orientationEventHandler;
        private IntPtr _visibilityEventHandler;

        private QuickpanelVisibility _visibility;
        private QuickpanelOrientation _orientation;
        private QuickPanelScrollability _scrollable;

        private EventHandler<OrientationEventArgs> _orientationChanged;
        private EventHandler<VisibilityEventArgs> _visibilityChanged;
        private QuickpanelCallback _orientationChangedCallback;
        private QuickpanelCallback _visibilityChangedCallback;

        private bool _isDisposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="Quickpanel"/> class.
        /// </summary>
        /// <param name="shell">Shell for the Quickpanel</param>
        /// <since_tizen> 6 </since_tizen>
        public Quickpanel(Shell shell)
        {
            _shell = shell;
            _qpHandler = Interop.Quickpanel.Create(_shell.shellHandler, _shell.windowId);

            if (_qpHandler == null)
            {
                var err = Internals.Errors.ErrorFacts.GetLastResult();
                if (err != (int)QuickpanelError.None)
                {
                    throw QuickpanelErrorFactory.CheckAndThrowException(err, "Unable to create Quickpanel");
                }
            }
        }

        /// <summary>
        /// Destroy the Quickpanel object
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        ~Quickpanel()
        {
            Dispose(false);
        }

        /// <summary>
        /// Event raised when orientation of the Quickpanel changed
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<OrientationEventArgs> OrientationChanged
        {
            add
            {
                if (_orientationChanged == null)
                {
                    RegisterOrientationChangedEvent();
                }

                _orientationChanged += value;
            }

            remove
            {
                _orientationChanged -= value;
                if (_orientationChanged == null)
                {
                    UnregisterOrientationChangedEvent();
                }
            }
        }

        /// <summary>
        /// Event fired up when visibility state of the Quickpanel changed
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<VisibilityEventArgs> VisibilityChanged
        {
            add
            {
                if (_visibilityChanged == null)
                {
                    RegisterVisibilityChangedEvent();
                }

                _visibilityChanged += value;
            }

            remove
            {
                _visibilityChanged -= value;
                if (_visibilityChanged == null)
                {
                    UnregisterVisibilityChangedEvent();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether Quickpanel is Scrollable or not
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public bool IsScrollable
        {
            get
            {
                var ret = Interop.Quickpanel.ScrollableGet(_qpHandler, out _scrollable);
                if (ret != (int)QuickpanelError.None)
                {
                    throw QuickpanelErrorFactory.CheckAndThrowException(ret, "Unable to get Quickpanel scrollable state");
                }

                return _scrollable == QuickPanelScrollability.Set;
            }

            set
            {
                var ret = Interop.Quickpanel.ScrollableSet(_qpHandler, value);
                if (ret != (int)QuickpanelError.None)
                {
                    throw QuickpanelErrorFactory.CheckAndThrowException(ret, "Unable to set Quickpanel scrollable state");
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether Quickpanel is Visible or not
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public bool IsVisible
        {
            get
            {
                var ret = Interop.Quickpanel.VisibleGet(_qpHandler, out _visibility);
                if (ret != (int)QuickpanelError.None)
                {
                    throw QuickpanelErrorFactory.CheckAndThrowException(ret, "Unable to get Quickpanel visibility");
                }

                return _visibility == QuickpanelVisibility.Shown;
            }
        }

        /// <summary>
        /// Gets orientation of the Quickpanel
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public QuickpanelOrientation Orientation
        {
            get
            {
                var ret = Interop.Quickpanel.OrientationGet(_qpHandler, out _orientation);
                if (ret != (int)QuickpanelError.None)
                {
                    throw QuickpanelErrorFactory.CheckAndThrowException(ret, "Unable to get Quickpanel orientation");
                }

                return _orientation;
            }
        }

        /// <summary>
        /// Shows Quickpanel on the screen
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void Show()
        {
            var ret = Interop.Quickpanel.Show(_qpHandler);
            if (ret != (int)QuickpanelError.None)
            {
                throw QuickpanelErrorFactory.CheckAndThrowException(ret, "Unable to show Quickpanel");
            }
        }

        /// <summary>
        /// Hide Quickpanel from the screen
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void Hide()
        {
            var ret = Interop.Quickpanel.Hide(_qpHandler);
            if (ret != (int)QuickpanelError.None)
            {
                throw QuickpanelErrorFactory.CheckAndThrowException(ret, "Unable to hide Quickpanel");
            }
        }

        /// <summary>
        /// Releases any unmanaged resources used by this object.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases any unmanaged resources used by this object. Can also dispose any other disposable objects.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    UnregisterOrientationChangedEvent();
                    UnregisterVisibilityChangedEvent();

                    if (_qpHandler != null && !_qpHandler.IsInvalid)
                        _qpHandler.Dispose();
                }

                _isDisposed = true;
            }
        }

        private void RegisterOrientationChangedEvent()
        {
            _orientationChangedCallback = new QuickpanelCallback(NativeOrientationChanged);
            _orientationEventHandler = AddEventHandler(_qpHandler, (int)EventType.Orientation, _orientationChangedCallback, IntPtr.Zero);
        }

        private bool NativeOrientationChanged(int type, IntPtr eventInfo, IntPtr data)
        {
            var ret = EventInfoGetOrientation(eventInfo, out var orientation);      
            if (ret == (int)QuickpanelError.None)
            {
                _orientationChanged?.Invoke(this, new OrientationEventArgs(orientation));
            }
            else
            {
                Tizen.Log.Error(logTag, $"Failed to get orientation from event info: {Internals.Errors.ErrorFacts.GetErrorMessage(ret)}");
            }

            return true;
        }

        private void UnregisterOrientationChangedEvent()
        {
            if (_orientationEventHandler != IntPtr.Zero)
            {
                var ret = DeleteEventHandler(_qpHandler, _orientationEventHandler);
                if (ret != (int)QuickpanelError.None)
                {
                    Tizen.Log.Error(logTag, $"Failed to remove orientation event handler: {Internals.Errors.ErrorFacts.GetErrorMessage(ret)}");
                }
            }
        }

        private void RegisterVisibilityChangedEvent()
        {
            _visibilityChangedCallback = new QuickpanelCallback(NativeVisibilityChanged);
            _visibilityEventHandler = AddEventHandler(_qpHandler, (int)EventType.Visible, _visibilityChangedCallback, IntPtr.Zero);
        }

        private bool NativeVisibilityChanged(int type, IntPtr eventInfo, IntPtr data)
        {
            var ret = EventInfoGetVisibility(eventInfo, out var visibility);
            if (ret == (int)QuickpanelError.None)
            {
                _visibilityChanged?.Invoke(this, new VisibilityEventArgs(visibility == QuickpanelVisibility.Shown));
            }
            else
            {
                Log.Error(logTag, $"Failed to get orientation from event info: {Internals.Errors.ErrorFacts.GetErrorMessage(ret)}");
            }

            return true;
        }

        private void UnregisterVisibilityChangedEvent()
        {
            if (_visibilityEventHandler != IntPtr.Zero)
            {
                var ret = DeleteEventHandler(_qpHandler, _visibilityEventHandler);
                if (ret != (int)QuickpanelError.None)
                {
                    Log.Error(logTag, $"Failed to remove visibility event handler: {Internals.Errors.ErrorFacts.GetErrorMessage(ret)}");
                }
            }
        }
    }

    /// <summary>
    /// Enumeration for Quickpanel orientation
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public enum QuickpanelOrientation : int
    {
        /// <summary>
        /// Value for unknown orientation
        /// </summary>
        OrientationUnknown,

        /// <summary>
        /// Value for 0 degrees orientation
        /// </summary>
        Orientation0,

        /// <summary>
        /// Value for 90 degrees orientation
        /// </summary>
        Orientation90,

        /// <summary>
        /// Value for 180 degrees orientation
        /// </summary>
        Orientation180,

        /// <summary>
        /// Value for 270 degrees orientation
        /// </summary>
        Orientation270,
    }

    internal enum EventType : int
    {
        Visible = 1,
        Orientation = 2
    }

}
