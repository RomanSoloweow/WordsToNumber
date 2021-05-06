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
        private Dictionary<string, int> Units { get; } = new()
        {
            {"один", 1},
            {"два", 2},
            {"три", 3},
            {"четыре", 4},
            {"пять", 5},
            {"шесть", 6},
            {"семь", 7},
            {"восемь", 8},
            {"девять", 9},
        };
        private Dictionary<string, int> Dozen2 { get; } = new()
        {
            {"десять", 10},
            {"одиннадцать", 11},
            {"двенадцать", 12},
            {"тринадцать", 13},
            {"четырнадцать", 14},
            {"пятнадцать", 15},
            {"шестнадцать", 16},
            {"семнадцать", 17},
            {"восемнадцать", 18},
            {"девятнадцать", 19}
        };
        
        private Dictionary<string, int> Dozens { get; } = new()
        {
            {"двадцать", 20},
            {"тридцать", 30},
            {"сорок", 40},
            {"пятьдесят", 50},
            {"шестьдесят", 60},
            {"семьдесят", 70},
            {"восемьдесят", 80},
            {"девяносто", 90},
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
            var numbers = 
            Regex.Match(text, @"(-)?(один|два|три|четыре|пять|шесть|семь|восемь|девять|десять)")
            return 0;
        }
    }
}
