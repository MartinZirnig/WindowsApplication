using BasicInputs.DataObjects.Mouse;
using BasicInputs.Keyboard;
using BasicInputs.Mouse.Mouse;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsLowLevelStructs;

namespace BasicInputs.KeyBoard
{
    internal class SimulatedKeyboardEvent
    {
        private const int MouseEvent = 0;

        internal readonly KeyboardInput[] Input;

        private SimulatedKeyboardEvent(KeyboardInput[] input)
        {
            Input = input;
        }

        public static SimulatedKeyboardEvent Create(params KeyboardKey[] eventType)
        {
            var data = new RawKeyboardData[eventType.Length];

            for (int index = 0; index < eventType.Length; index++)
                data[index] = new RawKeyboardData
                {
                    KeyCode = (ushort)eventType[index],
                    HardwareKeyCode = default,
                    Flags = default,
                    Time = default,
                    ExtraInfo = nint.Zero,
                };

            return Create(data);
        }
        public static SimulatedKeyboardEvent Create(params RawKeyboardData[] data)
        {
            var result = new KeyboardInput[data.Length];

            for (int index = 0; index < data.Length; index++)
                result[index] = new KeyboardInput
                {
                    type = MouseEvent,
                    data = new KeyboardInputUnion()
                    {
                        Data = data[index]
                    }
                };

            return new SimulatedKeyboardEvent(result);
        }
    }
}
