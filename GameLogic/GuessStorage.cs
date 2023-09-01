// Tobias Skog - .NET23
namespace NumbersGame.GameLogic
{
    public class GuessStorage
    {
        // Attributes of the GuessStorage class
        // where all the attributes except the "MyNumber"
        // is accessable outside to both get and set the value
        // we will only choose to set the value of the MyNumber
        // variable inside this class in the constructor
        public int MyNumber { get; private set; } // The number the user is trying to guess
        public int AmountOfGuesses { get; set; } // The amount of times the user have guessed
        public int AmountOfLow { get; set; } // The amount of times the user guessed a number lower than the correct number
        public int AmountOfHigh { get; set; } // The amount of times the user guessed a number higher than the correct number
        public int RemainingGuesses { get; set; } // The remaining amount of numbers the user have left to guess
        public int TotalRemainingGuesses { get; set; } // The total amount of guesses the user gets on this difficulty
        public int MaxRange { get; set; } // The max value that we are allowed to set MyNumber to
        public bool KeepPlaying { get; set; } // A bool to check if the user wants to keep on playing
        public bool Victory { get; set; } // A bool to check if the user has won

        // Constructor for the GuessStorage class where we take 3 ints as input
        public GuessStorage(int myNumber, int remainingGuesses, int maxRange)
        {
            // Assining the MyNumber variable to the input of myNumber
            MyNumber = myNumber;
            // Assigning the values of AmountOfGuesses, AmountOfLow, AmountOfHigh to 0 as a default
            AmountOfGuesses = 0;
            AmountOfLow = 0;
            AmountOfHigh = 0;
            // Assigining the RemainingGuesses variable to the input remainingGuesses
            RemainingGuesses = remainingGuesses;
            // Assigining the TotalRemainingGuesses variable to the input remainingGuesses
            TotalRemainingGuesses = remainingGuesses;
            // Assigning the KeepPlaying variable as a default to true
            KeepPlaying = true;
            // Assigning the Victory variable as a default to false
            Victory = false;
            // Assigning the MaxRange variable to the input maxRange
            MaxRange = maxRange;
        }
    }
}
