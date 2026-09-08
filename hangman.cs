
class Program {

    static string rightWord = "katt";

    static string GuessLetter(string prompt)
    {
        string? input;
        while (true)
        {
            Console.Write(prompt);
            input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input) && input.Length == 1 && char.IsLetter(input[0]))
            {
                break;
            }

            Console.WriteLine("Ogiltig inmatning. Ange exakt en bokstav.");
        }
        return input!;
    }

    static bool CompareLetters(string rightWord, string chosenLetter)
    {
        return rightWord.Contains(chosenLetter);
    }

    static void RightPlace(string chosenLetter, string rightWord)
    {
        bool found = false;

        for (int i = 0; i < rightWord.Length; i++)
        {
            if (rightWord[i] == chosenLetter[0])
            {
                Console.WriteLine($"Bokstaven är rätt och finns på position {i+1}.");
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("Den bokstaven finns tyvärr inte i ordet.");
        }
    }

    static void Main()
    {
        string chosenLetter = GuessLetter("Ange en bokstav: ");
        Console.WriteLine($"Du har angett bokstaven: {chosenLetter}");
        bool isCorrect = CompareLetters(rightWord, chosenLetter);
        RightPlace(chosenLetter, rightWord);
    }
}