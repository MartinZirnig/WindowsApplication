using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterfaceReporter
{
    internal class InputsResponder
    {
        private List<(byte[], Action)> _operations;
        private Action<byte[]>? _default;

        public InputsResponder()
        {
            _operations = new List<(byte[], Action)> ();
        }

        public void AddResponder(byte[] data, Action operation) =>
            _operations.Add((data, operation));
        public void SetDefault(Action<byte[]> action) =>
            _default = action;

        public void Invoke(byte[] data)
        {
            foreach (var action in _operations)
            {
                if (CompareBiteArrays(action.Item1, data))
                {
                    action.Item2();
                    return;
                }
            }
            _default?.Invoke(data);
        }
        public static bool CompareBiteArrays(byte[] left, byte[] right)
        {
            if (left.Length != right.Length)
                return false;

            for (int index = 0; index < left.Length; index++)
                if (left[index] != right[index])
                    return false;

            return true;
        }

    }
}
