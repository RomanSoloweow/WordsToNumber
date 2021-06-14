using System.IO;
using System.Collections.Generic;
using System.Numerics;
using Xunit;

namespace WordsToNumber.Tests.Examples
{
    public class Examples
    {
        // [Fact]
        // public void VerseTest()
        // {
        //     var parser = new WordsToNumbers.WordsToNumber();
        //     
        //     var input = File.ReadAllText( @"Examples/VerseInput.txt");
        //     var output = File.ReadAllText(@"Examples/VerseOutput.txt");
        //     
        //     var result = parser.WordsToNumberInText(input);
        //     
        //     Assert.Equal(output, result);
        // }
        //
        // [Fact]
        // public void TextTest()
        // {
        //     var parser = new WordsToNumbers.WordsToNumber();
        //     parser.NumberToString += NumberToString;
        //     
        //     var input = File.ReadAllText( @"Examples/TextInput.txt");
        //     var output = File.ReadAllText(@"Examples/TextOutput.txt");
        //     
        //     var result = parser.WordsToNumberInText(input);
        //     
        //     Assert.Equal(output, result);
        // }
        
        static string NumberToString(BigInteger number)
        {
            return number.ToString("N0");
        }
    }
}