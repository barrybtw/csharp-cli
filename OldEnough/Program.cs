using System.Globalization;

namespace OldEnough;

public static class Program
{
    public static void Main(string[] args)
    {
        var birthday = GetBirthday();
        var eighteenPlus = DateTime.Now.AddYears(-18);

        var isEighteen = birthday < eighteenPlus;
        Console.WriteLine(isEighteen ? $"Du er over 18 år gammel." : "Du er ikke over 18 år gammel, fy fy.");
    }

    private static DateTime GetBirthday()
    {
        Console.WriteLine("Hvad er din fødselsdag? Brug format dd-MM-yyyy");
        var userInput = Console.ReadLine();

        var culture = CultureInfo.GetCultureInfo("da-DK");
        const DateTimeStyles style = DateTimeStyles.None;


        var success = DateTime.TryParseExact(
            userInput,
            "dd-MM-yyyy",
            culture,
            style,
            out var birthDay
        );

        if (!success)
        {
            throw new Exception("Datoen blev indtastet forkert");
        }

        return birthDay;
    }
}