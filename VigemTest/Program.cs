using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigemTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var rc = new RootController();
            rc.Run();

            Console.WriteLine("Program will be closed..");
            Console.ReadLine();
        }
    }
}
