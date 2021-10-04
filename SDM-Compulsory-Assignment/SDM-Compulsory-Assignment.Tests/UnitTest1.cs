using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using SDM_Compulsory_Assignment.Core.Models;
using SDM_Compulsory_Assignment.Domain.IRepositories;
using SDM_Compulsory_Assignment.Domain.Services;
using SDM_Compulsory_Assignment.Infrastructure.Data.Repositories;
using Xunit;

namespace SDM_Compulsory_Assignment.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TestNumberOfReviewsFromReviewer()
        {
            Mock<IDataCRUD> reviewMock = new Mock<IDataCRUD>();
            var reviewService = new ReviewService(reviewMock.Object);
            var reviews = new List<Review>()
                //Arrange
                {
                    new Review() {Reviewer = 2, Grade = 4, Movie = 666, ReviewDate = DateTime.Now},
                    new Review() {Reviewer = 5, Grade = 4, Movie = 666, ReviewDate = DateTime.Now}
                };
            reviewMock.Setup(m => m.ReadALl()).Returns(() => reviews);
            //Act
            int actualResult = reviewService.GetNumberOfReviewsFromReviewer(5);
            reviewMock.Verify(x => x.ReadALl(), Times.Once);
            var expectedResult = 1;
            //Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void TestAverageRateFromReviewer()
        {
            Mock<IDataCRUD> reviewMock = new Mock<IDataCRUD>();
            var reviewService = new ReviewService(reviewMock.Object);
            var reviews = new List<Review>()
                //Arrange
                {
                    new Review() {Reviewer = 2, Grade = 4, Movie = 666, ReviewDate = DateTime.Now},
                    new Review() {Reviewer = 5, Grade = 4, Movie = 666, ReviewDate = DateTime.Now},
                    new Review() {Reviewer = 5, Grade = 3, Movie = 668, ReviewDate = DateTime.Now}
                };
            reviewMock.Setup(m => m.ReadALl()).Returns(() => reviews);
            double actualResult = reviewService.GetAverageRateFromReviewer(5);
            double expectedResult = 3.5;
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void TestNumberOfRatesFromReviewer()
        {
            Mock<IDataCRUD> reviewMock = new Mock<IDataCRUD>();
            var reviewService = new ReviewService(reviewMock.Object);
            var reviews = new List<Review>()
                //Arrange
                {
                    new Review() {Reviewer = 2, Grade = 4, Movie = 666, ReviewDate = DateTime.Now},
                    new Review() {Reviewer = 5, Grade = 4, Movie = 666, ReviewDate = DateTime.Now},
                    new Review() {Reviewer = 5, Grade = 3, Movie = 668, ReviewDate = DateTime.Now}
                };
            reviewMock.Setup(m => m.ReadALl()).Returns(() => reviews);
            var actualResult = reviewService.GetNumberOfRatesByReviewer(5, 3);
            var expectedResult = 1;
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void TestNumberOfReviewsOnMovie()
        {
            Mock<IDataCRUD> reviewMock = new Mock<IDataCRUD>();
            var reviewService = new ReviewService(reviewMock.Object);
            var reviews = new List<Review>()
                //Arrange
                {
                    new Review() {Reviewer = 2, Grade = 4, Movie = 666, ReviewDate = DateTime.Now},
                    new Review() {Reviewer = 5, Grade = 4, Movie = 666, ReviewDate = DateTime.Now},
                    new Review() {Reviewer = 5, Grade = 3, Movie = 668, ReviewDate = DateTime.Now}
                };
            reviewMock.Setup(m => m.ReadALl()).Returns(() => reviews);

            int actualResult = reviewService.GetNumberOfReviews(666);
            int expectedResult = 2;
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void TestAverageRateOfMovie()
        {
            Mock<IDataCRUD> reviewMock = new Mock<IDataCRUD>();
            var reviewService = new ReviewService(reviewMock.Object);
            var reviews = new List<Review>()
                //Arrange
                {
                    new Review() {Reviewer = 2, Grade = 4, Movie = 666, ReviewDate = DateTime.Now},
                    new Review() {Reviewer = 5, Grade = 4, Movie = 666, ReviewDate = DateTime.Now},
                    new Review() {Reviewer = 5, Grade = 3, Movie = 668, ReviewDate = DateTime.Now}
                };
            reviewMock.Setup(m => m.ReadALl()).Returns(() => reviews);

            double actualResult = reviewService.GetAverageRateOfMovie(666);
            double expectedResult = 4;
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void TestNumberOfRatingOnMovie()
        {
            Mock<IDataCRUD> reviewMock = new Mock<IDataCRUD>();
            var reviewService = new ReviewService(reviewMock.Object);
            var reviews = new List<Review>()
                //Arrange
                {
                    new Review() {Reviewer = 2, Grade = 4, Movie = 666, ReviewDate = DateTime.Now},
                    new Review() {Reviewer = 5, Grade = 4, Movie = 666, ReviewDate = DateTime.Now},
                    new Review() {Reviewer = 5, Grade = 3, Movie = 668, ReviewDate = DateTime.Now}
                };
            reviewMock.Setup(m => m.ReadALl()).Returns(() => reviews);

            int actualResult = reviewService.GetNumberOfRates(666, 4);
            int expectedResult = 2;
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void TestMoviesWithHighestNumberOfTopRates()
        {
            Mock<IDataCRUD> reviewMock = new Mock<IDataCRUD>();
            var reviewService = new ReviewService(reviewMock.Object);
            var reviews = new List<Review>()
                //Arrange
                {
                    new Review() {Reviewer = 2, Grade = 4, Movie = 666, ReviewDate = DateTime.Now},
                    new Review() {Reviewer = 5, Grade = 4, Movie = 666, ReviewDate = DateTime.Now},
                    new Review() {Reviewer = 4, Grade = 5, Movie = 628, ReviewDate = DateTime.Now},
                    new Review() {Reviewer = 5, Grade = 3, Movie = 668, ReviewDate = DateTime.Now},
                    new Review() {Reviewer = 3, Grade = 3, Movie = 668, ReviewDate = DateTime.Now},
                    new Review() {Reviewer = 5, Grade = 5, Movie = 618, ReviewDate = DateTime.Now}
                };
            reviewMock.Setup(m => m.ReadALl()).Returns(() => reviews);

            var actualResult = reviewService.GetMostProductiveReviewers().Count;
            var expectedResult = 1;
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void TestMostProductiveReviewer()
        {
            Mock<IDataCRUD> reviewMock = new Mock<IDataCRUD>();
            var reviewService = new ReviewService(reviewMock.Object);
            var reviews = new List<Review>()
                //Arrange
                {
                    new Review() {Reviewer = 4, Grade = 4, Movie = 666, ReviewDate = DateTime.Now},
                    new Review() {Reviewer = 5, Grade = 4, Movie = 666, ReviewDate = DateTime.Now},
                    new Review() {Reviewer = 4, Grade = 5, Movie = 628, ReviewDate = DateTime.Now},
                    new Review() {Reviewer = 5, Grade = 3, Movie = 668, ReviewDate = DateTime.Now},
                    new Review() {Reviewer = 4, Grade = 3, Movie = 668, ReviewDate = DateTime.Now},
                    new Review() {Reviewer = 5, Grade = 5, Movie = 618, ReviewDate = DateTime.Now}
                };
            reviewMock.Setup(m => m.ReadALl()).Returns(() => reviews);

            var actualResult = reviewService.GetMoviesWithHighestNumberOfTopRates().Count;
            var expectedResult = 2;
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void TestTopRatedMovies()
        {
            Mock<IDataCRUD> reviewMock = new Mock<IDataCRUD>();
            var reviewService = new ReviewService(reviewMock.Object);
            var reviews = new List<Review>()
                //Arrange
                {
                    new Review() {Reviewer = 4, Grade = 4, Movie = 666, ReviewDate = DateTime.Now},
                    new Review() {Reviewer = 5, Grade = 4, Movie = 666, ReviewDate = DateTime.Now},
                    new Review() {Reviewer = 4, Grade = 5, Movie = 628, ReviewDate = DateTime.Now},
                    new Review() {Reviewer = 4, Grade = 2, Movie = 628, ReviewDate = DateTime.Now},
                    new Review() {Reviewer = 5, Grade = 3, Movie = 668, ReviewDate = DateTime.Now},
                    new Review() {Reviewer = 4, Grade = 3, Movie = 668, ReviewDate = DateTime.Now},
                    new Review() {Reviewer = 5, Grade = 5, Movie = 618, ReviewDate = DateTime.Now}
                };
            reviewMock.Setup(m => m.ReadALl()).Returns(() => reviews);

            var testList = reviewService.GetTopRatedMovies(2);
            var actualResult = testList[0];
            var expectedResult = 618;
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void TestTopMoviesByReviewer()
        {
            Mock<IDataCRUD> reviewMock = new Mock<IDataCRUD>();
            var reviewService = new ReviewService(reviewMock.Object);
            var reviews = new List<Review>()
                //Arrange
                {
                    new Review() {Reviewer = 4, Grade = 4, Movie = 666, ReviewDate = DateTime.Now},
                    new Review() {Reviewer = 5, Grade = 4, Movie = 666, ReviewDate = DateTime.Now},
                    new Review() {Reviewer = 4, Grade = 5, Movie = 625, ReviewDate = DateTime.Now},
                    new Review() {Reviewer = 4, Grade = 2, Movie = 628, ReviewDate = DateTime.Now},
                    new Review() {Reviewer = 5, Grade = 3, Movie = 668, ReviewDate = DateTime.Now},
                    new Review() {Reviewer = 4, Grade = 3, Movie = 668, ReviewDate = DateTime.Now},
                    new Review() {Reviewer = 5, Grade = 5, Movie = 618, ReviewDate = DateTime.Now}
                };
            reviewMock.Setup(m => m.ReadALl()).Returns(() => reviews);

            var actualResult = reviewService.GetTopMoviesByReviewer(5).Count;
            var expectedResult = 3;
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void TestReviewersByMovie()
        {
            Mock<IDataCRUD> reviewMock = new Mock<IDataCRUD>();
            var reviewService = new ReviewService(reviewMock.Object);
            var reviews = new List<Review>()
                //Arrange
                {
                    new Review() {Reviewer = 4, Grade = 4, Movie = 666, ReviewDate = DateTime.Now},
                    new Review() {Reviewer = 5, Grade = 4, Movie = 666, ReviewDate = DateTime.Now},
                    new Review() {Reviewer = 4, Grade = 5, Movie = 625, ReviewDate = DateTime.Now},
                    new Review() {Reviewer = 4, Grade = 2, Movie = 628, ReviewDate = DateTime.Now},
                    new Review() {Reviewer = 5, Grade = 3, Movie = 668, ReviewDate = DateTime.Now},
                    new Review() {Reviewer = 4, Grade = 3, Movie = 668, ReviewDate = DateTime.Now},
                    new Review() {Reviewer = 5, Grade = 5, Movie = 618, ReviewDate = DateTime.Now}
                };
            reviewMock.Setup(m => m.ReadALl()).Returns(() => reviews);

            var actualResult = reviewService.GetReviewersByMovie(668).Count;
            var expectedResult = 2;
            Assert.Equal(expectedResult, actualResult);
        }
    }
}