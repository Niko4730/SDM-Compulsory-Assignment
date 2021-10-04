using System;
using System.Collections.Generic;
using SDM_Compulsory_Assignment.Core.Models;

namespace SDM_Compulsory_Assignment.Infrastructure.Data
{
    public static class ReviewMock
    {
        public static List<Review> ReviewsList = new List<Review>()
        {
            new Review()
            {
                Reviewer = 563,
                Movie = 781196, Grade = 2,
                ReviewDate = DateTime.Parse("2003-03-06")
            }
        };
    }
}