using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Testing
    {
        public void TestSevensOut()
        {
            Game game = new Game();

            Console.WriteLine("Testing TestSevensOut...");

            int SevensOutResult = game.TestSevensOut();

            Debug.Assert(SevensOutResult == 7, "ERROR SevensOutResult was not 7 invalid game exit");

            Console.WriteLine("Sevens out final return value: " + SevensOutResult);
        }

        public void TestThreeOrMore()
        {
            Game game = new Game();

            Console.WriteLine("Testing TestSevensOut...");

            int ThreeOrMoreResult = game.TestThreeOrMore();

            Debug.Assert(ThreeOrMoreResult >= 20, "ERROR ThreeOrMoreResult was not greater or equal to 20 invalid game exit");

            Console.WriteLine("ThreeOrMore final return value: " + ThreeOrMoreResult);
        }
    }
}
