using System;
using TextToNumber;

namespace Sandbox
{
    class TextToNumber
    {
        static void Main(string[] args)
        {
            var parser = new TextNumber();
            var result = parser.TextWordsToNumber("пятьюстами пятью миллионами оплатил дом, который стоил" +
                                                  " на триста шестьдесят семь тысяч дешевле");
            result = parser.TextWordsToNumber("семьдесят два года и ещё двести пять лет мучений");
            result = parser.TextWordsToNumber("сто одиннадцать тысяч фиолетовых оленей");
        }
    }
}
