using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krsasne_obdelnicky
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Application app = new Application();
            Console.WriteLine("Program začal");
            app.Start();


            Console.ReadLine();
        }
    }
}
