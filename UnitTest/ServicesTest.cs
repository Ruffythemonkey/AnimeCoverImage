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
            Assert.True(x.Count() > 1);

        }

        [Fact]
        public async void AniListCoTest()
        {
            //Arange
            IAnimeCoverImage AniList = new AniListCo();

            //Act
            var x = await AniList.GetAnimeCoverAsync("Dragonball");

            //Assert
            Assert.True(x.Count() > 1);
        }
    }
}