using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class SevensOut
    {
        //   Dice Games

        public void StartGame(bool TwoPlayer)
        {
           if(TwoPlayer)
            {
                StartTwoPlayerGame();
            }
           else
            {
                StartComputerGame();
            }
        }

        private void StartTwoPlayerGame()
        {
            int Player1Total = 0;
            int Player2Total = 0;
  
            bool Gameover = false;

            Console.WriteLine("Starting SevensOut Game, Player 1 vs Player 2, the first to 7 wins!");

            //Player 1 and two both set there names
            Console.WriteLine("Player 1 please enter your name: ");

            String Player1Name = GetUserNameInput();

            Console.WriteLine("Player 2 please enter your name: ");

            String Player2Name = GetUserNameInput();

            // Main game loop will run until game over is set to true
            while (!Gameover)
            {
                Console.WriteLine(Player1Name + ", press any button to roll!");
                Console.ReadLine();

                //Player 1 rolls and the result is added to there total
                int Player1Roll = RollTwoDie();

                Player1Total += Player1Roll;

                Console.WriteLine(Player1Name + ", you rolled "+ Player1Roll + ", your new total is "+ Player1Total);

                // Game is over if roll is 7
                if (Player1Roll == 7)
                {
                    Gameover = true;
                }
                // If player 1 didnt roll 7 player two takes there turn
                if(!Gameover)
                {
                    Console.WriteLine(Player2Name + ", press any button to roll!");
                    Console.ReadLine();

                    int Player2Roll = RollTwoDie();

                    Player2Total += Player2Roll;

                    Console.WriteLine(Player2Name + ", you rolled " + Player2Roll + ", your new total is " + Player2Total);

                    // Game is over if roll is 7
                    if (Player2Roll == 7)
                    {
                        Gameover = true;
                    }
                }
            }
            EndGame(Player1Total, Player2Total, Player1Name, Player2Name);  
        }

        private void StartComputerGame()
        {
            int Player1Total = 0;
            int ComputerTotal = 0;

            bool Gameover = false;

            Console.WriteLine("Starting SevensOut Game, Player 1 vs Computer, the first to 7 wins!");

            //Player 1 sets there name
            Console.WriteLine("Player 1 please enter your name: ");

            String Player1Name = GetUserNameInput();

   
            // Main game loop will run until game over is set to true
            while (!Gameover)
            {
                Console.WriteLine(Player1Name + ", press any button to roll!");
                Console.ReadLine();

                //Player 1 rolls and the result is added to there total
                int Player1Roll = RollTwoDie();

                Player1Total += Player1Roll;

                Console.WriteLine(Player1Name + ", you rolled " + Player1Roll + ", your new total is " + Player1Total);

                // Game is over if roll is 7
                if (Player1Roll == 7)
                {
                    Gameover = true;
                }
                // If player 1 didnt roll 7 the computer takes its turn
                if (!Gameover)
                {

                    int ComputerRoll = RollTwoDie();

                    ComputerTotal += ComputerRoll;

                    Console.WriteLine("The computer rolled "+ ComputerRoll + ", its new total is " + ComputerTotal);

                    // Game is over if roll is 7
                    if (ComputerRoll == 7)
                    {
                        Gameover = true;
                    }
                }
            }
            EndGame(Player1Total, ComputerTotal, Player1Name, "The computer");
        }

        private void EndGame(int Score1, int Score2, String Name1, String Name2)
        {
            if(Score1 > Score2) 
            {
                Console.WriteLine("GameOver! "+ Name1+ " wins with a score of " + Score1+ ", " + Name2+ " your score was "+ Score2);
            }
            else
            {
                Console.WriteLine("GameOver! " + Name2 + " wins with a score of " + Score2 + ", " + Name1 + " your score was " + Score1);
            }
        }

        private string GetUserNameInput()
        {
            string Input = "";

            while (Input.Length < 3 || Input.Length > 5)
            {
                Console.WriteLine("Please enter your name, must be a string between 3 and 5 characters:");
                Input = Console.ReadLine();

                if (Input.Length < 3 || Input.Length > 5)
                {
                    Console.WriteLine("Entry invalid. Try again.");
                }
            }

            return Input;
        }

        // Method rolls two die and returns the result
        private int RollTwoDie()
        {
            Die Die1 = new Die();
            Die Die2 = new Die();

            int DieRoll1 = Die1.Roll();
            int DieRoll2 = Die2.Roll();

            // If double return both numbers added and multiplied, if not return both numbers added
            if(DieRoll1 == DieRoll2)
            {
                Console.WriteLine(DieRoll1);
                Console.WriteLine("Die 1: "+ DieRoll1 + "\nDie 2: " + DieRoll2 + "\nThats double! Total: " + ((DieRoll1 + DieRoll2) * 2));
                return (DieRoll1 + DieRoll2)*2;
            }
            else
            {
                Console.WriteLine("Die 1: " + DieRoll1 + "\nDie 2: " + DieRoll2 + "\nTotal: " + (DieRoll1 + DieRoll2));
                return DieRoll1 + DieRoll2;
            }
           
        }


        //    Sevens Out
        //    2 x dice
        //Rules:
        //  Roll the two dice, noting the total rolled each time.

        //  If it is a 7 - stop.

        //  If it is any other number - add it to your total.

        // If it is a double -add double the total to your score(3,3 would add 12 to your total)

        // Play with partner(on the same computer), or against the computer.
    }
}
