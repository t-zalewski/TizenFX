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

using ElmSharp;
using System;

namespace Tizen.WindowManager
{
    enum ShellType
    {
        Unknown = 0,
        EFL = 1
    }

    /// <summary>
    /// Shell class
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
