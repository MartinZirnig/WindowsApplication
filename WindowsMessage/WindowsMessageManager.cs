using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsMessage
{
    public class WindowsMessageManager
    {
        public static WindowsMessageManager Instance
        {
            get
            {
                if (_instance is null)
                    _instance = new WindowsMessageManager();
                return _instance;
            }
        }
        private static WindowsMessageManager? _instance;




        public Action<WindowsMessage>? OnMessage {  get; set; }
        private WindowsMessageManager()
        {

        }
                


    }
}
