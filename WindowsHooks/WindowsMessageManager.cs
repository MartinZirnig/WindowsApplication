using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using WindowsLowLevelStructs;

namespace WindowsHooks
{
    public class WindowsMessageManager : IDisposable
    {
        private const nint AnyWindowCode = 0;
        private const uint AnyMessageCode = 0;

        private const int MouseBegin = 0x0200;
        private const int MouseEnd = 0x020E;


        public static WindowsMessageManager Instance
        {
            get
            {
                if (_instance is null)
                    _instance = new WindowsMessageManager();
                return _instance;
            }
        }
        private static WindowsMessageManager? _instance;

        public static void Close() 
        {
            _instance?.Dispose();
        }


        public event Action<WinApiMessage>? OnMessage;

        private CancellationTokenSource _cancel;

        private WindowsMessageManager()
        {
            _cancel = new CancellationTokenSource();
            Task.Run(MessageLoop);
        }
        private void MessageLoop()
        {
            while (!_cancel.IsCancellationRequested
                && GetMessage(out WinApiMessage msg,
                AnyWindowCode, AnyMessageCode, AnyMessageCode))
            {
                TranslateMessage(ref msg);
                DispatchMessage(ref msg);
            }
        }

        public void Dispose()
        {
            _cancel.Cancel();
            _instance = null;
        }


        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool GetMessage(out WinApiMessage msg, nint window, uint wMsgFilterMin, uint wMsgFilterMax);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool TranslateMessage(ref WinApiMessage msg);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern nint DispatchMessage(ref WinApiMessage msg);
    }
}
