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
            var x = await myAnimeList.GetAnimeCoverAsync("Dragon ball");

            //Assert
            Assert.True(x.Count() > 1);

            output.WriteLine(string.Join("\n", x.ToArray()));
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

            output.WriteLine(string.Join("\n",x.ToArray()));

        }
    }
}