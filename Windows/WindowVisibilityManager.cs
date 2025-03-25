using Handles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Windows
{
    internal class WindowVisibilityManager
        (WindowHandle windowHandle)
    {
        private WindowHandle _handle = windowHandle;

        public void Hide() => ShowWindow(_handle.Value, (int)WindowVisibility.Hidden);
        public void Show() => ShowWindow(_handle.Value, (int)WindowVisibility.Visible);


        [DllImport("user32.dll")]
        private static extern bool ShowWindow(nint handle, int visibilityCode);

        private enum WindowVisibility
        {
            Hidden = 0,
            Visible = 5,
        }
    }
}
