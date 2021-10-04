using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using SDM_Compulsory_Assignment.Core;
using SDM_Compulsory_Assignment.Domain.IRepositories;

namespace SDM_Compulsory_Assignment.Domain.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        readonly IDataCRUD _dataCRUD;

        public ReviewService(IDataCRUD dataCRUD)
        {
            _dataCRUD = dataCRUD;
        }

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
            
        public int GetNumberOfReviewsFromReviewer(int reviewer)
        {
            //return _reviewRepository.GetNumberOfReviewsFromReviewer(reviewer);
            return _dataCRUD.ReadALl().ToList().FindAll(r => r.Reviewer == reviewer).Count;
        }

        public double GetAverageRateFromReviewer(int reviewer)
        {
            var totalReviews = _dataCRUD.ReadALl().ToList().FindAll(x => x.Reviewer == reviewer).ToList();
            double totalScore = 0;
            totalReviews.ForEach((review) => totalScore += review.Grade);
            return totalScore / totalReviews.Count;
        }

        public int GetNumberOfRatesByReviewer(int reviewer, int rate)
        {
            return _dataCRUD.ReadALl().ToList().FindAll(r => r.Reviewer == reviewer && r.Grade == rate).Count;
        }

        public int GetNumberOfReviews(int movie)
        {
            return _dataCRUD.ReadALl().ToList().FindAll(m => m.Movie == movie).Count;
        }

        public double GetAverageRateOfMovie(int movie)
        {
            var totalReviews = _dataCRUD.ReadALl().ToList().FindAll(x => x.Movie == movie).ToList();
            double totalScore = 0;
            totalReviews.ForEach((movie) => totalScore += movie.Grade);
            return totalScore / totalReviews.Count;
        }

        public int GetNumberOfRates(int movie, int rate)
        {
            return _dataCRUD.ReadALl().ToList().FindAll(r => r.Movie == movie && r.Grade == rate).Count;
        }

        public List<int> GetMoviesWithHighestNumberOfTopRates()
        {
            List<int> movieIds = new List<int>();
            var topMovies = _dataCRUD.ReadALl().ToList().FindAll(m => m.Grade == 5).OrderBy(m => m.Movie).ToList();
            topMovies.ForEach((m) => movieIds.Add(m.Movie));
            return movieIds;
        }

        public List<int> GetMostProductiveReviewers()
        {
            //Reviewer Id, reviewer amount
            var dict = new Dictionary<int, int>();
            var ids = new List<int>();

            var allReviewers = _dataCRUD.ReadALl().ToList();
            for (int i = 0; i < allReviewers.Count; i++)
            {
                var reviewer = allReviewers[i];
                //check if reviewer id exists, if not add
                if (!dict.ContainsKey(reviewer.Reviewer))
                {   //reviewer id, reviewer amount
                    dict.Add(reviewer.Reviewer, 1);
                }
                else
                {   //reviewer id (key)
                    dict[reviewer.Reviewer]++;
                }
            }

            var highestAmount = dict.Values.Max();
            foreach (var entry in dict)
            {
                if (entry.Value == highestAmount)
                    ids.Add(entry.Key);
            }

            return ids;
        }

        public List<int> GetTopRatedMovies(int amount)
        {
            var averageRates = new Dictionary<int, double>();
            var movies = _dataCRUD.ReadALl().OrderByDescending(x=>x.Grade).ToList();
            int currentAmount = 0;
            for (int i = 0; i < movies.Count; i++)
            {
                var movie = movies[i];
                var averageRating = GetAverageRateOfMovie(movie.Movie);
                if (!averageRates.ContainsKey(movie.Movie) && currentAmount <= amount)
                {
                    currentAmount++;
                    averageRates.Add(movie.Movie, averageRating);
                }
                else break;
            }
            return averageRates.OrderByDescending(x => x.Value).Select(x => x.Key).ToList();
        }

        public List<int> GetTopMoviesByReviewer(int reviewer)
        {
            return _dataCRUD.ReadALl().Where(r => r.Reviewer == reviewer).OrderByDescending(r => r.Grade)
                .ThenByDescending(r => r.ReviewDate).Select(r => r.Movie).ToList();
        }

        public List<int> GetReviewersByMovie(int movie)
        {
            return _dataCRUD.ReadALl().Where(r => r.Movie == movie).OrderByDescending(r => r.Grade)
                .ThenByDescending(r => r.ReviewDate).Select(r => r.Reviewer).ToList();
        }
    }
}