using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows;

namespace WindowOutput
{
    public abstract class OutputManager
    {
        public List<Window> Window 
            = new List<Window>();

        protected void AttachToWindow(Window win)
        {

        }


    }
}
