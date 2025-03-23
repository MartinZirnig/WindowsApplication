using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WindowsLowLevelStructs;

namespace UserInterfaceReporter
{
    internal class InputsMessenger : IDisposable
    {
        public bool Active { get; private set; }
        public readonly InputsResponder Responder 
            = new InputsResponder();

        private CancellationTokenSource _cancel;
        private bool _disposed;
        private BinaryReader? _reader;
        private BinaryWriter? _writer;
        private BinaryWriter? _error;

        public void Open()
        {
            Active = true;

            _reader = new BinaryReader(Console.OpenStandardOutput());
            _writer = new BinaryWriter(Console.OpenStandardInput());
            _error  = new BinaryWriter(Console.OpenStandardError());
            _cancel = new CancellationTokenSource();

            var t = Task.Run(ReceiveControlProcess);
        }

        public void SendEvent(WinApiMessage msg)
        {
            



            

        }

        private void ReceiveControlProcess()
        {
            while (!_cancel.IsCancellationRequested)
            {
                
            }    
        }


        public void Close()
        {
            _reader?.Dispose();
            _reader = null;

            _writer?.Dispose();
            _writer = null;

            _error?.Dispose();
            _error = null;

            _cancel.Cancel();

            Active = false;
        }

        public void Dispose()
        {
            if (_disposed) return;

            Close();
            _disposed = true;
        }
    }
}
