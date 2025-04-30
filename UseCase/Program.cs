using WindowsApplication;
using WindowsApplication.Configuration;

namespace UseCase
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var builder = new ApplicationBuilder();
            var config = new ApplicationConfiguration()
            {
                InitializeApplicationInput = false,
                CatchKeyboard = false,
                CatchMouse = false,
                CloseStandardConsole = false,
            };

            builder.Build<App>(config);

            while (true) ;
        }
    }
}
