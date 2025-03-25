using Handles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Windows.ConsoleWindow
{
    internal class ConsoleHandleManagers : IDisposable
    {
        public WindowHandle WindowHandle { get; private set; }
        public Handle ConsoleHandle { get; private set; }

        public ConsoleHandleManagers(WindowHandle windowHandle)
        {
            WindowHandle = windowHandle;
            ConsoleHandle = GetConsoleHandle(windowHandle);
        }
        private Handle GetConsoleHandle(WindowHandle windowHandle)
        {

            if (GetWindowThreadProcessId(windowHandle.Value, out uint processId) == 0)
                throw new InvalidOperationException("Cannot open console handle");

            var result = OpenProcess((uint)ProcessAccess.PROCESS_ALL_ACCESS, false, processId);
            if (result == nint.Zero)
                throw new InvalidOperationException("Cannot open console handle");

            return new Handle(result);
        }


        [DllImport("user32.dll", SetLastError = true)]
        private static extern nint FindWindow(string className, string windowName);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint GetWindowThreadProcessId(nint windowHandle, out uint processId);


        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern nint OpenProcess(uint acces, bool inheriteHandle, uint processId);



        public void Dispose()
        {
            WindowHandle.Close();
            ConsoleHandle.Close();
        }
    }
}
