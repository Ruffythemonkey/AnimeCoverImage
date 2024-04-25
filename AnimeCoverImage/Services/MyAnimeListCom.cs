using HtmlAgilityPack;
using System.Text.Encodings.Web;
using HtmlAgilityPack.Extensions;

namespace AnimeCoverImage.Services
{
    public class MyAnimeListCom : IAnimeCoverImage
    {
        public async Task<string> GetAnimeCoverAsync(string name)
        {
            string t = $"https://myanimelist.net/anime.php?cat=anime&q={UrlEncoder.Default.Encode(name)}&type=0&score=0&status=0&p=0&r=0&sm=0&sd=0&sy=0&em=0&ed=0&ey=0&c%5B%5D=a&c%5B%5D=b&c%5B%5D=c&c%5B%5D=f";

            try
            {

                HtmlWeb source = new HtmlWeb();
                HtmlDocument html = await source.LoadFromWebAsync(t);

                //The HTML Class for the Node
                List<HtmlNode> nodes = html.GetElementsByClassName("picSurround");

                // 0 = name, 1 = Url
                Dictionary<string, string> valuePairs = new();

                foreach (var node in nodes)
                {
                    HtmlNode nhd = node.SelectSingleNode("a").SelectSingleNode("img");
                    //find Name and Image URl of the SourceSite
                    string AnimeName = nhd.Attributes["alt"].Value;
                    string Image = nhd.Attributes["data-src"].Value;
                    valuePairs.Add(AnimeName, Image);
                }


                string s = Comparer(valuePairs, name).Length > 0 ? Comparer(valuePairs, name) : valuePairs.FirstOrDefault().Value ?? "";
                return ConvertUrl(string.IsNullOrEmpty(s) ? valuePairs.First().Value : s);

            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }

        }

        private string ConvertUrl(string url)
        {
            Uri uri = new Uri(url);
            string c = uri.AbsolutePath.Split(@"/images/anime/").Last();
            return $"{uri.Scheme}://{uri.DnsSafeHost}/images/anime/{c}";
        }

        private string Comparer(Dictionary<string, string> valuePairs, string value)
        {
            var normalizedValue = Stringequalizer(value);
            return valuePairs.FirstOrDefault(pair => Stringequalizer(pair.Key) == normalizedValue).Value ?? "";
        }

        private string Stringequalizer(string value) => String.Concat(value.ToLower().Where(c => !Char.IsWhiteSpace(c)));

    }
}
