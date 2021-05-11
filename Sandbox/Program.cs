using System;
using System.IO;
using System.Numerics;
using TextToNumber;

namespace Sandbox
{
    class TextToNumber
    {
        static void Main(string[] args)
        {
            var parser = new WordsToNumber();
            parser.NumberToString += NumberToString;

            var input = File.ReadAllText("input.txt");
            // var output = parser.WordsToNumberInText("Пять");
            // output = parser.WordsToNumberInText(".Пятьсот.");
            // output = parser.WordsToNumberInText("четыреста сорок .пять");
            // output = parser.WordsToNumberInText("четыреста сорок пять.");
            // output = parser.WordsToNumberInText(".пять");
            // output = parser.WordsToNumberInText("пять.");
            // output = parser.WordsToNumberInText(".Пятьсот двадцать пять тысяч триста сорок семь.");
            // output = parser.WordsToNumberInText("два, четыре, сорок восемь");
            // output = parser.WordsToNumberInText("Сколько солдат там было? пять? Пятьдесят? Пятьсот?");
            // output = parser.WordsToNumberInText("Пятьдесят пять- много это или мало?");
             var output = parser.WordsToNumberInText(input);
            File.WriteAllText("output.txt", output);
        }

        static string NumberToString(BigInteger number)
        {
            return number.ToString("N0");
        }
    }
}
