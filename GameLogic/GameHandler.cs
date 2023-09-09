// Tobias Skog - .NET23
using NumbersGame.ConsoleOut;

namespace NumbersGame.GameLogic
{
    public class GameHandler
    {

        // Method that returns a GuessStorage object and takes no input
        public static GuessStorage CreateNewGame()
        {
            // Clears the console
            Console.Clear();
            // Calls the ConsoleIO class with the WelcomeMessage method
            ConsoleIO.WelcomeMessage();
            // Creating a int difficulty and assigning it to the value returned from the
            // GetVerfiedIntRange method wich takes the prompt as first input and the maximum allowed range as an int as second input
            int difficulty = GetVerifiedIntRange("\nVilken svårighetsnivå vill du spela på: ", 5, true);
            // Clearing the console again
            Console.Clear();
            // returning a GuessStorage Object created with the GetDifficulty method with the difficulty as input
            return GetDifficulty(difficulty);

        }

        // Method wich makes no returns, takes a GuessStorage object as input
        public static void MakeAGuess(GuessStorage game)
        {
            // Creating a int dictionaryChoice wich will be used later in the method
            int dictionaryChoice;

            // Creating a int guess and assigning it a value from the GetVerifiedIntRange
            // method wich takes the prompt as first input and the maximum allowed range
            // as an int as second input
            // We use the game object to get the value of the MaxRange in both the prompt and the
            // the value for recieving a int from the method
            int guess = GetVerifiedIntRange($"Vilken siffra tänker jag på (1 - {game.MaxRange}): ", game.MaxRange);

            // if the guess is the same as the object "MyNumber" variable wich is the the goal of the guessing game
            // we have won! Setting the objects Victory bool to true and choosing the victory dictionary
            if (guess == game.MyNumber)
            {
                game.Victory = true;
                dictionaryChoice = 4;
                // we recieved the correct guess, returning
                return;
            }
            // if the guess is lower then the value we are looking for...
            if (guess < game.MyNumber)
            {
                // if the guess is 1 or 2 numbers lower than then value we are looking for
                if (guess - game.MyNumber >= -2 && guess - game.MyNumber < 0)
                {
                    // we increment the object AmountOfLow guesses variable with +1
                    // and choose the dictionary for Close Low Answers
                    game.AmountOfLow++;
                    dictionaryChoice = 1;
                }
                // the value is greater than 2 below the value we are looking for
                else
                {
                    // we increment the object AmountOfLow guesses variable with +1
                    // and choose the dictionary for Far Low Answers

                    game.AmountOfLow++;
                    dictionaryChoice = 0;
                }
            }
            // else if the value is 1 or 2 numbers higher than the value we are looking for
            else if (guess - game.MyNumber > 0 && guess - game.MyNumber <= 2)
            {
                // we increment the object AmountOfHigh guesses variable with +1
                // and choose the dictionary for Close High Answers
                dictionaryChoice = 2;
                game.AmountOfHigh++;
            }
            else
            {
                // we increment the object AmountOfHigh guesses variable with +1
                // and choose the dictionary for Far High Answers
                dictionaryChoice = 3;
                game.AmountOfHigh++;

            }

            // incrementing the AmountOfGuesses with 1 and decrementing the RemainingGuesses with 1
            game.AmountOfGuesses++;
            game.RemainingGuesses--;
            // if we are out of guesses and we have NOT won
            if (game.RemainingGuesses <= 0 && !game.Victory)
            {
                // choose the dictionary for Game Over Answers
                dictionaryChoice = 5;
            }

            // calling the class ConsoleIO with the method DictionaryMessage with the dictionaryChoice
            // as first input and the game object as the second input
            ConsoleIO.DictionaryMessage(dictionaryChoice, game);
        }

        // Method that returns an int and takes a string and int as inputs
        public static int GetVerifiedIntRange(string prompt, int maxRange, bool getDifficulty = false)
        {
            // creates a new string that will be used later in the method
            string userInput;
            // do while loop to handle if the user gives us the wrong input
            // then it will keep looping until we have an acceptable value
            do
            {
                // if getDifficulty is true, wich is an optional input in the method that's otherwise
                // set to false, we will call the ConsoleIO class with the DifficultyMessage method 
                // to write out the menu for choosing a Difficulty
                if (getDifficulty)
                {
                    ConsoleIO.DifficultyMessage();
                }
                // writing the prompt to the console
                Console.Write(prompt);
                // assigning userInput to the users answer with Console.ReadLine()
                userInput = Console.ReadLine();
                // using int.TryParse on the userInput and creating a new int verifiedInt if the value is a int
                // if it's not we skip over the if block and write the error message to the screen and loop restarts
                // until we get a value we accept
                if (int.TryParse(userInput, out int verifiedInt))
                {
                    // the value is an int, no we check if the value is greater than 0 and less or equal to the
                    // defined maxRange value
                    if (verifiedInt > 0 && verifiedInt <= maxRange)
                    {
                        // the value is within the specified range, returning the value
                        return verifiedInt;
                    }
                }
                // the value was NOT either an INT or within the specified range
                // writing a error message in the console to encourage the user to get us
                // the value we're looking for
                Console.WriteLine($"Fel inmatning, det måste vara ett heltal mellan 1-{maxRange}.");

                // while true to keep the loop infite unless a correct answer is given
            } while (true);
        }

