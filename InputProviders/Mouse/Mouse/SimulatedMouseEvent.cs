using BasicInputs.DataObjects.Mouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsLowLevelStructs;

namespace BasicInputs.Mouse.Mouse
{
    public class SimulatedMouseEvent
    {
        private const int MouseEvent = 0;

        internal readonly MouseInput[] Input;

        private SimulatedMouseEvent(MouseInput[] input)
        {
            Input = input;
        }

        public static SimulatedMouseEvent Create(params MouseEventType[] eventType)
        {
            var data = new RawMouseData[eventType.Length];

            for (int index = 0; index < eventType.Length; index++)
                data[index] = new RawMouseData
                {
                    Position = default,
                    MouseData = 0,
                    Flags = (uint)eventType[index],
                    Time = 0,
                    ExtraInfo = nint.Zero,
                };

            return Create(data);
        }
        public static SimulatedMouseEvent Create(params RawMouseData[] data)
        {
            var result = new MouseInput[data.Length];

            for (int index = 0; index < data.Length; index++)
                result[index] = new MouseInput
                {
                    type = MouseEvent,
                    data = data[index]
                };

            return new SimulatedMouseEvent(result);
        }
    }
}
