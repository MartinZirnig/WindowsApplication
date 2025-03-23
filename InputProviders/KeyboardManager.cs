using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsHooks;

namespace BasicInputs
{
    public class KeyboardManager
    {
        private WindowsHook _hook;
        internal KeyboardManager(Action<HookEventArguments> procedure)
        {
            _hook = WindowsHookManager.OpenHook(WindowsHookType.Keyboard);
            _hook.HookProcedure = procedure;
        }






    }
}
