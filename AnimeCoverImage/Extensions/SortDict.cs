namespace AnimeCoverImage.Extensions
{
    static class SortDictEx
    {
        public static Dictionary<string, string> SortDict(this Dictionary<string, string> dict, string findvalue)
        {
            var ret = dict.ToList();
            var find = ret.FirstOrDefault(x => x.Key.Stringequalizer() == findvalue.Stringequalizer());
            if (find.Key != null)
            {
                ret.Remove(find);
                ret.Insert(0, find);
            }
            return ret.ToDictionary();
        }
    }
}
