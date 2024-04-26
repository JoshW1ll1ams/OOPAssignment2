using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Die Die1 = new Die();
   
            Console.WriteLine(Die1.Roll());
        }
    }
}
