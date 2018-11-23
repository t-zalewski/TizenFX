using System;

namespace Tizen.WsShell
{
    /// <summary>
    /// 
    /// </summary>
    public class OrientationEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public QuickpanelOrientation Orientation { get;}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orientation"></param>
        public OrientationEventArgs(QuickpanelOrientation orientation)
        {
            Orientation = orientation;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class VisibilityEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public bool IsVisible { get;}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="visibility"></param>
        public VisibilityEventArgs(bool visibility)
        {
            IsVisible = visibility;
        }
    }
}