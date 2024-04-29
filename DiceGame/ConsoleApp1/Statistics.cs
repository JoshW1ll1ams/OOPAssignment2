using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace ConsoleApp1
{
    internal class Statistics
    {
        string CurrentDirectory = Directory.GetCurrentDirectory();

        string RelativePath = "Stats.txt";

        // Mehod creates blank canvas for statistics if ones doesnt alreay exist 
        public void TryCreateStatisticsFile()
        {
            string FilePath = Path.Combine(CurrentDirectory, RelativePath);
            try
            {
                // Only create a new file if one doesnt exist
                if (!File.Exists(FilePath))
                {
                    using (StreamWriter streamWriter = new StreamWriter(FilePath))
                    {
                        streamWriter.WriteLine("Statistics");

                        streamWriter.WriteLine("Sevens Out HighScores: ");
                        streamWriter.WriteLine("Blank 0");
                        streamWriter.WriteLine("Blank 0");
                        streamWriter.WriteLine("Blank 0");

                        streamWriter.WriteLine("Three Or More HighScores: ");
                        streamWriter.WriteLine("Blank 0");
                        streamWriter.WriteLine("Blank 0");
                        streamWriter.WriteLine("Blank 0");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error with file creation: " + ex.Message);
            }
        }
        // Method that will be called when games end to check for potantial new highscore and alter the stat sheet if a highscore is gained
        public void TryAddHighScore(String name, int Score, String TypeOfGame)
        {
            string PotentialNewEntry = name + " " + Score;

            int TargetIndex = -1;

            string FilePath = Path.Combine(CurrentDirectory, RelativePath);
            try
            {
                using (StreamReader reader = new StreamReader(FilePath))
                {
                    for (int i = 0; !reader.EndOfStream; i++)
                    {
                        string CurrentLine = reader.ReadLine();
                        
                        if(TypeOfGame.Equals("SevensOut"))
                        {
                            if (i == 2)
                            {
                                if (GetScoreAtLine(CurrentLine) < Score)
                                {
                                    TargetIndex = i;
                                    break;
                                }
                            }
                            if (i == 3)
                            {
                                if (GetScoreAtLine(CurrentLine) < Score)
                                {
                                    TargetIndex = i;
                                    break;
                                }
                            }
                            if (i == 4)
                            {
                                if (GetScoreAtLine(CurrentLine) < Score)
                                {
                                    TargetIndex = i;
                                    break;
                                }
                            }
                        }
                        if (TypeOfGame.Equals("ThreeOrMore"))
                        {
                            if (i == 6)
                            {
                                if (GetScoreAtLine(CurrentLine) < Score)
                                {
                                    TargetIndex = i;
                                    break;
                                }
                            }
                            if (i == 7)
                            {
                                if (GetScoreAtLine(CurrentLine) < Score)
                                {
                                    TargetIndex = i;
                                    break;
                                }
                            }
                            if (i == 8)
                            {
                                if (GetScoreAtLine(CurrentLine) < Score)
                                {
                                    TargetIndex = i;
                                    break;
                                }
                            }
                        }
                    }
                }
                // if new tagrte index is found add it to list and move down past scores if neccessary
                if(TargetIndex != -1 ) 
                {
                    List<string> OldContent = new List<string>(File.ReadAllLines(FilePath));
                    
                    if (TargetIndex < OldContent.Count)
                    {
                        if(TargetIndex == 2)
                        {
                            OldContent[TargetIndex + 2] = OldContent[TargetIndex + 1];
                            OldContent[TargetIndex+ 1] = OldContent[TargetIndex];
                            OldContent[TargetIndex] = PotentialNewEntry;
                        }

                        if (TargetIndex == 3)
                        {
                            OldContent[TargetIndex + 1] = OldContent[TargetIndex];
                            OldContent[TargetIndex] = PotentialNewEntry;
                        }

                        if (TargetIndex == 4)
                        {
                            OldContent[TargetIndex] = PotentialNewEntry;
                        }

                        if (TargetIndex == 6)
                        {
                            OldContent[TargetIndex + 2] = OldContent[TargetIndex + 1];
                            OldContent[TargetIndex + 1] = OldContent[TargetIndex];
                            OldContent[TargetIndex] = PotentialNewEntry;
                        }

                        if (TargetIndex == 7)
                        {
                            OldContent[TargetIndex + 1] = OldContent[TargetIndex];
                            OldContent[TargetIndex] = PotentialNewEntry;
                        }

                        if (TargetIndex == 8)
                        {
                            OldContent[TargetIndex] = PotentialNewEntry;
                        }
                    }

                    using (StreamWriter streamWriter = new StreamWriter(FilePath))
                    {
                        for (int i = 0; i < OldContent.Count(); i++)
                        {
                            streamWriter.WriteLine(OldContent[i]);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot read file - : " + ex.Message);
            }

        }

        public void PrintStatistics()
        {
            string FilePath = Path.Combine(CurrentDirectory, RelativePath);

            try
            {
                using (StreamReader reader = new StreamReader(FilePath))
                {
                    for (int i = 0; !reader.EndOfStream; i++)
                    {
                        string CurrentLine = reader.ReadLine();
                        Console.WriteLine(CurrentLine); 
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot read file - : " + ex.Message);
            }
        }

        static int GetScoreAtLine(string Input)
        {
            string[] SplitStringArray = Input.Split(' ');

            int Score;

            if (int.TryParse(SplitStringArray[1], out Score))
            {
                return Score;
            }
            else
            {
                return -1;
            }
        }
    }
}
