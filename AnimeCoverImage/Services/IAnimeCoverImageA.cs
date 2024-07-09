namespace AnimeCoverImage.Services
{
    public interface IAnimeCoverImageA
    {
        public Task<Dictionary<string,string>> GetImagesAsync(string url);
    }
}
