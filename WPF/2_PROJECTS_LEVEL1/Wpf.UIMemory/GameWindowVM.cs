using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf.UIMemory
{
    public class GameWindowVM
    {
        public int WindowIndex { get; set; }
        ~GameWindowVM()
        {
            Debug.WriteLine($"deconstruction {WindowIndex}", GetType().Name);
        }
    }
    
}
