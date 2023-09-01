// Tobias Skog - .NET23
// using namespaces that contains code needed to call methods
using NumbersGame.ConsoleOut;
using NumbersGame.GameLogic;

namespace NumbersGame.App
{
    public static class App
    {
        // Method that takes no input and is in charge of starting the software
        public static void Run()
        {
            // Creating a new empty object of GuessStorage called game
            GuessStorage game;
            // do while (game.KeepPlaying) is true
            // Will ask the player after the game is won / lost if the player
            // wants to play again
            do
            {
                // initializing the game object with the GameHandler method CreateNewGame
                game = GameHandler.CreateNewGame();
                // while loop so that it only asks the user to make a guess
                // if we have guesses remaining and the game is not won
                // if any of the conditions are not filled we jump over the loop and write out the statistics of the game and ask the user if they want to play again
                while (game.RemainingGuesses > 0 && !game.Victory)
                {
                    // Remaining guesses are greater than 0 and we have not won yet
                    // asking the user to make a guess with the GameHandler class and MageAGuess method inputing the game object
                    GameHandler.MakeAGuess(game);

                }
                // The conditions for the while loop is not met, we call ConsoleIO class method WriteStatistics and input the game object
                ConsoleIO.WriteStatistics(game);
                // we set the bool in the game object game.KeepPlaying to the GameHandler class method WantToPlayAgain where we give the question prompt as input to the method
                game.KeepPlaying = GameHandler.WantToPlayAgain("Vill du spela igen? (J)a eller (N)ej: ");
                // if the user answered yes the game will play again and the loop continues, if the user answered no the loop will break and the program will end
            } while (game.KeepPlaying);
        }
    }
}
