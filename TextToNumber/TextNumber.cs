using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace TextToNumber
{
    public class TextNumber
    {
        private Dictionary<int, string> Declinations { get; } = new()
        {
            {1, @"одн(ого|ому|им|ом|ой|ою|их|ими|им|и|а|о|у)"},
            {2, @"дв(ух|умя|ум|а)"},
            {3, @"тр(ех|емя|ем|и)"},
            {4, @"четыр(ех|ем|ьмя|е)"},
            {5, @"пят(и|ью|ь)"},
            {6, @"шест(и|ью|ь)"},
            {7, @"сем(и|ью|ь)"},
            {8, @"вос(емью|ьми|емь)"},
            {9, @"девят(и|ью|ь)"},
            {10, @"десят(и|ью|ь)"},
            {11, @"одиннадцат(и|ью|ь)"},
            {12, @"двенадцат(и|ью|ь)"},
            {13, @"тринадцат(и|ью|ь)"},
            {14, @"четырнадцат(и|ью|ь)"},
            {15, @"пятнадцат(и|ью|ь)"},
            {16, @"шестнадцат(и|ью|ь)"},
            {17, @"семнадцат(и|ью|ь)"},
            {18, @"восемнадцат(и|ью|ь)"},
            {19, @"девятнадцат(и|ью|ь)"},
            {20, @"двадцат(и|ью|ь)"},
            {30, @"тридцат(и|ью|ь)"},
            {40, @"сорок(а)?"},
            {50, @"пят(ьдесят|идесяти|ьюдесятью)"},
            {60, @"шест(ьдесят|идесяти|ьюдесятью)"},
            {70, @"сем(ьдесят|идесяти|ьюдесятью)"},
            {80, @"вос(емьдесят|ьмидесяти|ьмьюдесятью)"},
            {90, @"девяност(а|о)"},
            {100, @"ст(а|о)"},
            {200, @"дв(ести|ухсот|умстам|умястами|ухстах)"},
            {300, @"тр(иста|ёхсот|ёмстам|емястами)"},
            {400, @"четыр(еста|ёхсот|ёмстам|ьмястами|ёхстах)"},
            {500, @"пят(ьсот|исот|истам|ьюстами|истах)"},
            {600, @"шест(ьсот|исот|истам|ьюстами|истах)"},
            {700, @"сем(ьсот|исот|истам|ьюстами|истах)"},
            {800, @"вос(емьсот|ьмисот|ьмистам|емьсот|емьюстами|ьмистах)"},
            {900, @"девят(ьсот|исот|истам|ьюстами|истах)"},
            {1000, @"тысяч(ами|ей|а|и|е|у)?"},
            {1000000, @"миллион(ами|а|у|ом|е|ов)?"},
            // {1000000000, @"миллиард(ами|а|у|ом|е|ов)?"},
            // {1000000000000, @"триллион(а|у|ом|ов)?"},
            // {1000000000000000, @"миллиард(а|у|ом|ов)?"},
        };

        private Regex NumberRegex = new Regex(@"\d+(\.\d+)?", RegexOptions.Compiled);


        public string TextWordsToNumber(string text)
        {
            text = text.ToLower();

            foreach (var declination in Declinations.Reverse())
            {
                text = Regex.Replace(text, @"(?<=([\s,.:;]|^))" + declination.Value + @"(?=([\s,.:;]|$))", declination.Key.ToString());
            }
            
            var words = text.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            List<string> result = new();
            List<string> buffer = new(); 
            foreach (var word in words)
            {
                if (!NumberRegex.IsMatch(word))
                {
                    if (buffer.Count < 2)
                    {
                        result.AddRange(buffer);
                        buffer.Clear();
                    }
                    else
                    {
                        result.Add(WordsToNumber(buffer).ToString());
                        buffer.Clear();
                    }
                    
                    result.Add(word);
                }
                else
                {
                    buffer.Add(word);
                }
            }

            if (buffer.Count <2)
            {
                result.AddRange(buffer);
                buffer.Clear();
            }
            else
            {
                result.Add(WordsToNumber(buffer).ToString());
                buffer.Clear();
            }
            
            return string.Join(" ", result);
        }
        
        private int WordsToNumber(List<string> words)
        {
            var numbers = words.Select(int.Parse).ToArray();
            int result = 0;
            List<int> numbers2 = new ();
            for (int i = 0; i < numbers.Length; i++)
            {
                var temp = numbers[i];
                while (i < numbers.Length-1 && numbers[i] > numbers[i + 1])
                {
                    temp+=numbers[i+1];
                    i++;
                }
                
                if (temp!=numbers[i])
                {
                  numbers2.Add(temp);
                }
                else
                {
                    numbers2.Add(numbers[i]); 
                }
            }
            
            for (int i = 0; i < numbers2.Count; i++)
            {
                if (i < numbers2.Count-1 && numbers2[i] < numbers2[i + 1])
                {
                    result += numbers2[i] * numbers2[i + 1];
                    i++;
                }
                else
                {
                    result += numbers2[i];
                }
            }

            return result;
        }
    }
}
