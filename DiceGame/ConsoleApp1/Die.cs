using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Die
    {
        // Current value variable will hold the result of the Roll method, It is public so we can access it outside of the class
        public int CurrentValue = 0;

        // We create an instance of the random class so we can use the Next method for our random die roll value
        private static Random random = new Random();

        // Roll method called by the Game class on each instance of Die object it creates
        public int Roll()
        {
            // Set current value to a random integer between 1 and 6
            CurrentValue = random.Next(1, 7);

            // Return the current value variable
            return CurrentValue;
        }
    }

}

