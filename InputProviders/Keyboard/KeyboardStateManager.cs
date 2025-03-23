using BasicInputs.Keyboard;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BasicInputs.KeyBoard;

internal class KeyboardStateManager
{
    const uint KeyboardLayout_Active = 0x00000001;
    public bool IsKeyDown(KeyboardKey key)
    {
        return (GetAsyncKeyState((int)key) & 0x8000) != 0;
    }
    public bool IsAssociatedKeyDown(KeyboardKey key)
    {
        return (GetKeyState((int)key) & 0x8000) != 0;
    }
    
    public void SetLayout(string layout)
    {
        LoadKeyboardLayout(layout, KeyboardLayout_Active);
    }
    public nint GetLayoutHandle()
    {
        var handle = GetForegroundWindow();
        var threadId = GetWindowThreadProcessId(handle, out _);
        return GetLayoutHandle(threadId);
    }
    public nint GetLayoutHandle(uint threadId)
    {
        return GetKeyboardLayout(threadId);
    }
    public void Execute(SimulatedKeyboardEvent keyboardEvent)
    {
        SendInput((uint)keyboardEvent.Input.Length, 
            keyboardEvent.Input, Marshal.SizeOf(typeof(KeyboardInput)));
    }


    [DllImport("user32.dll", SetLastError = true)]
    public static extern uint SendInput(uint count, KeyboardInput[] inputs, int size);
    [DllImport("user32.dll")]
    public static extern nint GetForegroundWindow();
    [DllImport("user32.dll")]
    private static extern nint LoadKeyboardLayout(string layoutCode, uint flags);
    [DllImport("user32.dll")]
    public static extern uint GetWindowThreadProcessId(nint windowHandle, out uint processId);

    [DllImport("user32.dll")]
    private static extern short GetKeyState(int keyCode);
    [DllImport("user32.dll")]
    private static extern short GetAsyncKeyState(int keyCode);
    [DllImport("user32.dll")]
    public static extern nint GetKeyboardLayout(uint threadId);

}

