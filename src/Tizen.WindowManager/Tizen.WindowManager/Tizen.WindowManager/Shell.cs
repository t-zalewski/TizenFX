using ElmSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.WindowManager
{
    enum ShellType
    {
        Unknown = 0,
        EFL = 1
    }

    /// <summary>
    /// Class 
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class Shell : IDisposable
    {
        internal SafeShellHandle shellHandler;
        internal Int32 windowId;

        private bool _isDisposed;

        ///<summary>
        /// Initializes a new instance of the <see cref="Shell"/> class.
        /// </summary>
        /// <param name="parent">Parent EvasObject</param>
        /// <since_tizen> 6 </since_tizen>
        public Shell(EvasObject parent)
        {
            shellHandler = Interop.WindowManagerShell.Create((int)ShellType.EFL);

            if (shellHandler == null)
            {
                var err = Internals.Errors.ErrorFacts.GetLastResult();
                if (err != (int)QuickpanelError.None)
                {
                    throw QuickpanelErrorFactory.CheckAndThrowException(err, "Unable to create Quickpanel");
                }
            }

            windowId = Interop.WindowManagerShell.GetElmWindowId(parent);
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
        /// Destroy the Shell object
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        ~Shell()
        {
            Dispose(false);
        }

        /// <summary>
        /// Releases any unmanaged resources used by this object. Can also dispose any other disposable objects.
        /// </summary>
        /// <param name="disposing"></param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    if (shellHandler != null && !shellHandler.IsInvalid)
                        shellHandler.Dispose();
                }

                _isDisposed = true;
            }
        }
    }
}
