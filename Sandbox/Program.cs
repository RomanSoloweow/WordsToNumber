using System;
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

            var result = parser.WordsToNumberInText(
                "Пятьюстами пятью миллионами оплатил дом, который стоил на триста шестьдесят семь тысяч дешевле."
                + " В итоге семьдесят два года и ещё двести пять лет мучений cта одиннадцать тысяч фиолетовых оленей.");
            
        }

        static string NumberToString(BigInteger number)
        {
            return number.ToString("N0");
        }
    }
}
