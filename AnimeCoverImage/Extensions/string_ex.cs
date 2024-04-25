using System.Text.RegularExpressions;


namespace AnimeCoverImage.string_ex
{
    public static class string_ex
    {

        public static List<string> Between(this string x, string from, string to)
        {
            return StringBetween(x, from, to);
        }

        public static string BeetweenReplace(this string x, string from, string to, string replacewith = "")
        {
            string ret = x;
            x.Between(from, to).ForEach((rep) => { ret = ret.Replace(from + rep + to, replacewith); });
            return ret;
        }

        public static List<string> StringBetween(string inputstring, string from, string to)
        {
            List<string> ret = new List<string>();
            string pattern = "(?si)" + Regex.Escape(from) + "(.*?)" + Regex.Escape(to);

            MatchCollection matches = Regex.Matches(inputstring, pattern);
            foreach (Match match in matches)
            {
                ret.Add(match.Value.Substring(from.Length, match.Length - to.Length - from.Length));
            }
            return ret;
        }

       public static string RemoveControlCharacters(this string input)
        {
            // Ersetze alle Zeilenumbruch- und Steuerzeichen durch Leerzeichen
            string cleaned = Regex.Replace(input, @"[\p{C}&&[^\r\n\t]]", " ");

            // Ersetze aufeinanderfolgende Leerzeichen durch ein einzelnes Leerzeichen
            cleaned = Regex.Replace(cleaned, @"\s+", " ");

            // Entferne Leerzeichen am Anfang und Ende des bereinigten Strings
            cleaned = cleaned.Trim();

            return cleaned;
        }

    }
}
