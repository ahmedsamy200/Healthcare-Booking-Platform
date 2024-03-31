using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Service.Interface
{
    public interface IReviewService
    {
        Task<bool> AddReview(Review review);
        Task<bool> AddedBefor(Review review);
        Task<float> GetRating(int doctorID);

        Task<IEnumerable<Review>> GetDoctorReviews(int doctorID);

    }
}
