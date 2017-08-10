/** Copyright (c) 2017 Samsung Electronics Co., Ltd.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*
*/

namespace Tizen.NUI
{

    /// <summary>
    /// Rectangle class
    /// </summary>
    public class Rectangle : global::System.IDisposable
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        protected bool swigCMemOwn;

        internal Rectangle(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Rectangle obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        //A Flag to check who called Dispose(). (By User or DisposeQueue)
        private bool isDisposeQueued = false;
        //A Flat to check if it is already disposed.
        protected bool disposed = false;

        ~Rectangle()
        {
            if(!isDisposeQueued)
            {
                isDisposeQueued = true;
                DisposeQueue.Instance.Add(this);
            }
        }

        public void Dispose()
        {
            //Throw excpetion if Dispose() is called in separate thread.
            if (!Window.IsInstalled())
            {
                throw new System.InvalidOperationException("This API called from separate thread. This API must be called from MainThread.");
            }

            if (isDisposeQueued)
            {
                Dispose(DisposeTypes.Implicit);
            }
            else
            {
                Dispose(DisposeTypes.Explicit);
                System.GC.SuppressFinalize(this);
            }
        }

        protected virtual void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if(type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    NDalicPINVOKE.delete_Rectangle(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
            disposed = true;
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="a">First operand</param>
        /// <param name="b">Second operand</param>
        /// <returns>True if boxes are exactly same</returns>
        public static bool operator ==(Rectangle a, Rectangle b)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            // Return true if the fields match:
            return a.X == b.X && a.Y == b.Y && a.Width == b.Width && a.Height == b.Height;
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="a">The first rectangle</param>
        /// <param name="b">The second rectangle</param>
        /// <returns>True if rectangles are not identical</returns>
        public static bool operator !=(Rectangle a, Rectangle b)
        {
            return !(a == b);
        }

        /// <summary>
        /// X position of the rectangle
        /// </summary>
        public int X
        {
            set
            {
                x = ( value );
            }
            get
            {
                return x;
            }
            }

        /// <summary>
        /// Y position of the rectangle
        /// </summary>
        public int Y
        {
            set
            {
                y = ( value );
            }
            get
            {
                return y;
            }
        }

        /// <summary>
        /// Width of the rectangle
        /// </summary>
        public int Width
        {
            set
            {
                width = ( value );
            }
            get
            {
                return width;
            }
        }

        /// <summary>
        /// Height of the rectangle
        /// </summary>
        public int Height
        {
            set
            {
                height = ( value );
            }
            get
            {
                return height;
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public Rectangle() : this(NDalicPINVOKE.new_Rectangle__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="x">X coordinate (or left)</param>
        /// <param name="y">Y coordinate (or right)</param>
        /// <param name="width">Width (or bottom)</param>
        /// <param name="height">Height (or top)</param>
        public Rectangle(int x, int y, int width, int height) : this(NDalicPINVOKE.new_Rectangle__SWIG_1(x, y, width, height), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Assignment from individual values.
        /// </summary>
        /// <param name="newX">X coordinate</param>
        /// <param name="newY">Y coordinate</param>
        /// <param name="newWidth">Width</param>
        /// <param name="newHeight">Height</param>
        public void Set(int newX, int newY, int newWidth, int newHeight)
        {
            NDalicPINVOKE.Rectangle_Set(swigCPtr, newX, newY, newWidth, newHeight);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Determines whether or not this Rectangle is empty.
        /// </summary>
        /// <returns>True if width or height are zero</returns>
        public bool IsEmpty()
        {
            bool ret = NDalicPINVOKE.Rectangle_IsEmpty(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets the left of the rectangle.
        /// </summary>
        /// <returns>The left edge of the rectangle</returns>
        public int Left()
        {
            int ret = NDalicPINVOKE.Rectangle_Left(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets the right of the rectangle.
        /// </summary>
        /// <returns>The right edge of the rectangle</returns>
        public int Right()
        {
            int ret = NDalicPINVOKE.Rectangle_Right(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets the top of the rectangle.
        /// </summary>
        /// <returns>The top of the rectangle</returns>
        public int Top()
        {
            int ret = NDalicPINVOKE.Rectangle_Top(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets the bottom of the rectangle.
        /// </summary>
        /// <returns>The bottom of the rectangle</returns>
        public int Bottom()
        {
            int ret = NDalicPINVOKE.Rectangle_Bottom(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets the area of the rectangle.
        /// </summary>
        /// <returns>The area of the rectangle</returns>
        public int Area()
        {
            int ret = NDalicPINVOKE.Rectangle_Area(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Determines whether or not this rectangle and the specified rectangle intersect.
        /// </summary>
        /// <param name="other">The other rectangle to test against this rectangle</param>
        /// <returns>True if the rectangles intersect</returns>
        public bool Intersects(Rectangle other)
        {
            bool ret = NDalicPINVOKE.Rectangle_Intersects(swigCPtr, Rectangle.getCPtr(other));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Determines whether or not this Rectangle contains the specified rectangle.
        /// </summary>
        /// <param name="other">The other rectangle to test against this rectangle</param>
        /// <returns>True if the specified rectangle is contained</returns>
        public bool Contains(Rectangle other)
        {
            bool ret = NDalicPINVOKE.Rectangle_Contains(swigCPtr, Rectangle.getCPtr(other));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private int x
        {
            set
            {
                NDalicPINVOKE.Rectangle_x_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                int ret = NDalicPINVOKE.Rectangle_x_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private int left
        {
            set
            {
                NDalicPINVOKE.Rectangle_left_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                int ret = NDalicPINVOKE.Rectangle_left_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private int y
        {
            set
            {
                NDalicPINVOKE.Rectangle_y_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                int ret = NDalicPINVOKE.Rectangle_y_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private int right
        {
            set
            {
                NDalicPINVOKE.Rectangle_right_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                int ret = NDalicPINVOKE.Rectangle_right_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private int width
        {
            set
            {
                NDalicPINVOKE.Rectangle_width_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                int ret = NDalicPINVOKE.Rectangle_width_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private int bottom
        {
            set
            {
                NDalicPINVOKE.Rectangle_bottom_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                int ret = NDalicPINVOKE.Rectangle_bottom_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private int height
        {
            set
            {
                NDalicPINVOKE.Rectangle_height_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                int ret = NDalicPINVOKE.Rectangle_height_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private int top
        {
            set
            {
                NDalicPINVOKE.Rectangle_top_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                int ret = NDalicPINVOKE.Rectangle_top_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

    }

}