using static System.Int64;

namespace GuessTheNumber;

public abstract class Program
{
    public static void Main()
    {
        var isRunning = true;
        var randNumberInstance = new Random();

        while (isRunning)
        {
            var userInput = AskForNumber();
            
            Console.WriteLine($"Du har valgt nummeret: {userInput}");
            var currRand = randNumberInstance.NextInt64(1, userInput);
            
            var usersGuess = AskForGuess(userInput);
            Console.WriteLine(usersGuess == currRand
                ? $"Du gættede rigtigt! Tallet var {currRand}"
                : $"Desværre, du gættede ikke rigtigt, det var {currRand}");

            var goAgain = GoAgain();
            if (!goAgain) isRunning = false;
        }
    }

    private static long AskForNumber()
    {
        Console.WriteLine("Vælg et positivt tal:");
        var userInput = Console.ReadLine();

        var parseSucceeded = TryParse(userInput, out var userValue);
        if (userValue == 0 || parseSucceeded == false)
        {
            throw new Exception("Vælg et positivt tal");
        }

        return userValue;
    }

    private static long AskForGuess(long maxValue)
    {
        Console.WriteLine($"Gæt et nummer mellem 1 og {maxValue}");
        var userInput = Console.ReadLine();

        var parseSucceeded = TryParse(userInput, out var userGuess);

        if (userGuess == 0 || parseSucceeded == false)
        {
            throw new Exception("Vælg et positivt tal");
        }

        return userGuess;
    }

    private static bool GoAgain()
    {
        Console.WriteLine("Vil du prøve igen? Skriv enten 'ja' eller 'nej'");
        var userInput = Console.ReadLine();

        if (userInput == null)
        {
            throw new Exception("Vælg enten ja eller nej");
        }

        return "ja".Equals(userInput.ToLower());
    }
}