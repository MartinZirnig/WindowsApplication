using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UserInputManagement.InputProviders;

namespace UserInterfaceReporter
{
    internal class RunManager : IDisposable
    {
        private InputsMessenger _messenger;
        private IncludedUserInputProvider _userInputProvider;

        

        public void Run()
        {

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
