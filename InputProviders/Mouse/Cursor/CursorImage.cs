using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BasicInputs.Mouse.Cursor
{
    public class CursorImage
    {
        internal readonly nint Value;

        private CursorImage(nint value)
        {
            Value = value;
        }

        public static CursorImage Load(CursorTypes type)
        {
            return Load(nint.Zero, (int)type);
        }
        public static CursorImage Load(string path)
        {
            var cursor = LoadCursorFromFile(path);
            return new CursorImage(cursor);
        }
        public static CursorImage Load(nint source, int identification)
        {
            var cursor = LoadCursor(source, identification);
            return new CursorImage(cursor);
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern nint LoadCursorFromFile(string filePath);
        [DllImport("user32.dll")]
        static extern nint LoadCursor(nint hInstance, int lpCursorName);

    }
}
