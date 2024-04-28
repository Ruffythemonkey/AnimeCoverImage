using AnimeCoverImage.Services;
using System.Diagnostics;
using Xunit.Abstractions;

namespace UnitTest
{
    public class ServicesTest
    {
        private readonly ITestOutputHelper output;

        public ServicesTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public async void MyAnimeListTest()
        {
            //Arrange
            IAnimeCoverImage myAnimeList = new MyAnimeListCom();

            //Act
            var x = await myAnimeList.GetAnimeCoverAsync("Dragonball Z");

            //Assert
            Assert.True(x.Count() > 1);

            output.WriteLine(x.First().Value);
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
            output.WriteLine(x.First().Value);

        }
    }
}