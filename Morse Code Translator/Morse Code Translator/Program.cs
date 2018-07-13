using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morse_Code_Translator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("* * * * Morse Code Converter * * * *");
            Console.WriteLine();
            Console.WriteLine();
            Dictionary<char, String> morseCode = new Dictionary<char, String>()
            {
                { 'A' , ".-"},
                { 'B' , "-..."},
                { 'C' , "-.-."},
                { 'D' , "-.."},
                { 'E' , "."},
                { 'F' , "..-."},
                { 'G' , "--."},
                { 'H' , "...."},
                { 'I' , ".."},
                { 'J' , ".---"},
                { 'K' , "-.-"},
                { 'L' , ".-.."},
                { 'M' , "--"},
                { 'N' , "-."},
                { 'O' , "---"},
                { 'P' , ".--."},
                { 'Q' , "--.-"},
                { 'R' , ".-."},
                { 'S' , "..."},
                { 'T' , "-"},
                { 'U' , "..-"},
                { 'V' , "...-"},
                { 'W' , ".--"},
                { 'X' , "-..-"},
                { 'Y' , "-.--"},
                { 'Z' , "--.."},
                { '0' , "-----"},
                { '1' , ".----"},
                { '2' , "..---"},
                { '3' , "...--"},
                { '4' , "....-"},
                { '5' , "....."},
                { '6' , "-...."},
                { '7' , "--..."},
                { '8' , "---.."},
                { '9' , "----."},
                { '.' , ".-.-.-"},
                { ',' , "--..--"},
                { '?' , "..--.."},
                { '/' , "-..-."},
                { '@' , ".--.-."},
            };
            // One way to add into dictionary
            // morseCode.Add('A', ".-");
            // morseCode.Add('B', "-...");

            /* 
             * Testing Dictionary Entries
             * Console.WriteLine(morseCode['A']);
             * Console.WriteLine(morseCode['B']);
            */
            bool again = true;
            while (again)
            {
                Console.WriteLine(" Type Your String: ");
                String input = Console.ReadLine();
                input = input.ToUpper();
                Console.WriteLine();

                for (int i = 0; i < input.Length; i++)
                {
                    if (i > 0)
                        Console.Write('/');

                    char c = input[i];
                    if (morseCode.ContainsKey(c))
                        Console.Write(morseCode[c]);
                }

                Console.WriteLine();
                Console.WriteLine();
                


                bool valid = false;

                while (valid == false)
                {
                    Console.WriteLine(" Translate another string? (Y/N)");
                    String x = Console.ReadLine();
                    x = x.ToUpper();


                    if (x == "Y" || x == "YES")
                    {
                        again = true;
                        valid = true;
                    }

                    else if (x == "N" || x == "NO")
                    {
                        again = false;
                        valid = true;
                    }

                    else
                    {
                        Console.WriteLine(" Invalid input. Type Y/N ");
                        Console.WriteLine();
                    }
                }

            }
            
            Console.WriteLine(" Press any key...");
            Console.WriteLine();
            Console.ReadKey(false);
        }
    }
}
