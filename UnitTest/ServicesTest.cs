using AnimeCoverImage.Services;
using System.Diagnostics;

namespace UnitTest
{
    public class ServicesTest
    {
        [Fact]
        public async void MyAnimeListTest()
        {
            //Arrange
            IAnimeCoverImage myAnimeList = new MyAnimeListCom();

            //Act
            var x = await myAnimeList.GetAnimeCoverAsync("Dragonball");

            //Assert
            Assert.Equal("https://cdn.myanimelist.net/images/anime/1887/92364.jpg", x);

        }

        [Fact]
        public async void AniListCoTest()
        {
            //Arange
            IAnimeCoverImage AniList = new AniListCo();

            //Act
            var x = await AniList.GetAnimeCoverAsync("Dragonball");

            //Assert
            Assert.Equal("https://s4.anilist.co/file/anilistcdn/media/anime/cover/large/bx223-Ld6vrSnd081L.png", x);
        }
    }
}