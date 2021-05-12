using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using TextToNumber.Helper;

namespace WordsToNumbers
{
    public class WordsToNumber
    {
        /// <summary>
        /// Delegate to format numbers before adding to text
        /// </summary>
        public Func<BigInteger , string> NumberToString;
        public Dictionary<BigInteger , string> Declinations { get; } = new()
        {
            {1, @"од(ного|ному|ним|ном|ной|ною|них|ними|ин|ним|ни|на|но|ну)"},
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
            {1000000000, @"миллиард(ами|а|у|ом|е|ов)?"},
            {1000000000000, @"триллион(ами|а|у|ом|ов)?"},
            {1000000000000000, @"триллиард(ами|а|у|ом|ов)?"}
        };

        public string WordsToNumberInText(string text)
        {
            text = NumbersToInfinitive(text);
            return MergeInfinitiveWordsInText(text);
            
            var words = text.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            
            words = MergeInfinitiveWordsInText(words);
          
            return string.Join(" ", words);
        }

        public string NumbersToInfinitive(string text)
        {
            
            foreach (var declination in Declinations.Reverse())
            {
                // text = Regex.Replace(text, @"(?<=([\s,.:;]|^))" + declination.Value + @"(?=([\s,.:;]|$))", declination.Key.ToString(), RegexOptions.IgnoreCase);
                text = Regex.Replace(text, @"(?<=([^а-яА-Я]|^))" + declination.Value + @"(?=([^а-яА-Я]|$))", declination.Key.ToString(), RegexOptions.IgnoreCase);
            }

            return text;
        }
        
        public BigInteger InfinitiveNumbersToNumber(List<string> words)
        {
            var numbers = words.Select(ulong.Parse).ToArray();
            BigInteger  result = 0;
            List<BigInteger > numbers2 = new ();
            
            //adding numbers 200 + 30 + 5 = 235
            for (int i = 0; i < numbers.Length; i++)
            {
                var temp = numbers[i];
                while (i < numbers.Length-1 
                       && numbers[i] > numbers[i + 1] 
                       && numbers[i] < 1000)
                {
                    temp+=numbers[i+1];
                    i++;
                }

                numbers2.Add(temp);
            }
            
            //235 1000 577 = 235000 + 577 = 235577
            for (int i = 0; i < numbers2.Count; i++)
            {
                if (i < numbers2.Count - 1 && numbers2[i] < numbers2[i + 1])
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

        private List<string> MergeInfinitiveWordsInText(List<string> words)
        {
            List<string> result = new();
            if (!words.Any())
                return result;
            
            List<string> buffer = new();

            for (int i = 0; i < words.Count; i++)
            {
                var currentWord = words[i];
                string prefix = string.Empty;
                string postfix = string.Empty;
                
                var match = Regex.Matches(words[i], @"^(\W|\s)?(\d+)(\W|\s)?$").GetTheLongest();
                var currentNumber = new NumberMatch(match);
                
                if (currentNumber.IsNumber)
                {
                    prefix = currentNumber.Prefix;
                    buffer.Add(currentNumber.Value);
                    postfix = currentNumber.Postfix;
               

                    while (i<words.Count-1 && string.IsNullOrEmpty(postfix))
                    {
                        match = Regex.Matches(words[i +1], @"(\W|\s|^)?(\d+)(\W|$|\s)?").GetTheLongest();
                        currentNumber = new NumberMatch(match);
                        
                        if(currentNumber.HasPrefix || !currentNumber.IsNumber)
                            break;
                        
                        buffer.Add(currentNumber.Value);
                        i++;
                        
                        if (currentNumber.HasPostfix)
                        {
                            postfix = currentNumber.Postfix;
                        }
                    }
                }
  
                if (buffer.Any())
                {
                    var number = InfinitiveNumbersToNumber(buffer);
                    buffer.Clear();
                    var numberString = NumberToString == null ? number.ToString() : NumberToString(number);
                    currentWord = prefix + numberString + postfix;
                }
                
                result.Add(currentWord);
            }

            return result;
        }

        public string MergeInfinitiveWordsInText(string text)
        { 
            var result = text;
            int offset = 0;
            var matches =  Regex.Matches(text, @"(?<=([^а-яА-Я]|\s|^))(\d+)(?=([^а-яА-Я]|\s|$))");
          List<Match> buffer = new();
          
          for(int i=0; i<matches.Count;i++)
          {
              buffer.Add(matches[i]);
              while (i < matches.Count-1 && 
                     string.IsNullOrWhiteSpace(GetMatchesInterval(text, matches[i], matches[i + 1]))
              )
              {
                buffer.Add(matches[i +1]);
                i++;
              }

              if (buffer.Count > 1)
              {
                  var number = InfinitiveNumbersToNumber(buffer.Select(x=>x.Value).ToList());
                  var numberString = NumberToString == null ? number.ToString() : NumberToString(number);
                  var startIndex = buffer.First().Index;
                  var lenght = buffer.Last().Index - startIndex + buffer.Last().Length;
                  
                  result = result.Remove(startIndex - offset, lenght);
                  result = result.Insert(buffer.First().Index - offset, numberString);
                  offset += lenght - numberString.Length;
              }
              
              buffer.Clear();
          }
          return result;
        }

        private string GetMatchesInterval(string text, Match left, Match right)
        {
            var intervalStart = left.Index + left.Length ;
            var intervalLenght = right.Index - intervalStart;
            var result = text.Substring(intervalStart, intervalLenght);
            return result;
        }
    }
}
