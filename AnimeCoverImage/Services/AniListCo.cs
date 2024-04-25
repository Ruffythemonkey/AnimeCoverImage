using System.Net.Http.Json;
using System.Text.Json.Nodes;
using System.Text.Json;
using AnimeCoverImage.string_ex;
using Microsoft.Net.Http.Headers;

namespace AnimeCoverImage.Services
{
    public class AniListCo : IAnimeCoverImage
    {
        private string csrfToken = default!;
        private DateTime tokenUpdateTime = default!;
        private IEnumerable<string> cookie;

        public async Task<string> GetAnimeCoverAsync(string name)
        {
            try
            {
                //check is Token Elapsed
                if (IsTokenElapsed()) { await getToken(); }
                if (IsTokenElapsed())
                    return string.Empty;

                using var client = new HttpClient();

                //Set aktuall Token
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("x-csrf-token", csrfToken);
                client.DefaultRequestHeaders.Add(HeaderNames.Cookie, cookie);
                client.DefaultRequestHeaders.Accept.Add(new("application/json"));
            
                //Create body
                var variables = new Models.AniList.Variables() { search = name };
                var body = new Models.AniList.Root() { variables = variables };

                //Post Message
                var ret = await client.PostAsJsonAsync("https://anilist.co/graphql", body);
                if (ret.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var s = await ret.Content.ReadAsStringAsync();
                    return Converter(s, name);
                }
            }
            catch (Exception)
            {

                //Hier könnte der log stehen
            }


            return string.Empty;
        }


        private string Converter(string s, string nameOfAnime)
        {
            var json = JsonNode.Parse(s);

            var ret = json["data"]?["Page"]?["media"]
                .AsArray()
                .Select(item => new KeyValuePair<string, string>(
                    item["title"]?["userPreferred"].ToString(),
                    item["coverImage"]?["large"].ToString()))
                .ToList();

            //Wenn der Animename als solches anders benannt ist siehe "The Apothecary Diaries"
            if (!ret.Any(x => x.Key == nameOfAnime))
            {
                ret.Insert(0, new KeyValuePair<string, string>(nameOfAnime, ret.FirstOrDefault().Value));
                //ret.Add(new KeyValuePair<string, string>(nameOfAnime, ret.FirstOrDefault().Value));
            }
            return JsonSerializer.Serialize(ret);
        }

        private async Task getToken()
        {
            using var client = new HttpClient();
            var t = await client.GetAsync("https://anilist.co");
            t.EnsureSuccessStatusCode();

            cookie = t.Headers.GetValues(HeaderNames.SetCookie);

            var s = await t.Content.ReadAsStringAsync();

            csrfToken = s.Between("window.al_token = \"", "\"")[0];
            tokenUpdateTime = DateTime.Now;
        }

        private bool IsTokenElapsed()
        {
            return tokenUpdateTime == default ||
                   csrfToken == default ||
                   DateTime.Now.Subtract(tokenUpdateTime).Minutes > 1;
        }


    }
}
