namespace ConsoleApp1
{
    internal class Menu
    {
        Game game;

        public Menu() 
        {
            game = new Game();
        }

        int CurrentMenuIndex = 0;

        public void OpenMenu()
        {
            OpenMainMenu(CurrentMenuIndex);
        }

        private void OpenMainMenu(int CurrentMenuIndex)
        {
            Console.Clear();
            PrintMainMenuHeader();

            string[] MenuOptions = { "Play SevensOut", "Play ThreeOrMore", "Statistics", "Testing", "Exit" };

            for (int i = 0; i < MenuOptions.Length; i++)
            {
                if (i == CurrentMenuIndex)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                Console.WriteLine(MenuOptions[i]);
            }

            Console.BackgroundColor = ConsoleColor.Black;

            PrintMenuFooter();

            ConsoleKeyInfo KeyInfo = Console.ReadKey();
            ConsoleKey CurrentKey = KeyInfo.Key;

            if (CurrentKey == ConsoleKey.UpArrow)
            {
                if(CurrentMenuIndex > 0) 
                {
                    CurrentMenuIndex--;
                }
                OpenMainMenu(CurrentMenuIndex);
            }
            else if (CurrentKey == ConsoleKey.DownArrow)
            {
                if (CurrentMenuIndex < 4)
                {
                    CurrentMenuIndex++;
                }
                OpenMainMenu(CurrentMenuIndex);
            }
            else if (CurrentKey == ConsoleKey.Enter)
            {
                SelectMenuOption(CurrentMenuIndex);
            }
            else
            {
                OpenMainMenu(CurrentMenuIndex);
            }

        }

        private void SelectMenuOption(int SelectedOption)
        {
            if(SelectedOption == 0) 
            {
                OpenSevensOutMenu(0);
            }
            if (SelectedOption == 1)
            {
                OpenThreeOrMoreMenu(0);
            }
            if (SelectedOption == 2)
            {
                StatisticsSelected();
            }
            if (SelectedOption == 3)
            {
                TestingSelected();
            }
            if (SelectedOption == 4)
            {
                Environment.Exit(0);
            }
        }

        private void OpenSevensOutMenu(int CurrentSevensOutIndex)
        {
            Console.Clear();
            PrintSevensOutMenuHeader();

            string[] SevensOutOptions = { "Play Single Player", "Play Multiplayer", "Return to Main Menu" };

            for (int i = 0; i < SevensOutOptions.Length; i++)
            {
                if (i == CurrentSevensOutIndex)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                Console.WriteLine(SevensOutOptions[i]);
            }

            Console.BackgroundColor = ConsoleColor.Black;

            PrintMenuFooter();

            ConsoleKeyInfo KeyInfo = Console.ReadKey();
            ConsoleKey CurrentKey = KeyInfo.Key;

            if (CurrentKey == ConsoleKey.UpArrow)
            {
                if (CurrentSevensOutIndex > 0)
                {
                    CurrentSevensOutIndex--;
                }
                OpenSevensOutMenu(CurrentSevensOutIndex);
            }
            else if (CurrentKey == ConsoleKey.DownArrow)
            {
                if (CurrentSevensOutIndex < 2)
                {
                    CurrentSevensOutIndex++;
                }
                OpenSevensOutMenu(CurrentSevensOutIndex);
            }
            else if (CurrentKey == ConsoleKey.Enter)
            {
                SelectSevensOutMenuOption(CurrentSevensOutIndex);
            }
            else
            {
                OpenSevensOutMenu(CurrentSevensOutIndex);
            }
        }

        private void SelectSevensOutMenuOption(int SelectedOption)
        {

            string[] SevensOutOptions = { "Play Single Player", "Play Multiplayer", "Return to Main Menu" };

            if (SelectedOption == 0) 
            {
                Console.Clear();
                game.StartSevensOutGameLoop(false);
            }
            if (SelectedOption == 1)
            {
                Console.Clear();
                game.StartSevensOutGameLoop(true);
            }
            if (SelectedOption == 2)
            {
                Console.Clear();
                OpenMainMenu(0);
            }
        }

