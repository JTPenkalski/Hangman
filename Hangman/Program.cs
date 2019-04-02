using System;
using System.Collections;

namespace Hangman
{
    class Program
    {

        //Class Variables
        static ArrayList wordList;
        static ArrayList guessStatus;
        static String chosenWord;
        static int turns;
        static bool continueApp = true;

        //Main Method
        static void Main(string[] args)
        {
            //Set Title
            Console.Title = "Hangman Console Game";

            //Main App
            while (continueApp)
            {
                //Direction Set 1
                int command;
                Console.WriteLine("Enter a command:");
                Console.WriteLine("1) Play");
                Console.WriteLine("2) View Word List");
                Console.WriteLine("3) Clear Console");
                Console.WriteLine("4) Quit");

                command = Convert.ToInt32(Console.ReadLine());
                //Command Actions
                switch (command)
                {
                    case 1:
                        //Generate Word List & Parallel Array List
                        CreateWordList();
                        guessStatus = new ArrayList();

                        //Choose the Word
                        Random wordChooser = new Random();
                        int chosenWordIndex = wordChooser.Next(wordList.Count);

                        chosenWord = (String)wordList[chosenWordIndex];

                        //Populate the Parallel Array List With Blanks
                        //  Display the Blank Word
                        for (int i = 0; i < chosenWord.Length; i++)
                        {
                            guessStatus.Add("_");
                        }
                        Console.WriteLine();

                        //Guessing
                        turns = chosenWord.Length + 5;
                        String guess;

                        do
                        {
                            Console.WriteLine("\nTurns Remaining: " + turns + "\n");
                            for (int i = 0; i < guessStatus.Count; i++)
                            {
                                Console.Write(guessStatus[i] + " ");
                            }

                            do
                            {
                                Console.WriteLine("\n\nGuess a letter:");
                                guess = Console.ReadLine();
                            } while (guess.Length <= 0);

                            Guess(guess.Substring(0, 1));

                            if (!guessStatus.Contains("_"))
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nYou Won!");
                                Console.ResetColor();
                                break;
                            }
                        } while (turns > 0);

                        if (guessStatus.Contains("_"))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nYou Lose!");
                            Console.ResetColor();
                        }

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\nThe Word Was: " + chosenWord.ToUpper() + "\n\n");
                        Console.ResetColor();

                        //Stop the Case
                        break;
                    case 2:
                        //Create Word List
                        CreateWordList();

                        //Print Each Available Word
                        foreach (String word in wordList)
                        {
                            Console.WriteLine(word);
                        }

                        Console.WriteLine("\n\n");

                        //Stop the Case
                        break;
                    case 3:
                        //Clear Console
                        Console.Clear();

                        //Stop the Case
                        continue;
                    case 4:
                        //Stop Loop
                        continueApp = false;

                        //Stop the Case
                        break;
                }
            }

            //Wait Until the User Confirms Close
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            
        }

        //Guess a Letter
        static void Guess(String letter)
        {
            bool turnChange = true;

            for (int i = 0; i < chosenWord.Length; i++)
            {
                if(guessStatus[i].Equals(letter.ToUpper())) //If Letter Was Already Guessed
                {
                    if(turnChange)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nYou have already guessed this letter!");
                        Console.ResetColor();
                        turnChange = false;
                    }
                }
                else if(chosenWord.Substring(i,1).Equals(letter.ToLower())) //If Letter Was Found But Not Guessed
                {
                    guessStatus[i] = letter.ToUpper();
                    if(turnChange)
                    {
                        turnChange = false;
                    }
                }
            }

            if(turnChange) //If Letter Was Not Found, Subtract 1 Turn
            {
                turns--;
            }

        }

        //Word List
        static void CreateWordList()
        {
            //Instantiate Word List Array List
            wordList = new ArrayList
            {

                //3-Letter Words
                "arm",
                "axe",
                "bat",
                "bed",
                "bee",
                "boy",
                "bus",
                "cat",
                "cow",
                "eat",
                "egg",
                "eye",
                "ink",
                "jam",
                "jar",
                "key",
                "owl",
                "pig",
                "pot",
                "rat",
                "run",
                "sky",
                "sun",
                "toy",
                "van",
                "zip",

                //4-Letter Words
                "army",
                "atom",
                "baby",
                "bank",
                "bath",
                "bean",
                "bear",
                "beef",
                "bomb",
                "boot",
                "card",
                "coal",
                "desk",
                "dirt",
                "doll",
                "drum",
                "duck",
                "fish",
                "game",
                "girl",
                "gold",
                "golf",
                "king",
                "kite",
                "mail",
                "meat",
                "nose",
                "park",
                "pear",
                "pony",
                "rain",
                "road",
                "shed",
                "ship",
                "shoe",
                "sink",
                "snow",
                "sofa",
                "song",
                "star",
                "suit",
                "tent",
                "wind",
                "wolf",
                "worm",

                //5-Letter Words
                "alien",
                "angel",
                "apple",
                "beach",
                "broom",
                "candy",
                "chair",
                "cloud",
                "clown",
                "drink",
                "flame",
                "flute",
                "ghost",
                "globe",
                "grass",
                "heart",
                "house",
                "jelly",
                "jewel",
                "knife",
                "laser",
                "lemon",
                "magic",
                "medal",
                "money",
                "movie",
                "music",
                "panda",
                "pants",
                "paper",
                "peach",
                "phone",
                "piano",
                "pizza",
                "plane",
                "radio",
                "robot",
                "ruler",
                "smoke",
                "snake",
                "squid",
                "torch",
                "truck",
                "watch",
                "water",
                "whale",
                "world",
                "zebra",

                //6-Letter Words
                "archer",
                "bamboo",
                "banana",
                "beaver",
                "bottle",
                "burger",
                "cactus",
                "camera",
                "carrot",
                "castle",
                "desert",
                "domino",
                "dragon",
                "eraser",
                "family",
                "flower",
                "friend",
                "galaxy",
                "garden",
                "guitar",
                "helmet",
                "jacket",
                "kitten",
                "laptop",
                "lizard",
                "monkey",
                "muffin",
                "orange",
                "peanut",
                "pencil",
                "pirate",
                "remote",
                "school",
                "shovel",
                "statue",
                "temple",
                "tennis",
                "turtle",
                "wallet",
                "window",
                "wizard",
                "zombie"
            };
        }

    }
}