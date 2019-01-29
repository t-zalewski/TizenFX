using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Tizen.WindowManager.Shell
{
    internal class SafeQuickpanelHandle : SafeHandle
    {
        internal SafeQuickpanelHandle() : base(IntPtr.Zero, true)
        {
        }

        internal SafeQuickpanelHandle(IntPtr existingHandle, bool ownHandle) : base(IntPtr.Zero, ownHandle)
        {
            SetHandle(existingHandle);
        }

        public override bool IsInvalid
        {
            get { return this.handle == IntPtr.Zero; }
        }

        protected override bool ReleaseHandle()
        {
            var ret = Interop.Quickpanel.Destroy(this.handle);
            if (ret != (int)QuickpanelError.None)
            {
                Tizen.Log.Error(Interop.Quickpanel.logTag, $"Failed to destroy object: {Internals.Errors.ErrorFacts.GetErrorMessage(ret)}");
            }
            this.SetHandle(IntPtr.Zero);
            return true;
        }
    }
}
