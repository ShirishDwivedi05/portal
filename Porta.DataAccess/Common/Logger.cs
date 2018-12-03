namespace Porta.DataAccess.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Logger
    {
        public static void Log(string message)
        {
            Console.WriteLine("EF Message: {0} ", message);
        }
    }
}
