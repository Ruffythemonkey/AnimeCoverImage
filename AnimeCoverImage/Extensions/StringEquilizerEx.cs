namespace AnimeCoverImage.Extensions
{
    static class StringEquilizerEx
    {
        static public string Stringequalizer(this string value) => String.Concat(value.ToLower().Where(c => !Char.IsWhiteSpace(c)));

    }
}
