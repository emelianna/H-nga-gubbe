using System.Collections.Generic;
class Program {

    static string ChooseRandomWord() {
    List<string> rightWords = new List<string> {"hund", "katt", "häst", "ko", "gris", "får", "get", "kanin", "hamster", "marsvin", "elefant", "lejon", "tiger", "gepard", "leopard", "zebra", "giraff", "noshörning", "flodhäst", "björn", "varg", "räv", "älg", "rådjur", "hjort", "hare", "ekorre", "igelkott", "grävling", "utter", "säl", "val", "delfin", "haj", "pingvin", "uggla", "örn", "falk", "duva", "skata", "kråka", "svan", "gås", "anka", "höna", "tupp", "kalkon", "struts", "papegoja", "kolibri", "orm", "ödla", "krokodil", "sköldpadda", "groda", "padda", "salamander", "fjäril", "bi", "geting", "myra", "skalbagge", "spindel", "snigel", "mussla", "bläckfisk", "krabba", "hummer", "räka"};

    Random random = new();
    int randomIndex = random.Next(0, rightWords.Count);
    return rightWords[randomIndex];
}
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
            Console.WriteLine("Bra, den bokstaven finns!");
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
    
static string[] hangmanStages =
[
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
];
static void DrawTrophy()
{
    Console.WriteLine(@"
      ___________
     '._==_==_=_.'
     .-\:      /-.
    | (|:.     |) |
     '-|:.     |-'
       \::.    /
        '::. .'
          ) (
        _.' '._
       `""""""""`
");
}

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


 
    static void PlayRound()
{
    string rightWord = ChooseRandomWord();
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
        Console.WriteLine($"Rätt ord var {rightWord}");
        break;
    }
}

RightPlace(chosenLetter, rightWord, guessedWord, wrongLetters);
Console.WriteLine(new string(guessedWord));
Console.WriteLine("Fel gissade bokstäver: " + string.Join(", ", wrongLetters));

if (IsWordGuessed(guessedWord))
{
    Console.WriteLine("Grattis, du gissade hela ordet rätt!");
    DrawTrophy();
    break;
}

    
}
Console.WriteLine($"Antal gissningar: {guessCount}");
}


static void Main()
{
    bool playAgain = true;

    while (playAgain)
    {
        PlayRound();

        Console.Write("Vill du spela en omgång till? (ja/nej): ");
        string? answer = Console.ReadLine();


        if (answer == null || answer.ToLower() != "ja")
        {
            
            playAgain = false;
        }
    }

    Console.WriteLine("Tack för att du spelade!");
}
}