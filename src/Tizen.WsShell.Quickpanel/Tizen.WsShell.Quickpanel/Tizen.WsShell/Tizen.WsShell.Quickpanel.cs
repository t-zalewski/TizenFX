using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Interop.Quickpanel;

namespace Tizen.WsShell
{
    /// <summary>
    /// 
    /// </summary>
    public enum QuickpanelOrientation : int
    {
        /// <summary>
        /// 
        /// </summary>
        OrientationUnknown,

        /// <summary>
        /// 
        /// </summary>
        Orientation0,

        /// <summary>
        /// 
        /// </summary>
        Orientation90,

        /// <summary>
        /// 
        /// </summary>
        Orientation180,

        /// <summary>
        /// 
        /// </summary>
        Orientation270,
    }

    /// <summary>
    /// 
    /// </summary>
    public class Quickpanel
    {
        private IntPtr _shellHandler;
        private IntPtr _qpHandler;
        private IntPtr _orientationEventHandler;
        private IntPtr _visibilityEventHandler;

        private QuickpanelVisibility _visibility;
        private QuickpanelOrientation _orientation;
        private QuickPanelScrollability _scrollability;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Quickpanel(ElmSharp.EvasObject parent)
        {
            _shellHandler = Interop.WsShell.Create(1);
            if (_shellHandler == null)
            {
                var err = Internals.Errors.ErrorFacts.GetLastResult();
                throw new Exception(Internals.Errors.ErrorFacts.GetErrorMessage(err)); // TODO: change Exception type
            }

            var windowId = Interop.WsShell.GetElmWindowId(parent);
            _qpHandler = Interop.Quickpanel.Create(_shellHandler, windowId);
            if (_qpHandler == null)
            {
                var err = Internals.Errors.ErrorFacts.GetLastResult();
                throw new Exception(Internals.Errors.ErrorFacts.GetErrorMessage(err)); //TODO: change Exception type
            }
        }

        private EventHandler<OrientationEventArgs> _orientationChanged;
        private EventHandler<VisibilityEventArgs> _visibilityChanged;
        private QuickpanelCallback _orientationChangedCallback;
        private QuickpanelCallback _visibilityChangedCallback;

        /// <summary>
        /// 
        /// </summary>
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
                if(_orientationChanged == null)
                {
                    UnregisterOrientationChangedEvent();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
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
        /// 
        /// </summary>
        public bool IsScrollable
        {
            get
            {
                var ret = ScrollableGet(_qpHandler, out _scrollability);
                if (ret != 0)
                {
                    throw new Exception(Internals.Errors.ErrorFacts.GetErrorMessage(ret));
                }
                return _scrollability == QuickPanelScrollability.Set;
            }
            set
            {
                var ret = ScrollableSet(_qpHandler, value);
                if (ret != 0)
                {
                    throw new Exception(Internals.Errors.ErrorFacts.GetErrorMessage(ret));
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsVisible
        {
            get
            {
                var ret = Interop.Quickpanel.VisibleGet(_qpHandler, out _visibility);
                if(ret != 0)
                {
                    throw new Exception(Internals.Errors.ErrorFacts.GetErrorMessage(ret));
                }
                return _visibility == QuickpanelVisibility.Shown;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public QuickpanelOrientation Orientation
        {
            get
            {
                var ret = OrientationGet(_qpHandler, out _orientation);
                if (ret != 0)
                {
                    throw new Exception(Internals.Errors.ErrorFacts.GetErrorMessage(ret));
                }
                return _orientation;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Show()
        {
            var ret = Interop.Quickpanel.Show(_qpHandler);
            if (ret != 0)
            {
                throw new Exception(Internals.Errors.ErrorFacts.GetErrorMessage(ret));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Hide()
        {
            var ret = Interop.Quickpanel.Hide(_qpHandler);
            if (ret != 0)
            {
                throw new Exception(Internals.Errors.ErrorFacts.GetErrorMessage(ret));
            }
        }

        private void RegisterOrientationChangedEvent()
        {
            _orientationChangedCallback = new QuickpanelCallback(NativeOrientationChanged);
            _orientationEventHandler = AddEventHandler(_qpHandler, 2, _orientationChangedCallback, IntPtr.Zero);       
        }

        private bool NativeOrientationChanged(int type, IntPtr eventInfo, IntPtr data)
        {
            var ret = EventInfoGetOrientation(eventInfo, out var orientation);
            if (ret == 0) //TODO: Internals.Errors.ErrorCode.None
            {
                _orientationChanged?.Invoke(this, new OrientationEventArgs(orientation));
            }
            else
            {
                Tizen.Log.Error("WsShell", $"Failed to get orientation from event info: {Internals.Errors.ErrorFacts.GetErrorMessage(ret)}");
            }

            return true;
        }

        private void UnregisterOrientationChangedEvent()
        {
            if(_orientationEventHandler != IntPtr.Zero)
            {
                var ret = DeleteEventHandler(_qpHandler, _orientationEventHandler);
                if(ret != 0)
                {
                    Tizen.Log.Error("WsShell", $"Failed to remove orientation event handler: {Internals.Errors.ErrorFacts.GetErrorMessage(ret)}");
                }
            }
        }
        private void RegisterVisibilityChangedEvent()
        {
            _visibilityChangedCallback = new QuickpanelCallback(NativeVisibilityChanged);
            _visibilityEventHandler = AddEventHandler(_qpHandler, 1, _visibilityChangedCallback, IntPtr.Zero);
        }

        private bool NativeVisibilityChanged(int type, IntPtr eventInfo, IntPtr data)
        {
            var ret = EventInfoGetVisibility(eventInfo, out var visibility);
            if (ret == 0) //TODO: Internals.Errors.ErrorCode.None
            {
                _visibilityChanged?.Invoke(this, new VisibilityEventArgs(visibility == QuickpanelVisibility.Shown));
            }
            else
            {
                Log.Error("WsShell", $"Failed to get orientation from event info: {Internals.Errors.ErrorFacts.GetErrorMessage(ret)}");
            }

            return true;
        }

        private void UnregisterVisibilityChangedEvent()
        {
            if (_visibilityEventHandler != IntPtr.Zero)
            {
                var ret = DeleteEventHandler(_qpHandler, _visibilityEventHandler);
                if (ret != 0)
                {
                    Log.Error("WsShell", $"Failed to remove visibility event handler: {Internals.Errors.ErrorFacts.GetErrorMessage(ret)}");
                }
            }
        }

    }
}
