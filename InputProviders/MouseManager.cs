using BasicInputs.Mouse.Cursor;
using BasicInputs.Mouse.Mouse;
using System.Runtime.InteropServices;
using WindowsHooks;
using WindowsLowLevelStructs;

namespace BasicInputs
{
    public class MouseManager
    {
        private WindowsHook _hook;
        internal MouseManager(Action<HookEventArguments> procedure)
        {
            _hook = WindowsHookManager.OpenHook(WindowsHookType.Mouse);
            _hook.HookProcedure = procedure;
        }



        private static MouseStateManager _stateManager;
        private static CursorManager _cursorManager;
        static MouseManager()
        {
            _cursorManager = new CursorManager();
            _stateManager = new MouseStateManager();
        }

        public static Point CursorPosition
        {
            get
            {
                return _stateManager.GetCursorPosition();
            }
            set
            {
                _stateManager.SetPosition(value);
            }
        }
        public static Rectangle Limitation
        {
            get
            {
                return _stateManager.GetCursorLimitation();
            }
            set
            {
                _stateManager.LimitCursor(value);
            }
        }
        public static bool CursorVisible
        {
            get
            {
                return _cursorManager.Visible;
            }
            set
            {
                _cursorManager.SetCursorVisibility(value);
            }
        }
        public static CursorInfo CursorData => _cursorManager.GetCursorInfo();

        public static void FreeCursor()
        {
            _stateManager.FreeCursor();
        }

        public static void Click()
        {
            _stateManager.Click();
        }
        public static void RightClick()
        {
            _stateManager.RightClick();
        }
        public static void Execute(SimulatedMouseEvent mouseEvent)
        {
            _stateManager.Execute(mouseEvent);
        }
        public static void SetCursor(CursorImage image)
        {
            _cursorManager.SetCursorImage(image);
        }
        public static bool IsButtonDown(MouseButtons key)
        {
            return _stateManager.IsButtonDown(key);
        }
    }
}
