using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Game
    {
        Statistics CurrentStatisticsInstance;
        Testing CurrentTestingInstance;

        public Game()
        {
            // Create instance of Statistics and try create a file if ones doesnt already exist
            CurrentTestingInstance = new Testing();

            // Create instance of Statistics and try create a file if ones doesnt already exist
            CurrentStatisticsInstance = new Statistics();
            CurrentStatisticsInstance.TryCreateStatisticsFile();
        }

        public void PrintStatistics()
        {
            CurrentStatisticsInstance.PrintStatistics();
        }

        public void StartThreeOrMoreGameLoop(bool TwoPlayer)
        {
            ThreeOrMore threeOrMore = new ThreeOrMore();
            threeOrMore.StartGame(TwoPlayer);
        }

        public void StartSevensOutGameLoop(bool TwoPlayer)
        {
            SevensOut sevensOut = new SevensOut();
            sevensOut.StartGame(TwoPlayer);
        }

        public void EndGame(int Score1, int Score2, String Name1, String Name2)
        {
            if (Score1 > Score2)
            {
                Console.WriteLine("GameOver! " + Name1 + " wins with a score of " + Score1 + ", " + Name2 + " your score was " + Score2);
            }
            else
            {
                Console.WriteLine("GameOver! " + Name2 + " wins with a score of " + Score2 + ", " + Name1 + " your score was " + Score1);
            }
        }
        public void EndGame(int Score1, int Score2, String Name1)
        {
            if (Score1 > Score2)
            {
                Console.WriteLine("GameOver! " + Name1 + " wins with a score of " + Score1 + ", the computer got " + Score2);
            }
            else
            {
                Console.WriteLine("GameOver! the computer wins with a score of " + Score2 + ", " + Name1 + " your score was " + Score1);
            }
        }

        public string GetUserNameInput()
        {
            string Input = "";

            while (Input.Length < 3 || Input.Length > 5)
            {
                Console.WriteLine("Please enter your name, must be a string between 3 and 5 characters:");
                Input = Console.ReadLine();

                if (Input.Length < 3 || Input.Length > 5)
                {
                    Console.Clear();
                    Console.WriteLine("Entry invalid. Try again.");
                }
            }

            return Input;
        }

        public void PromptPlayerEnterName(string PlayerName)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine(PlayerName + " please enter your name: ");
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void PromptPlayerRoll(string PlayerName)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            if (PlayerName.Equals("Computer"))
            {
                Console.WriteLine("Press any button for the computer to take their turn...");
            }
            else
            {
                Console.WriteLine(PlayerName + ", press enter to roll!");
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public int TestSevensOut()
        {
            SevensOut sevensOut = new SevensOut();
            return sevensOut.TestGame();
        }
        public int TestThreeOrMore()
        {
            ThreeOrMore threeOrMore = new ThreeOrMore();
            return threeOrMore.TestGame();
        }

        protected interface GameInterface
        {
            void StartGame(bool TwoPlayer);
            void StartTwoPlayerGame(bool Testing);
            void StartComputerGame();
            int TestGame();
        }

        class ThreeOrMore : Game, GameInterface
        {

            public void StartGame(bool TwoPlayer)
            {
                if (TwoPlayer)
                {
                    StartTwoPlayerGame(false);
                }
                else
                {
                    StartComputerGame();
                }
            }


            // Test game will run the two player version of the game without any userinput, it will just display the rolls
            // The final highest player score will be logged to ensure it is 20 or greater
            int HighestPlayerScore = 0;

            public int TestGame()
            {
                StartTwoPlayerGame(true);

                return HighestPlayerScore;
            }

            public void StartTwoPlayerGame(bool Testing)
            {
                int Player1Total = 0;
                int Player2Total = 0;
                String Player1Name = "";
                String Player2Name = "";

                bool Gameover = false;

                if (!Testing)
                {
                    Console.WriteLine("Starting Three or more Game, Player 1 vs Player 2, the first to 20 or more wins!");

                    //Player 1 and two both set there names

                    PromptPlayerEnterName("Player 1");
                    Player1Name = GetUserNameInput();

                    Console.Clear();

                    PromptPlayerEnterName("Player 2");

                    Player2Name = GetUserNameInput();

                    Console.Clear();
                }
               

                // Main game loop will run until game over is set to true
                while (!Gameover)
                {
                    if(!Testing)
                    {
                        PromptPlayerRoll(Player1Name);

                        Console.ReadLine();

                        Console.Clear();
                    }

                    //Player 1 rolls and the result is added to there total
                    int Player1Roll = Roll5Die();

                 
                    // If player got any matches add the relevant score
                    if (Player1Roll != -1)
                    {
                        Player1Total += Player1Roll;
                        Console.WriteLine(Player1Name + " you get " + Player1Roll + " points, your new score is: " + Player1Total);
                    }
                    else
                    {
                        Console.WriteLine(Player1Name + " no matches for you! Your score is still: " + Player1Total);
                    }
                    


                    // Game is over if total is 20 or more
                    if (Player1Total >= 20)
                    {
                        Gameover = true;
                    }

                    // If player 1 total isnt 20 or more player 2 takes there turn
                    if (!Gameover)
                    {
                        if(!Testing)
                        {
                            PromptPlayerRoll(Player2Name);

                            Console.ReadLine();

                            Console.Clear();
                        }

                        int Player2Roll = Roll5Die();

            
                        // If player got any matches add the relevant score
                        if (Player2Roll != -1)
                        {
                            Player2Total += Player2Roll;

                            Console.WriteLine(Player2Name + " you get " + Player2Roll + " points, your new score is: " + Player2Total);
                        }
                        else
                        {

                            Console.WriteLine(Player2Name + " no matches for you! Your score is still: " + Player2Total);
                        }
                        


                        // Game is over if total is 20 or more
                        if (Player2Total >= 20)
                        {
                            Gameover = true;
                        }
                    }
                }
                if(!Testing)
                {
                    // Try add both high scores to stat list 
                    CurrentStatisticsInstance.TryAddHighScore(Player1Name, Player1Total, "ThreeOrMore");
                    CurrentStatisticsInstance.TryAddHighScore(Player2Name, Player2Total, "ThreeOrMore");

                    EndGame(Player1Total, Player2Total, Player1Name, Player2Name);

                    Console.WriteLine("Press enter to return to main menu...");
                    Console.ReadLine();
                    Program.menu.OpenMenu();
                }
                else
                {
                    if(Player1Total >= Player2Total)
                    {
                        HighestPlayerScore = Player1Total;
                    }
                    else
                    {
                        HighestPlayerScore = Player2Total;
                    }
                }
            }

            public void StartComputerGame()
            {
                Console.WriteLine("Starting Three or more Game, Player 1 vs Computer, the first to 20 or more wins!");

                int Player1Total = 0;
                int ComputerTotal = 0;

                bool Gameover = false;

                //Player 1 and two both set there names
                PromptPlayerEnterName("Player 1");

                String Player1Name = GetUserNameInput();

                Console.Clear();

                // Main game loop will run until game over is set to true
                while (!Gameover)
                {
                    PromptPlayerRoll(Player1Name);

                    Console.ReadLine();
                    Console.Clear();

                    //Player 1 rolls and the result is added to there total
                    int Player1Roll = Roll5Die();

                    // If player got any matches add the relevant score
                    if (Player1Roll != -1)
                    {
                        Player1Total += Player1Roll;
                        Console.WriteLine(Player1Name + " you get " + Player1Roll + " points, your new score is: " + Player1Total);
                    }
                    else
                    {
                        Console.WriteLine(Player1Name + " no matches for you! Your score is still: " + Player1Total);
                    }


                    // Game is over if total is 20 or more
                    if (Player1Total >= 20)
                    {
                        Gameover = true;
                    }

                    // If player 1 total isnt 20 or more player 2 takes there turn
                    if (!Gameover)
                    {
                        PromptPlayerRoll("Computer");

                        Console.ReadLine();
                        Console.Clear();

                        int ComputerRoll = Roll5Die();

                        // If player got any matches add the relevant score
                        if (ComputerRoll != -1)
                        {
                            ComputerTotal += ComputerRoll;
                            Console.WriteLine("The computer gets " + ComputerRoll + " points, computers new score is: " + ComputerTotal);
                        }
                        else
                        {
                            Console.WriteLine("Computer got no matches! It's score is still: " + ComputerTotal);
                        }

                        // Game is over if total is 20 or more
                        if (ComputerTotal >= 20)
                        {
                            Gameover = true;
                        }
                    }
                }
                // Try add player highscore to stat list
                CurrentStatisticsInstance.TryAddHighScore(Player1Name, Player1Total, "ThreeOrMore");
                EndGame(Player1Total, ComputerTotal, Player1Name);

                Console.WriteLine("Press enter to return to main menu...");
                Console.ReadLine();
                Program.menu.OpenMenu();
            }

            private int Roll5Die()
            {
                Die Die1 = new Die();
                Die Die2 = new Die();
                Die Die3 = new Die();
                Die Die4 = new Die();
                Die Die5 = new Die();

                int[] RollResultArray = { Die1.Roll(), Die2.Roll(), Die3.Roll(), Die4.Roll(), Die5.Roll() };

                int MatchesFound = 0;
                bool MatchingFound = false;

                for (int i = 0; i < RollResultArray.Length; i++)
                {
                    Console.WriteLine("Roll " + (i + 1) + " : " + RollResultArray[i]);
                    int TotalMatching = 0;

                    if (!MatchingFound)
                    {
                        for (int n = 0; n < RollResultArray.Length; n++)
                        {
                            if (RollResultArray[i] == RollResultArray[n])
                            {
                                TotalMatching++;
                            }
                        }
                        if (TotalMatching >= 3)
                        {
                            MatchesFound = TotalMatching;
                            MatchingFound = true;
                        }
                    }
                }

                Console.WriteLine("Three or more matching rolls found : " + MatchesFound);

                if (MatchesFound == 3)
                {
                    Console.WriteLine("You get 3 points!");
                    return 3;
                }
                if (MatchesFound == 4)
                {
                    Console.WriteLine("You get 6 points!");
                    return 6;
                }
                if (MatchesFound == 5)
                {
                    Console.WriteLine("You get 12 points!");
                    return 12;
                }

                return -1;
            }

        }

        class SevensOut : Game, GameInterface
        {
            public void StartGame(bool TwoPlayer)
            {
                if (TwoPlayer)
                {
                    StartTwoPlayerGame(false);
                }
                else
                {
                    StartComputerGame();
                }
            }

            // Test game will run the two player version of the game without any userinput, it will just display the rolls
            // The last player roll will be logged to esnure it is 7 for the correct ending of the game
            int LastPlayerRoll = 0;

            public int TestGame()
            {
                StartTwoPlayerGame(true);

                return LastPlayerRoll;
            }

            public void StartTwoPlayerGame(bool Testing)
            {
                int Player1Total = 0;
                int Player2Total = 0;
                String Player1Name = "";
                String Player2Name = "";
                bool Gameover = false;

                if (!Testing)
                {
                             
                    Console.WriteLine("Starting SevensOut Game, Player 1 vs Player 2, the first to 7 wins!");

                    //Player 1 and two both set there names
                    PromptPlayerEnterName("Player 1");

                    Player1Name = GetUserNameInput();

                    Console.Clear();

                    PromptPlayerEnterName("Player 2");

                    Player2Name = GetUserNameInput();

                    Console.Clear();
                }

                // Main game loop will run until game over is set to true
                while (!Gameover)
                {
                    if (!Testing)
                    {
                        PromptPlayerRoll(Player1Name);

                        Console.ReadLine();

                        Console.Clear();
                    }

                    //Player 1 rolls and the result is added to there total
                    int Player1Roll = RollTwoDie();

                    Player1Total += Player1Roll;

                    if (!Testing)
                    {
                        Console.WriteLine(Player1Name + ", you rolled " + Player1Roll + ", your new total is " + Player1Total);
                    }

                    // Game is over if roll is 7
                    if (Player1Roll == 7)
                    {
                        Gameover = true;
                    }
                    // If player 1 didnt roll 7 player two takes there turn
                    if (!Gameover)
                    {
                        if(!Testing)
                        {
                            PromptPlayerRoll(Player2Name);

                            Console.ReadLine();

                            Console.Clear();
                        }
                      

                        int Player2Roll = RollTwoDie();

                        Player2Total += Player2Roll;

                        if (!Testing)
                        {
                            Console.WriteLine(Player2Name + ", you rolled " + Player2Roll + ", your new total is " + Player2Total);
                        }

                        // Game is over if roll is 7
                        if (Player2Roll == 7)
                        {
                            Gameover = true;
                        }
                    }
                }
                if(!Testing)
                {
                    // Try add both high scores to stat list 
                    CurrentStatisticsInstance.TryAddHighScore(Player1Name, Player1Total, "SevensOut");
                    CurrentStatisticsInstance.TryAddHighScore(Player2Name, Player2Total, "SevensOut");

                    EndGame(Player1Total, Player2Total, Player1Name, Player2Name);

                    Console.WriteLine("Press enter to return to main menu...");
                    Console.ReadLine();
                    Program.menu.OpenMenu();
                }
            }

            public void StartComputerGame()
            {
                int Player1Total = 0;
                int ComputerTotal = 0;

                bool Gameover = false;

                Console.WriteLine("Starting SevensOut Game, Player 1 vs Computer, the first to 7 wins!");

                //Player 1 sets there name
                PromptPlayerEnterName("Player 1");

                String Player1Name = GetUserNameInput();

                Console.Clear();

                // Main game loop will run until game over is set to true
                while (!Gameover)
                {
                    PromptPlayerRoll(Player1Name);

                    Console.ReadLine();

                    Console.Clear();

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
                        PromptPlayerRoll("Computer");
                        Console.ReadLine();
                        Console.Clear();

                        int ComputerRoll = RollTwoDie();

                        ComputerTotal += ComputerRoll;

                        Console.WriteLine("The computer rolled " + ComputerRoll + ", its new total is " + ComputerTotal);

                        // Game is over if roll is 7
                        if (ComputerRoll == 7)
                        {
                            Gameover = true;
                        }
                    }
                }
                // Try add high score of player one 
                CurrentStatisticsInstance.TryAddHighScore(Player1Name, Player1Total, "SevensOut");

                EndGame(Player1Total, ComputerTotal, Player1Name);

                Console.WriteLine("Press enter to return to main menu...");
                Console.ReadLine();    
                Program.menu.OpenMenu();
            }

            // Method rolls two die and returns the result
            private int RollTwoDie()
            {
                Die Die1 = new Die();
                Die Die2 = new Die();

                int DieRoll1 = Die1.Roll();
                int DieRoll2 = Die2.Roll();

                // If double return both numbers added and multiplied, if not return both numbers added
                if (DieRoll1 == DieRoll2)
                {
                    Console.WriteLine("Die 1: " + DieRoll1 + "\nDie 2: " + DieRoll2 + "\nThats double! Total: " + ((DieRoll1 + DieRoll2) * 2));
                    LastPlayerRoll = (DieRoll1 + DieRoll2) * 2;
                    return (DieRoll1 + DieRoll2) * 2;
                }
                else
                {
                    Console.WriteLine("Die 1: " + DieRoll1 + "\nDie 2: " + DieRoll2 + "\nTotal: " + (DieRoll1 + DieRoll2));
                    LastPlayerRoll = DieRoll1 + DieRoll2;
                    return DieRoll1 + DieRoll2;
                }
            }
        }
    }
}
