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
using Tizen.Internals.Errors;

namespace Tizen.WindowManager
{
    internal enum QuickpanelError
    {
        None = ErrorCode.None,
        InvalidParameter = ErrorCode.InvalidParameter,
        OutOfMemory = ErrorCode.OutOfMemory,
        PermissionDenied = ErrorCode.PermissionDenied,
        NoService = -0x02860000 | 0x01
    }

    internal static class QuickpanelErrorFactory
    {
        static internal Exception CheckAndThrowException(int error, string msg)
        {
            QuickpanelError e = (QuickpanelError)error;
            switch (e)
            {
                case QuickpanelError.None:
                    return null;
                case QuickpanelError.InvalidParameter:
                    return new ArgumentException("Invalid Parameter: " + msg);
                case QuickpanelError.OutOfMemory:
                    return new OutOfMemoryException("Out of Memory: " + msg);
                case QuickpanelError.PermissionDenied:
                    return new UnauthorizedAccessException("Permission Denied: " + msg);
                case QuickpanelError.NoService:
                    return new InvalidOperationException("No Service: " + msg);
                default:
                    return new InvalidOperationException("Unknown Error Code: " + msg);
            }
        }
    }
}
