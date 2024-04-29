using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        public static Menu menu { get; set; }

        static void Main(string[] args)
        {
            menu = new Menu();
            menu.OpenMenu();

            Console.ReadLine();

        }
    }
}
