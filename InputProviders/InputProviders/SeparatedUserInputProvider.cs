using BasicInputs.DataObjects;
using BasicInputs.DataObjects.Mouse;
using System.ComponentModel;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BasicInputs.InputProviders;

public class SeparatedUserInputProvider : IUserInputProvider
{
    public const byte ExpectedMessageLengthInBytes = 4; // integer for enum compatibility

    public event Action<MouseButtonEventData>? MouseButtonActions;
    public event Action<MouseMoveEventData>? MouseMoveActions;
    public Action? FailProcedure;

    public bool Ready { get; private set; }

    private bool _disposed;
    private Process? _process;
    private BinaryWriter? _writer;
    private BinaryReader? _reader;
    private BinaryReader? _error;
    private CancellationTokenSource? _cancel;
    private static readonly byte[] _delimiter = BitConverter.GetBytes((int)SpCommand.TransmissionDelimiter);

    private bool _listening => !_cancel?.IsCancellationRequested ?? false;

    public void Close()
    {
        if (!Ready) return;

        Ready = false;
        SendCommand(SpCommand.ShutDown);

        _writer?.Dispose();
        _reader?.Dispose();
        _error?.Dispose();

        _writer = null;
        _reader = null;
        _error = null;

        _cancel?.Dispose();
        _cancel = null;

        _process?.Dispose();
        _process = null;

        _cancel?.Cancel();
    }
    private void CatchMouseMove(MouseMoveEventData data)
    {
        MouseButtonActions?.Invoke(new MouseButtonEventData());
    }
    private void CatchMouseAction(MouseButtonEventData data)
    {
        MouseButtonActions?.Invoke(data);
    }
    private void CatchKeyboardAction()
    {
        throw new NotImplementedException();
    }

    private void InfoCatchingLoop()
    {
        while (_listening)
        {
            var response = _reader?.ReadBytes(ExpectedMessageLengthInBytes);
            if (TestResponseAndProcessFail(response)) return;

            var objectType = BitConverter.ToInt32(response!, 0);
            var data = _reader!.ReadString();
            Task.Run(() => HandleReceivedObject(objectType, data));
        }
    }
    private void HandleReceivedObject(int typeIdentifikator, string data)
    {
        switch (typeIdentifikator)
        {
            case MouseButtonEventData.TypeIdentifikator:
                var buttonObject = JsonSerializer.Deserialize<MouseButtonEventData>(data);
                CatchMouseAction(buttonObject);
                break;
            case MouseMoveEventData.TypeIdentifikator:
                var moveObject = JsonSerializer.Deserialize<MouseMoveEventData>(data);
                CatchMouseMove(moveObject);
                break;
        }
    }

    private void ErrorCatchingLoop()
    {
        while (_listening)
        {
            var error = _error?.ReadBytes(ExpectedMessageLengthInBytes);
            if (TestResponseAndProcessFail(error)) return;

            var errorCode = BitConverter.ToInt32(error!, 0);

            Task.Run(() => HandleReceivedError((SPErrorType)errorCode));
        }
    }
    private void HandleReceivedError(SPErrorType error)
    {
        switch (error)
        {
            case SPErrorType.Insignificant:
                break;
            case SPErrorType.Significant:
                SendCommand(SpCommand.Reset);
                break;
            case SPErrorType.Critical:
                Failed();
                break;
        }
    }

    private bool TestResponseAndProcessFail(byte[]? response)
    {
        if (response is null ||
            response.Length != ExpectedMessageLengthInBytes)
        {
            Failed();
            return false;
        }
        return true;
    }

    private void SendCommand(SpCommand info)
    {
        var data = BitConverter.GetBytes((int)info);
        _writer?.Write(data);
        _writer?.Write(_delimiter);
        _writer?.Flush();
    }

    public void Dispose()
    {
        if (_disposed) return;

        MouseButtonActions = null;
        MouseMoveActions = null;

        _disposed = true;
    }

    public void Open()
    {
        Ready = true;

        var info = new ProcessStartInfo()
        {
            FileName = "UserInterfaceReporter.exe",
            UseShellExecute = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            RedirectStandardInput = true
        };

        _process = new Process();
        _process.StartInfo = info;
        if (!_process.Start())
        {
            Failed();
            return;
        }

        _error = new BinaryReader(_process.StandardError.BaseStream);
        _reader = new BinaryReader(_process.StandardOutput.BaseStream);
        _writer = new BinaryWriter(_process.StandardInput.BaseStream);

        _cancel = new CancellationTokenSource();

        Task.Run(ErrorCatchingLoop);
        Task.Run(InfoCatchingLoop);
    }
    private void Failed()
    {
        Close();
        FailProcedure?.Invoke();
    }
}