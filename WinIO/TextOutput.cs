using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Text;

namespace WinIO
{
    public abstract class TextOutput : TextWriter
    {
        public static readonly Encoding DefaultEncoding = Encoding.UTF8;


        public static readonly TextWriter Null;
        private readonly GeneralPrinter _printer;

        protected char[] CoreNewLine;

        protected TextWriter()
        {
            _printer = new ConsolePrinter();
            
        }
        
        protected TextWriter(IFormatProvider? formatProvider)
        {

        }

        public override Encoding Encoding { get; }

        public override IFormatProvider FormatProvider { get; }

        public override string NewLine { get; set; }


        public static TextWriter Synchronized(TextWriter writer)
        {

        }


        public override void Flush()
        {

        }

        public override Task FlushAsync()
        {

        }

        public override Task FlushAsync(CancellationToken cancellationToken)
        {

        }

        public override void Write(ulong value)
        {

        }

        public override void Write(uint value)
        {

        }

        public override void Write(StringBuilder? value)
        {

        }

        public override void Write(string format, params object?[] arg)
        {

        }

        public override void Write(string format, object? arg0, object? arg1, object? arg2)
        {

        }

        public override void Write(string format, object? arg0, object? arg1)
        {

        }

        public override void Write( string format, object? arg0)
        {

        }

        public override void Write(string? value)
        {

        }

        public override void Write(float value)
        {

        }

        public override void Write(long value)
        {

        }

        public override void Write(int value)
        {

        }

        public override void Write(double value)
        {

        }

        public override void Write(decimal value)
        {

        }

        public override void Write(char[] buffer, int index, int count)
        {

        }

        public override void Write(char[]? buffer)
        {

        }

        public override void Write(char value)
        {

        }

        public override void Write(bool value)
        {

        }

        public override void Write(ReadOnlySpan<char> buffer)
        {

        }

        public override void Write(object? value)
        {

        }

        public override Task WriteAsync(string? value)
        {

        }

        public override Task WriteAsync(StringBuilder? value, CancellationToken cancellationToken = default)
        {

        }

        public Task WriteAsync(char[]? buffer)
        {

        }

        public override Task WriteAsync(char value)
        {

        }

        public override Task WriteAsync(ReadOnlyMemory<char> buffer, CancellationToken cancellationToken = default)
        {

        }

        public override Task WriteAsync(char[] buffer, int index, int count)
        {

        }

        public override void WriteLine(char value)
        {

        }

        public override void WriteLine(ulong value)
        {

        }

        public override void WriteLine(uint value)
        {

        }

        public override void WriteLine(StringBuilder? value)
        {

        }

        public override void WriteLine(string format, params object?[] arg)
        {

        }

        public override void WriteLine(bool value)
        {

        }

        public override void WriteLine(string format, object? arg0, object? arg1)
        {

        }

        public override void WriteLine()
        {

        }

        public override void WriteLine(string? value)
        {

        }
)
        public override void WriteLine(string format, object? arg0, object? arg1, object? arg2)
        {

        }

        public override void WriteLine(float value)
        {

        }

        public override void WriteLine(char[]? buffer)
        {

        }

        public override void WriteLine(char[] buffer, int index, int count)
        {

        }

        public override void WriteLine(decimal value)
        {

        }

        public override void WriteLine(string format, object? arg0)
        {

        }

        public override void WriteLine(int value)
        {

        }

        public override void WriteLine(long value)
        {

        }

        public override void WriteLine(object? value)
        {

        }

        public override void WriteLine(double value)
        {

        }

        public override Task WriteLineAsync(char value)
        {

        }

        public Task WriteLineAsync(char[]? buffer)
        {

        }

        public override Task WriteLineAsync(char[] buffer, int index, int count)
        {

        }

        public override Task WriteLineAsync(ReadOnlyMemory<char> buffer, CancellationToken cancellationToken = default)
        {

        }

        public override Task WriteLineAsync(string? value)
        {

        }

        public override Task WriteLineAsync(StringBuilder? value, CancellationToken cancellationToken = default)
        {

        }

        public override Task WriteLineAsync()
        {

        }

        protected override void Dispose(bool disposing)
        {

        }



        public override void Close()
        {

        }
    }
}
