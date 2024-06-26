﻿using HtmlAgilityPack;
using System.Text.Encodings.Web;
using HtmlAgilityPack.Extensions;
using AnimeCoverImage.Extensions;

namespace AnimeCoverImage.Services
{
    public class MyAnimeListCom : IAnimeCoverImage
    {
        public async Task<Dictionary<string, string>> GetAnimeCoverAsync(string name)
        {
            string t = $"https://myanimelist.net/anime.php?cat=anime&q={UrlEncoder.Default.Encode(name)}&type=0&score=0&status=0&p=0&r=0&sm=0&sd=0&sy=0&em=0&ed=0&ey=0&c%5B%5D=a&c%5B%5D=b&c%5B%5D=c&c%5B%5D=f";

            HtmlWeb source = new HtmlWeb();
            HtmlDocument html = await source.LoadFromWebAsync(t);

            //The HTML Class for the Node
            List<HtmlNode> nodes = html.GetElementsByClassName("picSurround");

            // 0 = name, 1 = Url
            Dictionary<string, string> dictFind = new();

            foreach (var node in nodes)
            {
                HtmlNode nhd = node.SelectSingleNode("a").SelectSingleNode("img");
                //find Name and Image URl of the SourceSite
                string AnimeName = nhd.Attributes["alt"].Value;
                string Image = ConvertUrl(nhd.Attributes["data-src"].Value);
                dictFind.Add(AnimeName, Image);
            }

            return dictFind.SortDict(name);

        }

        private string ConvertUrl(string url)
        {
            Uri uri = new Uri(url);
            string c = uri.AbsolutePath.Split(@"/images/anime/").Last();
            return $"{uri.Scheme}://{uri.DnsSafeHost}/images/anime/{c}";
        }
    }
}
