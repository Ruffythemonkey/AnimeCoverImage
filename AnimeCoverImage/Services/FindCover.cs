namespace AnimeCoverImage.Services
{
    public class FindCover : IAnimeCoverImage
    {
        public async Task<Dictionary<string, string>> GetAnimeCoverAsync(string name)
        {
            //myanimelist first
            try
            {
                var x = new MyAnimeListCom();
                return await x.GetAnimeCoverAsync(name);
            }
            catch (Exception)
            {  
            }

            //Anilistco 2end
            try
            {
                var x = new AniListCo();
                return await x.GetAnimeCoverAsync(name);
            }
            catch (Exception)
            {
            }

            throw new Exception("no cover found");
        }
    }
}
