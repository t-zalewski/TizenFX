using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tizen.WsShell
{
    /// <summary>
    /// 
    /// </summary>
    public class Quickpanel
    {
        private IntPtr _shellHandler;
        private IntPtr _qpHandler;

        private Int32 _visibility;

        /// <summary>
        /// 
        /// </summary>
        public bool IsScrollable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsVisible
        {
            get
            {
                var res = Interop.Quickpanel.VisibleGet(_qpHandler, out _visibility);
                return Convert.ToBoolean(_visibility - 1);
            }
        }

        // public Orientation Orientation {get; private set;}

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
    }
}
