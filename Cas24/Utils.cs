using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cas24
{
    class Utils
    {
        public static string GetUserInput(string Message)
        {
            Console.Write("{0} > ", Message);
            return Console.ReadLine();
        }
    }
}
