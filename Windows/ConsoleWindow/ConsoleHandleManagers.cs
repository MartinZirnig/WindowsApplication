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
        public nint WindowHandle { get; private set; }
        public nint ConsoleHandle { get; private set; }

        public ConsoleHandleManagers(nint windowHandle)
        {
            WindowHandle = windowHandle;
            ConsoleHandle = GetConsoleHandle(windowHandle);
        }
        private nint GetConsoleHandle(nint windowHandle)
        {

            if (GetWindowThreadProcessId(windowHandle, out uint processId) == 0)
                throw new InvalidOperationException("Cannot open console handle");

            var result = OpenProcess((uint)ProcessAccess.PROCESS_ALL_ACCESS, false, processId);
            if (result == nint.Zero)
                throw new InvalidOperationException("Cannot open console handle");

            return result;
        }


        [DllImport("user32.dll", SetLastError = true)]
        private static extern nint FindWindow(string className, string windowName);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint GetWindowThreadProcessId(nint windowHandle, out uint processId);


        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern nint OpenProcess(uint acces, bool inheriteHandle, uint processId);


        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool CloseHandle(nint handle);

        public void Dispose()
        {
            CloseHandle(ConsoleHandle);
            ConsoleHandle = nint.Zero;
            WindowHandle = nint.Zero;
        }
    }
}
