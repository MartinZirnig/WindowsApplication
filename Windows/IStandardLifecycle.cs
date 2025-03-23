using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows
{
    internal interface IStandardLifecycle : IDisposable 
    {
        public void Open();
        public void Close();
    }
}
