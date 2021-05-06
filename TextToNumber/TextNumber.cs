using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TextToNumber
{
    public class TextNumber
    {
        private Dictionary<string, List<string>> MapForReplace { get; } = new()
        {
            { "два", new List<string>(){"две"}},
            { "один", new List<string>(){"одна"}},
            { "тысяча", new List<string>(){"тысяч([а-я])*"}},
            { "миллион", new List<string>(){@"(миллион)([а-я])*"}},
            { "миллиард", new List<string>(){@"(миллиард)([а-я])*"}}
        };
        
        public long Parse(string text)
        {
            text = text.ToLower();
            foreach (var (name, list) in MapForReplace)
            {
                foreach (var value in list)
                {
                    text = Regex.Replace(text, value, name);
                }
            }

            return 0;
        }
    }
}