        private void OpenThreeOrMoreMenu(int CurrentThreeOrMoreIndex)
        {
            Console.Clear();
            PrintThreeOrMoreMenuHeader();

            string[] ThreeOrMoreOptions = { "Play Single Player", "Play Multiplayer", "Return to Main Menu" };

            for (int i = 0; i < ThreeOrMoreOptions.Length; i++)
            {
                if (i == CurrentThreeOrMoreIndex)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                Console.WriteLine(ThreeOrMoreOptions[i]);
            }

            Console.BackgroundColor = ConsoleColor.Black;

            PrintMenuFooter();

            ConsoleKeyInfo KeyInfo = Console.ReadKey();
            ConsoleKey CurrentKey = KeyInfo.Key;

            if (CurrentKey == ConsoleKey.UpArrow)
            {
                if (CurrentThreeOrMoreIndex > 0)
                {
                    CurrentThreeOrMoreIndex--;
                }
                OpenThreeOrMoreMenu(CurrentThreeOrMoreIndex);
            }
            else if (CurrentKey == ConsoleKey.DownArrow)
            {
                if (CurrentThreeOrMoreIndex < 2)
                {
                    CurrentThreeOrMoreIndex++;
                }
                OpenThreeOrMoreMenu(CurrentThreeOrMoreIndex);
            }
            else if (CurrentKey == ConsoleKey.Enter)
            {
                SelectThreeOrMoreMenuOption(CurrentThreeOrMoreIndex);
            }
            else
            {
                OpenThreeOrMoreMenu(CurrentThreeOrMoreIndex);
            }
        }

        private void SelectThreeOrMoreMenuOption(int SelectedOption)
        {
            if (SelectedOption == 0)
            {
                Console.Clear();
                game.StartThreeOrMoreGameLoop(false);
            }
            if (SelectedOption == 1)
            {
                Console.Clear();
                game.StartThreeOrMoreGameLoop(true);
            }
            if (SelectedOption == 2)
            {
                Console.Clear();
                OpenMainMenu(0);
            }
        }

        private void StatisticsSelected()
        {
            Console.Clear();

            PrintStatisticsHeader();
            PrintStatistics();

            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Press enter to return to main menu...");
            Console.BackgroundColor = ConsoleColor.Black;

            ConsoleKeyInfo KeyInfo = Console.ReadKey();
            ConsoleKey CurrentKey = KeyInfo.Key;

            if (CurrentKey == ConsoleKey.Enter)
            {
                OpenMainMenu(0);
            }
            else
            {
                StatisticsSelected();
            }

        }
        private void TestingSelected()
        {
            Console.Clear();

            PrintTestingHeader();

            Testing testing = new Testing();

            Console.WriteLine("Press enter to test SevensOut...");
            Console.ReadLine();
            testing.TestSevensOut();


            Console.WriteLine("Press enter to test ThreeOrMore...");
            Console.ReadLine();
            testing.TestThreeOrMore();

            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Press enter to return to main menu...");
            Console.BackgroundColor = ConsoleColor.Black;

            ConsoleKeyInfo KeyInfo = Console.ReadKey();
            ConsoleKey CurrentKey = KeyInfo.Key;

            if (CurrentKey == ConsoleKey.Enter)
            {
                OpenMainMenu(0);
            }
            else
            {
                StatisticsSelected();
            }
        }

        private void PrintStatistics()
        {
            game.PrintStatistics();
        }

        private void PrintTestingHeader()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("-----------------------------------------");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("----------------Testing---------------");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("-----------------------------------------");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\n");
            Console.WriteLine("\n");

        }

        private void PrintStatisticsHeader()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("-----------------------------------------");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("----------------Statistics---------------");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("-----------------------------------------");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\n");
            Console.WriteLine("\n");

        }

        private void PrintSevensOutMenuHeader()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("-----------------------------------------");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("----------------SevensOut----------------");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("-----------------------------------------");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\n");
            Console.WriteLine("\n");
        }

        private void PrintThreeOrMoreMenuHeader()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("-----------------------------------------");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("---------------ThreeOrMore---------------");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("-----------------------------------------");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\n");
            Console.WriteLine("\n");

        }
        private void PrintMainMenuHeader()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("-----------------------------------------");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("----- Play SevensOut or ThreeOrMore -----");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("-----------------------------------------");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\n");
            Console.WriteLine("\n");
        }
        private void PrintMenuFooter()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Press up and down arrow keys to navigate.");
            Console.WriteLine("Press enter to make a selection");
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
