# WordsToNumber

[![Build Status](https://travis-ci.com/RomanSoloweow/WordsToNumber.svg?branch=master)](https://travis-ci.com/RomanSoloweow/WordsToNumber)

Allows you to find in the text and replace numbers written in words, numbers written in digits for Russian locale:

```C#
var parser = new WordsToNumber();

var result = parser.WordsToNumberInText("Пятьюстами пятью миллионами оплатил дом, " +
                                   "который стоил на триста шестьдесят семь тысяч дешевле. " +
                                   "В итоге семьдесят два года и ещё двести пять лет мучений ста " +
                                   "одиннадцати тысяч фиолетовых оленей");
                                   
//505 000 000 оплатил дом, который стоил на 367 000 дешевле. В итоге 72 года и ещё 205 лет мучений 111 000 фиолетовых оленей     

```


