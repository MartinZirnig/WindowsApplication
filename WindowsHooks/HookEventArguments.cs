using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsHooks;
public struct HookEventArguments(int code, nint wParam, nint lParam)
{
    public int Code = code;
    public nint WParam = wParam;
    public nint LParam = lParam;
}

