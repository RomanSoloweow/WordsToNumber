using System.Linq;
using System.Text.RegularExpressions;

namespace TextToNumber.Helper
{
    public static class MatchCollectionExpression
    {
        public static Match GetTheLongest(this MatchCollection collection)
        {
          return  collection.OrderByDescending(x => x.Length).FirstOrDefault();
        }
    }
}