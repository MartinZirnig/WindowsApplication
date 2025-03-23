using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StdExtensions;
    public unsafe class StringEditor : IDisposable
{
    private char* _content;
    private int _length;
    private bool _disposed;

    public StringEditor(string content)
    {
        _length = content.Length;
        fixed (char* cLikeString = content)
            _content = cLikeString;
    }

    [method: MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void EditOnPosition(int position, char value)
    {
        char* editedChar = _content + position;
        *editedChar = value;
    }

    public char this[int index]
    {
        get
        {
            ThrowWhenDisposed();
            ThrowWhenLengthExceeded(index);
            ThrowWhenNegative(index);

            return _content[index];
        }
        set
        {
            ThrowWhenDisposed();
            ThrowWhenLengthExceeded(index);
            ThrowWhenNegative(index);

            EditOnPosition(index, value);
        }
    }
    public string this[int index, int length]
    {
        get
        {
            ThrowWhenDisposed();
            ThrowWhenNegative(index);

            var upperIndex = index + length;
            ThrowWhenLengthExceeded(upperIndex);

            return new string(_content, index, length);
        }
        set
        {
            ThrowWhenDisposed();
            ThrowWhenNegative(index);
            ThrowWhenNegative(length);

            var upperIndex = index + length;
            ThrowWhenLengthExceeded(upperIndex);

            for (; index < upperIndex; index++)
                EditOnPosition(index, value[index]);
        }
    }



    private void ThrowWhenLengthExceeded(int index)
    {
        if (index >= _length)
            throw new IndexOutOfRangeException();
    }
    private void ThrowWhenNegative(int index)
    {
        if (index < 0)
            throw new IndexOutOfRangeException();
    }
    private void ThrowWhenDisposed() =>
        ObjectDisposedException.ThrowIf(_disposed, this);
    

    public unsafe void Dispose()
    {
        if (!_disposed)
        {
            _disposed = true;
            _content = null;
            _length = 0;
        }
    }
}

