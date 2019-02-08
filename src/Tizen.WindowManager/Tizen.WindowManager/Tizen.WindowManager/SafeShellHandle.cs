using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Tizen.WindowManager
{
    internal class SafeShellHandle : SafeHandle
    {
        internal SafeShellHandle() : base(IntPtr.Zero, true)
        {
        }

        internal SafeShellHandle(IntPtr existingHandle, bool ownsHandle) : base(IntPtr.Zero, ownsHandle)
        {
            SetHandle(existingHandle);
        }

        public override bool IsInvalid
        {
            get { return this.handle == IntPtr.Zero; }
        }

        protected override bool ReleaseHandle()
        {
            var ret = Interop.WindowManagerShell.Destroy(this.handle);
            if (ret != (int)QuickpanelError.None)
            {
                Tizen.Log.Error(Interop.Quickpanel.logTag, $"Failed to destroy object: {Internals.Errors.ErrorFacts.GetErrorMessage(ret)}");
            }
            this.SetHandle(IntPtr.Zero);
            return true;
        }
    }
}
