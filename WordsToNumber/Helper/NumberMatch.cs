using System.Diagnostics.SymbolStore;
using System.Text.RegularExpressions;

namespace TextToNumber.Helper
{
    public class NumberMatch
    {
        public string Prefix { get; }
        public string Postfix { get; }
        public string Value { get; }
        public bool HasPrefix { get; }
        public bool HasPostfix { get; }
        public bool IsNumber { get; }
        public bool IsClearNumber { get; }
        public bool IsSingleNumber { get; }
        public NumberMatch(Match match)
        {
            IsNumber = match is not null;
            Prefix = match?.Groups[1].Value;
            Postfix = match?.Groups[3].Value;
            HasPrefix = !string.IsNullOrEmpty(Prefix);
            HasPostfix = !string.IsNullOrEmpty(Postfix);
            IsClearNumber = IsNumber && !HasPostfix && !HasPrefix;
            IsSingleNumber = IsNumber && HasPostfix && HasPrefix;
            Value = match?.Groups[2].Value;
        }
    }
}