using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicInputs.Mouse.Cursor;

public enum CursorTypes
{
    Arrow = 32512,        // Standard arrow
    Text = 32513,         // Text selection (I-beam)
    Wait = 32514,         // Hourglass / Waiting
    Cross = 32515,        // Crosshair
    UpArrow = 32516,      // Up arrow
    Size = 32640,         // Obsolete sizing cursor
    Icon = 32641,         // Obsolete icon cursor
    ResizeNWSE = 32642,   // Diagonal resize ↖↘
    ResizeNESW = 32643,   // Diagonal resize ↗↙
    ResizeWE = 32644,     // Horizontal resize ↔
    ResizeNS = 32645,     // Vertical resize ↕
    Move = 32646,         // Move cursor (all directions)
    No = 32648,          // No (circle with slash)
    Hand = 32649,        // Hand (link select)
    Loading = 32650,     // Arrow + hourglass (app starting)
    Help = 32651         // Question mark (help)
}
