namespace AnimeCoverImage.Extensions
{
    static class StringEquilizerEx
    {
        /// <summary>
        /// Delete Whitespaces and make the string ToLower
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        static public string Stringequalizer(this string value) => String.Concat(value.ToLower().Where(c => !Char.IsWhiteSpace(c)));

    }
}
