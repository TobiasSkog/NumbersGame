// Tobias Skog - .NET23
namespace NumbersGame.GameLogic
{
    internal class AlternateAnswers
    {
        // Method that returns a string and takes a int and a GuessStorage object as input 
        public static string GetAlternateAnswer(int dictionary, GuessStorage game)
        {
            // Creating and initializing a new random and an int with the random.Next method 
            // to create a random integer between 0, 1, 2, 3, 4
            Random rnd = new();
            int answer = rnd.Next(0, 5);

            // Declaring and Initalizing a list of dictionaries
            List<Dictionary<int, string>> dictionaries = new();

            // Creating a new Dictionary wich takes a int and a string
            // We use these to get random answers based on the users guess
            // and how far or close it was
            // There is a total of 6 lists:
            // Far Low Answers, Close Low Answers,
            // Close High Answers, Far High Answers,
            // Correct Answers,
            // Game Over Answers

            // Ordering all the lists with the range from 0-4 so that our int answer can return
            // a string answer no matter wich dictionary we choose
            Dictionary<int, string> FarLowAnswers = new(){
            { 0 , "Det var otroligt... Långt bort...För lågt." },
            { 1 , "Eeh... Okej... Ja nä de där vart lite fel! För lågt."},
            { 2 , "Nu tog du i lite va? För lågt." },
            { 3 , "Ja... Hur kom du ens på ett så lågt nummer? För lågt." },
            { 4 , "Nä det var fel! För lågt." }
            };
            Dictionary<int, string> CloseLowAnswers = new(){
            { 0 , "Det var nära, lite för lågt." },
            { 1 , "Nästan! Lite för lågt."},
            { 2 , "Nu börjar det likna något! Lite för lågt." },
            { 3 , "Oj det var nära! Lite för lågt!" },
            { 4 , "Inte illa, lite för lågt." }
            };
            Dictionary<int, string> CloseHighAnswers = new(){
            { 0, "Nära skjuter ingen hare, lite för högt."},
            { 1 , "Det var nära ögat, lite för högt."},
            { 2 , "Inte illa, men inte bra nog! Lite för högt." },
            { 3 , "Hade den där träffat lite lägre så hade du vunnit här! Lite för högt." },
            { 4 , "Oj det var nära! Lite för högt!" }
            };
            Dictionary<int, string> FarHighAnswers = new(){
            { 0, "Dem säger sikta mot stjärnorna, men nu tog du i lite va? För högt."},
            { 1 , "Eeh... Nä inte ens nära, på tok för högt."},
            { 2 , "Nu vet jag inte om vi spelar samma spel längre... För högt." },
            { 3 , "Det var inte riktigt det jag tänkte på, för högt." },
            { 4 , "Oj oj oj! Nu brinner det.... På grannens tak... För högt." }
            };
            Dictionary<int, string> CorrectAnswers = new(){
            { 0, "\nWohoo! Du vann!" },
            { 1, "\nSnyggt byggt! Du vann!" },
            { 2, "\nOj där fick du mig! Det var korrekt!" },
            { 3, "\nDra mig baklänges, det var rätt!" },
            { 4, "\nA men titta! De var ju helt rätt!" }
            };
            Dictionary<int, string> GameOverAnswers = new(){
            { 0, $"\nTyvärr, du lyckades inte gissa talet på {game.TotalRemainingGuesses} försök!" },
            { 1, $"\nDu hade {game.TotalRemainingGuesses} försök och gissade inte rätt en enda gång, du har förlorat!" },
            { 2, $"\nHaha där fick jag dig! Du gissade fel {game.TotalRemainingGuesses} gånger!" },
            { 3, $"\nDet blev en förlust för dig, inte ett rätt på {game.TotalRemainingGuesses} försök." },
            { 4, $"\nNu har du gissat {game.TotalRemainingGuesses} gånger, vi avslutar här. Du förlorar." }
            };

            // Adding each dictionary in the dictionarys list
            dictionaries.Add(FarLowAnswers);
            dictionaries.Add(CloseLowAnswers);
            dictionaries.Add(CloseHighAnswers);
            dictionaries.Add(FarHighAnswers);
            dictionaries.Add(CorrectAnswers);
            dictionaries.Add(GameOverAnswers);

            // returning a string value based on the the input of dictionary (a int with value 0-5) and
            // the random int (with a value of 0-4) to get our random answer from our specific dictionary
            return dictionaries[dictionary][answer];
        }
    }
}
