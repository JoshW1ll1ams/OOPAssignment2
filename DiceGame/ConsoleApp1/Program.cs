﻿using System;
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

            SevensOut sevensOut = new SevensOut();

            sevensOut.StartGame(false);

            // Player can choose either game to play through a menu.
            // Play with partner(on the same computer), or against the computer.
            // Should be a console implementation - but scope for extending it to a GUI application should be possible.

            Console.ReadLine();

        }
    }
}
