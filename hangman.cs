
class Program {

string rightWord = "katt";

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

static bool CompareLetters(string rightWord,string chosenLetter)

{
    return rightWord.Contains(chosenLetter);
}




static void Main() {

string chosenLetter = GuessLetter("Ange en bokstav: ");
Console.WriteLine($"Du har angett bokstaven: {choosenLetter}");
bool isCorrect = CompareLetters(rightWord, guessedLetter);

}
}