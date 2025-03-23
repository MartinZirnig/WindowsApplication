using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Windows
{
    internal class WindowVisibilityManager
        (nint windowHandle)
    {
        private nint _windowHandle = windowHandle;

        public void Hide() => ShowWindow(_windowHandle, (int)WindowVisibility.Hidden);
        public void Show() => ShowWindow(_windowHandle, (int)WindowVisibility.Visible);


        [DllImport("user32.dll")]
        private static extern bool ShowWindow(nint handle, int visibilityCode);

        private enum WindowVisibility
        {
            Hidden = 0,
            Visible = 5,
        }
    }
}
