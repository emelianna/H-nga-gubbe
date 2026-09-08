using System.Collections.Generic;
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

    static void RightPlace(string chosenLetter, string rightWord, char[] guessedWord, List<string> wrongLetters)
{
    bool found = false;

    for (int i = 0; i < rightWord.Length; i++)
    {
        if (rightWord[i] == chosenLetter[0])
        {
            guessedWord[i] = chosenLetter[0]; // fyll i rätt bokstav på rätt plats
            found = true;
        }
    }

   if (!found)
{
    Console.WriteLine("Den bokstaven finns tyvärr inte i ordet.");
    wrongLetters.Add(chosenLetter);
}
}

static void DrawHangman(int wrongGuesses)
{
    Console.WriteLine(hangmanStages[wrongGuesses]);
    }
    
static string[] hangmanStages = new string[]
{
    @"
  +---+
  |   |
      |
      |
      |
      |
=========",
    @"
  +---+
  |   |
  O   |
      |
      |
      |
=========",
    @"
  +---+
  |   |
  O   |
  |   |
      |
      |
=========",
    @"
  +---+
  |   |
  O   |
 /|   |
      |
      |
=========",
    @"
  +---+
  |   |
  O   |
 /|\  |
      |
      |
=========",
    @"
  +---+
  |   |
  O   |
 /|\  |
 /    |
      |
=========",
    @"
  +---+
  |   |
  O   |
 /|\  |
 / \  |
      |
========="
};

static char[] CreateGuessedWord(string word)
{
    char[] result = new char[word.Length];
    for (int i = 0; i < result.Length; i++)
    {
        result[i] = '_';
    }
    return result;
}

static bool IsWordGuessed(char[] guessedWord)
{
    return !new string(guessedWord).Contains('_');
}


static void Main()
{
    char[] guessedWord = CreateGuessedWord(rightWord);
    int guessCount = 0;
    int wrongGuesses = 0;
    List<string> wrongLetters = new List<string>();

    while (true)
    {
        string chosenLetter = GuessLetter("Ange en bokstav: ");
        guessCount++;

        Console.WriteLine($"Du har angett bokstaven: {chosenLetter}");

       bool isCorrect = CompareLetters(rightWord, chosenLetter);
if (!isCorrect)
{
    wrongGuesses++;
    DrawHangman(wrongGuesses);

    if (wrongGuesses == hangmanStages.Length - 1)
    {
        Console.WriteLine("Gubben är klar – du förlorade!");
        break;
    }
}

RightPlace(chosenLetter, rightWord, guessedWord, wrongLetters);
Console.WriteLine(new string(guessedWord));
Console.WriteLine("Fel gissade bokstäver: " + string.Join(", ", wrongLetters));

if (IsWordGuessed(guessedWord))
{
    Console.WriteLine("Grattis, du gissade hela ordet!");
    break;
}

    
}
Console.WriteLine($"Antal gissningar: {guessCount}");
}
}