using System;
using System.IO;
using System.Numerics;
using TextToNumber;
using WordsToNumbers;

namespace Sandbox
{
    class TextToNumber
    {
        static void Main(string[] args)
        {
            var parser = new WordsToNumber();
            parser.NumberToString += NumberToString;
            
            var input = File.ReadAllText("input.txt");
            var output = parser.WordsToNumberInText(input);
            File.WriteAllText("output.txt", output);
        }

        static string NumberToString(BigInteger number)
        {
            return number.ToString("N0");
        }
    }
}
