using System.Net.Http.Json;
using System.Text.Json.Nodes;
using AnimeCoverImage.Extensions;
using AnimeCoverImage.StringBetweenEx;
using Microsoft.Net.Http.Headers;

namespace AnimeCoverImage.Services
{
    public class AniListCo : IAnimeCoverImage
    {
        private string csrfToken = default!;
        private DateTime tokenUpdateTime = default!;
        private IEnumerable<string> cookie;

        public async Task<Dictionary<string, string>> GetAnimeCoverAsync(string name)
        {

            //check is Token Elapsed
            if (IsTokenElapsed()) { await getToken(); }
            if (IsTokenElapsed())
                throw new("token required");

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
            ret.EnsureSuccessStatusCode();

            var content = await ret.Content.ReadAsStringAsync();
            var sid = Converter(content, name).SortDict(name);
            return sid;

        }


        private Dictionary<string, string> Converter(string s, string nameOfAnime)
        {
            var json = JsonNode.Parse(s);

            return json["data"]?["Page"]?["media"]
                .AsArray()
                .Select(item => new KeyValuePair<string, string>(
                    item["title"]?["userPreferred"].ToString(),
                    item["coverImage"]?["large"].ToString()))
                .ToDictionary();
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
