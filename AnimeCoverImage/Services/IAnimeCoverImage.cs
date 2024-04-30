namespace AnimeCoverImage.Services
{
    public interface IAnimeCoverImage
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">Animename</param>
        /// <returns>Picture Url</returns>
        public Task<Dictionary<string, string>> GetAnimeCoverAsync(string name);
    }
}
