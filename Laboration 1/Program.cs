

using System;

class Program 
{
    static void Main()
    {
        string input = "29535123p48723487597645723645";
        long totalSum = 0; // Variabel för att hålla summan av alla tal
        int length = input.Length;

        for (int i = 0; i < length; i++)
        {
            if (char.IsDigit(input[i]))
            {
                for (int j = i + 1; j < length; j++)
                {
                    if (char.IsDigit(input[j]) && input[i] == input[j])
                    {
                        bool validSubstring = true;
                        for (int k = i + 1; k < j; k++)
                        {
                            if (!char.IsDigit(input[k]) || input[k] == input[i])
                            {
                                validSubstring = false;
                                break;
                            }
                        }

                        if (validSubstring)
                        {
                            string substring = input.Substring(i, j - i + 1);
                            PrintWithHighlight(input, i, j);

                            // Lägger till delsträngens numeriska värde till summan här
                            totalSum += long.Parse(substring);
                        }
                    }
                    else if (!char.IsDigit(input[j]))
                    {
                        break;
                    }
                }
            }
        }

        // Tom rad för att separera utdata
        Console.WriteLine();

        // Skriv ut summan
        Console.WriteLine($"Summa = {totalSum}");
    }

    // Metod för att skriva ut strängen med en markerad delsträng
    static void PrintWithHighlight(string input, int startIndex, int endIndex)
    {
        Console.Write(input.Substring(0, startIndex));

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write(input.Substring(startIndex, endIndex - startIndex + 1));

        Console.ResetColor();
        Console.WriteLine(input.Substring(endIndex + 1));
    }
}
