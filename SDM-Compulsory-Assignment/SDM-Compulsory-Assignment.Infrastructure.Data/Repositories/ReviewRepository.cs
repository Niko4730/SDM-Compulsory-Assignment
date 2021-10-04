using System.Collections.Generic;
using System.Linq;
using SDM_Compulsory_Assignment.Core.Models;
using SDM_Compulsory_Assignment.Domain.IRepositories;

namespace SDM_Compulsory_Assignment.Infrastructure.Data.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        public int GetNumberOfReviewsFromReviewer(int reviewer)
        {
            return ReviewMock.ReviewsList.FindAll(x => x.Reviewer == reviewer).Count;
        }

        public double GetAverageRateFromReviewer(int reviewer)
        {
            var totalReviews = ReviewMock.ReviewsList.FindAll(x => x.Reviewer == reviewer).ToList();
            double totalScore = 0;
            totalReviews.ForEach((review) => totalScore += review.Grade);
            return totalScore / totalReviews.Count;
        }

        public int GetNumberOfRatesByReviewer(int reviewer, int rate)
        {
            throw new System.NotImplementedException();
        }

        public int GetNumberOfReviews(int movie)
        {
            throw new System.NotImplementedException();
        }

        public double GetAverageRateOfMovie(int movie)
        {
            throw new System.NotImplementedException();
        }

        public int GetNumberOfRates(int movie, int rate)
        {
            throw new System.NotImplementedException();
        }

        public List<int> GetMoviesWithHighestNumberOfTopRates()
        {
            throw new System.NotImplementedException();
        }

        public List<int> GetMostProductiveReviewers()
        {
            throw new System.NotImplementedException();
        }

        public List<int> GetTopRatedMovies(int amount)
        {
            throw new System.NotImplementedException();
        }

        public List<int> GetTopMoviesByReviewer(int reviewer)
        {
            throw new System.NotImplementedException();
        }

        public List<int> GetReviewersByMovie(int movie)
        {
            throw new System.NotImplementedException();
        }
    }
}