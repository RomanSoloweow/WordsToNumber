using System;
using TextToNumber;

namespace Sandbox
{
    class TextToNumber
    {
        static void Main(string[] args)
        {
            var parser = new TextNumber();
            
            var t = parser.Parse("две миллионов");
            Console.WriteLine("Hello World!");
        }
    }
}