        // Method that returns a bool with a string as input
        public static bool WantToPlayAgain(string prompt)
        {
            // creates a new string that will be used later in the method
            string userInput;
            // do while loop to handle if the user gives us the wrong input
            // then it will keep looping until we have an acceptable value
            do
            {
                // writing the prompt to the console
                Console.Write(prompt);
                // assigning userInput to the users answer with Console.ReadLine().ToUpper()
                // making all the characters uppercase to make it easier to compare values
                userInput = Console.ReadLine().ToUpper();
                // if the user inputs "JA" or "J" 
                if (userInput == "JA" || userInput == "J")
                {
                    // the user wants to keep playing, returns true
                    return true;
                }
                // if the user inputs "NEJ" or "N" 
                else if (userInput == "NEJ" || userInput == "N")
                {
                    // the user wants to stop playing, returns false
                    return false;
                }
                // the value recieved was not "JA", "J", "NEJ" or "N"
                // writing an error to the console to encourage the user
                // to give us the value we are looking for
                Console.WriteLine("Fel inmatning! Svara (J)a eller (N)ej.");

                // while true to keep the loop infite unless a correct answer is given
            } while (true);
        }

        // Method that returns a GuessStorage object and takes an int as input
        public static GuessStorage GetDifficulty(int difficulty)
        {
            // Declaring and Initializing a new Random
            Random rnd = new();
            // Declaring a new GuessStorage with the name game
            GuessStorage game;

            // Creating a switch with the difficulty as input
            switch (difficulty)
            {
                // if difficulty is 1
                case 1:
                    // Initializing a new GuessStorage Object with the constructor that takes 3 inputs
                    // 1.
                    // the number the user is trying to guess with rnd.Next(1,11) wich is a random number
                    // that can be greater or equal to 1 and less or equal to 10
                    // 2.
                    // the amount of remaining guesses for that difficulty 8
                    // 3. 
                    // the highest number that we can get from the random value 10

                    game = new GuessStorage(rnd.Next(1, 11), 8, 10);
                    // returning the GuessStorage Object
                    return game;
                // if difficulty is 2
                case 2:
                    // Initializing a new GuessStorage Object with the constructor that takes 3 inputs
                    // 1.
                    // the number the user is trying to guess with rnd.Next(1,11) wich is a random number
                    // that can be greater or equal to 1 and less or equal to 10
                    // 2.
                    // the amount of remaining guesses for that difficulty 5
                    // 3.
                    // the highest number that we can get from the random value 10
                    game = new GuessStorage(rnd.Next(1, 11), 5, 10);
                    // returning the GuessStorage Object
                    return game;
                // if difficulty is 3
                case 3:
                    // Initializing a new GuessStorage Object with the constructor that takes 3 inputs
                    // 1.
                    // the number the user is trying to guess with rnd.Next(1,21) wich is a random number
                    // that can be greater or equal to 1 and less or equal to 20
                    // 2.
                    // the amount of remaining guesses for that difficulty 4
                    // 3.
                    // the highest number that we can get from the random value 20
                    game = new GuessStorage(rnd.Next(1, 21), 4, 20);
                    // returning the GuessStorage Object
                    return game;
                // if difficulty is 4
                case 4:
                    // Initializing a new GuessStorage Object with the constructor that takes 3 inputs
                    // 1.
                    // the number the user is trying to guess with rnd.Next(1,51) wich is a random number
                    // that can be greater or equal to 1 and less or equal to 50
                    // 2.
                    // the amount of remaining guesses for that difficulty 3
                    // 3.
                    // the highest number that we can get from the random value 50
                    game = new GuessStorage(rnd.Next(1, 51), 3, 50);
                    // returning the GuessStorage Object
                    return game;
                // if difficulty is 5
                case 5:
                    // Initializing a new GuessStorage Object with the constructor that takes 3 inputs
                    // 1.
                    // the number the user is trying to guess with rnd.Next(1,501) wich is a random number
                    // that can be greater or equal to 1 and less or equal to 500
                    // 2.
                    // the amount of remaining guesses for that difficulty 3
                    // 3.
                    // the highest number that we can get from the random value 500
                    game = new GuessStorage(rnd.Next(1, 501), 3, 500);
                    // returning the GuessStorage Object
                    return game;
                // if difficulty is anything else but 1-5
                default:
                    // Something went wrong somewhere in the code if we get here so we create a new GuessStorage
                    // object with 0 as the number we're trying to guess, 0 as the amount of remaining guesses  
                    // and 0 as the highest number we can get from the random value
                    // If we return a object with 0 remaining guesses the game will skip the loop to let the 
                    // user make a guess and tell them they lost and restart the game if the user choose to do so
                    game = new GuessStorage(0, 0, 0);
                    // returning the GuessStorage Object
                    return game;
            }
        }
    }
}
