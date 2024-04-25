namespace AnimeCoverImage.Services
{
    public  interface IAnimeCoverImage
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">Animename</param>
        /// <returns>Picture Url</returns>
        public Task<string> GetAnimeCoverAsync(string name);
    }
}
