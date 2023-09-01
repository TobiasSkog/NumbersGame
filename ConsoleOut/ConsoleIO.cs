// Tobias Skog .NET23
using NumbersGame.GameLogic;

namespace NumbersGame.ConsoleOut
{

    // Static class that only handles writing out to the console
    public static class ConsoleIO
    {
        // Method that writes out the Welcome Message to the user
        public static void WelcomeMessage()
        {
            Console.WriteLine($"=========================================");
            Console.WriteLine("              Gissningsleken");
            Console.WriteLine($"=========================================");

        }
        // Method that writes out the Difficulty Message in the form of a menu to the user
        public static void DifficultyMessage()
        {
            Console.WriteLine("Du ska nu få välja svårighetsnivå!");
            Console.WriteLine("1. Nybörjare - 10 tal och 8 försök.");
            Console.WriteLine("2. Lätt - 10 tal och 5 försök.");
            Console.WriteLine("3. Medel - 20 tal och 4 försök.");
            Console.WriteLine("4. Expert - 50 tal och 3 försök");
            Console.WriteLine("5. Galenskap - 500 tal och 3 försök.");
        }

        // Method that writes out the Statistics of the game played, takes a GuessStorage object as input
        public static void WriteStatistics(GuessStorage game)
        {
            // Using string interpolation to give the user statistics from the game played with information from
            // the GuessStorage object that was passed in as input
            Console.WriteLine("\nHär kommer lite statisk för denna rundan!\n");

            Console.WriteLine($"=========================================");
            Console.WriteLine($"        Jag tänkte på: {game.MyNumber}");
            Console.WriteLine($"    Antal gånger du gissade: {game.AmountOfGuesses}");
            Console.WriteLine($"    Antal för låga gissningar: {game.AmountOfLow}");
            Console.WriteLine($"    Antal för höga gissningar: {game.AmountOfHigh}");
            Console.WriteLine($"=========================================\n");
        }

        // Method that writes out the Dictionary Message to the user takes a int for the dictionary choice
        // and a GuessStorage object as input
        public static void DictionaryMessage(int DictionaryChoice, GuessStorage game)
        {
            // Writing to the console the result from the class AlternateAnswers with the method GetAlternateAnswer
            // where the DictionaryChoice is the first input and the GuessStorage object is the second input
            Console.WriteLine(AlternateAnswers.GetAlternateAnswer(DictionaryChoice, game));
        }
    }
}
