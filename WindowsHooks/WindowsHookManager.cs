using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsHooks;

public static class WindowsHookManager
{
    internal delegate nint MouseInputProcedure(int nCode, nint wParam, nint lParam);

    private const int HookToAnyThreadCode = 0;

    public static WindowsHook OpenHook(int hookCode)
    {
        return OpenHook((WindowsHookType)hookCode);
    }
    public static WindowsHook OpenHook(WindowsHookType type)
    {
        var hook = new WindowsHook();
        hook.Type = type;

        ReopenHook(ref hook);
        return hook;
    }
    public static void ReopenHook(ref WindowsHook hook)
    {
        var thisProcess = Process.GetCurrentProcess();
        var module = thisProcess.MainModule
            ?? throw new Exception("Cannot load current module!");
        var moduleHandle = GetModuleHandle(module.ModuleName);

        var handle = SetWindowsHookEx((int)hook.Type, hook.CatchEvent, moduleHandle, HookToAnyThreadCode);
        hook.Handle = handle;
        hook.Activate();

        thisProcess.Dispose();
        module?.Dispose();
    }

    internal static void CloseHook(nint hook)
    {
        UnhookWindowsHookEx(hook);
    }
    internal static nint FinishHookEventHandling(nint handle, int code, nint wParam, nint lParam)
    {
        return CallNextHookEx(handle, code, wParam, lParam);
    }





    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern nint CallNextHookEx(nint handle, int code, nint wParam, nint lParam);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern nint SetWindowsHookEx(int hookType, MouseInputProcedure procedure, nint moduleHandle, uint threadId);


    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern nint GetModuleHandle(string moduleName);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool UnhookWindowsHookEx(nint handle);

}

