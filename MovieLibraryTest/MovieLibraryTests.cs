using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieLibrary.Controllers;
using MovieLibrary.Models;

namespace MovieLibraryTest
{
    [TestClass]
    public class MovieLibraryTests
    {
        private readonly MovieController movieController = new MovieController();
        [TestMethod]
        public void GetMovieByIdTest()
        {
            //Arrange
            var expected = new Movie
            {
                id = "tt0108052",
                title = "Schindler's List",
                rated = "8.9"
            };

            //Act
            var actual = movieController.GetMovieById("tt0108052");

            //Assert
            Assert.AreEqual(expected.title, actual.title);
        }
    }
}
