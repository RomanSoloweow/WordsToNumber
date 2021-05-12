using System;
using System.Collections.Generic;
using Xunit;
using WordsToNumbers;

namespace WordsToNumber.Tests
{
    public class WordsToNumberTests
    {

        static Dictionary<int, string> Units = new Dictionary<int, string>()
        {
            {1, @"один"},
            {2, @"два"},
            {3, @"три"},
            {4, @"четыре"},
            {5, @"пять"},
            {6, @"шесть"},
            {7, @"семь"},
            {8, @"восемь"},
            {9, @"девять"},
        };
        static Dictionary<int, string> Dozens = new Dictionary<int, string>()
        {
            {10, "десять"},
            {20, "двадцать"},
            {30, "тридцать"},
            {40, "сорок"},
            {50, "пятьдесят"},
            {60, "шестьдесят"},
            {70, "семьдесят"},
            {80, "восемьдесят"},
            {90, "девяносто"},
        };
        static Dictionary<int, string> Dozens2 = new Dictionary<int, string>()
        {
            {11, @"одиннадцать"},
            {12, @"двенадцать"},
            {13, @"тринадцать"},
            {14, @"четырнадцать"},
            {15, @"пятнадцать"},
            {16, @"шестнадцать"},
            {17, @"семнадцать"},
            {18, @"восемнадцать"},
            {19, @"девятнадцать"},
        };
        static Dictionary<int, string> Hundreds = new Dictionary<int, string>()
        {
            {100, @"сто"},
            {200, @"двести"},
            {300, @"триста"},
            {400, @"четыреста"},
            {500, @"пятьсот"},
            {600, @"шестьсот"},
            {700, @"семьсот"},
            {800, @"восемьсот"},
            {900, @"девятьсот"},
        };
        
        
        [Fact]
        public void UnitsTest()
        {
            var parser = new WordsToNumbers.WordsToNumber();
            
            foreach (var value in Units)
            {
                var output = parser.WordsToNumberInText(value.Value);   
                Assert.Equal(value.Key.ToString(), output);
            }
           
        }
        
        [Fact]
        public void UnitsWithWordTest()
        {
            var parser = new WordsToNumbers.WordsToNumber();
            var word = " числом";
            foreach (var value in Units)
            {
                var output = parser.WordsToNumberInText(value.Value + word);   
                Assert.Equal(value.Key + word, output);
            }
        }
        
        [Fact]
        public void UnitsBetweenWordsTest()
        {
            var parser = new WordsToNumbers.WordsToNumber();
            var before = "Получается ";
            var after = " ровно";
            foreach (var value in Units)
            {
                var output = parser.WordsToNumberInText($"{before}{value.Value}{after}");   
                Assert.Equal($"{before}{value.Key}{after}", output);
            }
        }
        
        [Fact]
        public void UnitsBetweenSymbolsTest()
        {
            var parser = new WordsToNumbers.WordsToNumber();
            foreach (var value in Units)
            {
                var output = parser.WordsToNumberInText($".{value.Value}.");   
                Assert.Equal($".{value.Key}.", output);
            }
        }
        
        [Fact]
        public void DozensTest()
        {
            var parser = new WordsToNumbers.WordsToNumber();
            
            foreach (var value in Dozens)
            {
                var output = parser.WordsToNumberInText(value.Value);   
                Assert.Equal(value.Key.ToString(), output);
            }
           
        }
        
        [Fact]
        public void DozensWithWordTest()
        {
            var parser = new WordsToNumbers.WordsToNumber();
            var word = " домов";
            foreach (var value in Dozens)
            {
                var output = parser.WordsToNumberInText(value.Value + word);   
                 Assert.Equal(value.Key + word, output);
            }
        }
        
        [Fact]
        public void DozensBetweenWordsTest()
        {
            var parser = new WordsToNumbers.WordsToNumber();
            var before = "Получается ";
            var after = " домов";
            foreach (var value in Dozens)
            {
                var output = parser.WordsToNumberInText($"{before}{value.Value}{after}");   
                Assert.Equal($"{before}{value.Key}{after}", output);
            }
        }
        
        [Fact]
        public void DozensBetweenSymbolsTest()
        {
            var parser = new WordsToNumbers.WordsToNumber();
            foreach (var value in Dozens)
            {
                var output = parser.WordsToNumberInText($".{value.Value}.");   
                Assert.Equal($".{value.Key}.", output);
            }
        }
        
        [Fact]
        public void Dozens2Test()
        {
            var parser = new WordsToNumbers.WordsToNumber();
            
            foreach (var value in Dozens2)
            {
                var output = parser.WordsToNumberInText(value.Value);   
                Assert.Equal(value.Key.ToString(), output);
            }
           
        }
        
        [Fact]
        public void Dozens2WithWordTest()
        {
            var parser = new WordsToNumbers.WordsToNumber();
            var word = " домов";
            foreach (var value in Dozens2)
            {
                var output = parser.WordsToNumberInText(value.Value + word);   
                Assert.Equal(value.Key + word, output);
            }
        }
        
        [Fact]
        public void Dozens2BetweenWordsTest()
        {
            var parser = new WordsToNumbers.WordsToNumber();
            var before = "Получается ";
            var after = " домов";
            foreach (var value in Dozens2)
            {
                var output = parser.WordsToNumberInText($"{before}{value.Value}{after}");   
                Assert.Equal($"{before}{value.Key}{after}", output);
            }
        }
        
        [Fact]
        public void Dozens2BetweenSymbolsTest()
        {
            var parser = new WordsToNumbers.WordsToNumber();
            foreach (var value in Dozens2)
            {
                var output = parser.WordsToNumberInText($".{value.Value}.");   
                Assert.Equal($".{value.Key}.", output);
            }
        }
        
        [Fact]
        public void HundredsTest()
        {
            var parser = new WordsToNumbers.WordsToNumber();
            
            foreach (var value in Hundreds)
            {
                var output = parser.WordsToNumberInText(value.Value);   
                Assert.Equal(value.Key.ToString(), output);
            }
           
        }
        
        [Fact]
        public void HundredsWithWordTest()
        {
            var parser = new WordsToNumbers.WordsToNumber();
            var word = " домов";
            foreach (var value in Hundreds)
            {
                var output = parser.WordsToNumberInText(value.Value + word);   
                Assert.Equal(value.Key + word, output);
            }
        }
        
        [Fact]
        public void HundredsBetweenWordsTest()
        {
            var parser = new WordsToNumbers.WordsToNumber();
            var before = "Получается ";
            var after = " домов";
            foreach (var value in Hundreds)
            {
                var output = parser.WordsToNumberInText($"{before}{value.Value}{after}");   
                Assert.Equal($"{before}{value.Key}{after}", output);
            }
        }
        
        [Fact]
        public void HundredsBetweenSymbolsTest()
        {
            var parser = new WordsToNumbers.WordsToNumber();
            foreach (var value in Hundreds)
            {
                var output = parser.WordsToNumberInText($".{value.Value}.");   
                Assert.Equal($".{value.Key}.", output);
            }
        }

    }
}