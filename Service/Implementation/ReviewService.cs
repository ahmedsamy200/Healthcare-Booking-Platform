using Domain;
using Repository;
using Service.Interface;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class ReviewService : IReviewService
    {
        private readonly IRepository<Review> _repository;
        private readonly ApplicationDbContext _dbContext;

        public ReviewService(IRepository<Review> repository, ApplicationDbContext dbContext)
        {
            _repository = repository;
            _dbContext = dbContext;
        }
        public async Task<bool> AddReview(Review review)
        {
            try
            {
                var result = await _repository.Add(review);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Review>> GetDoctorReviews(int doctorID)
        {
            try
            {
                if (doctorID > 0 )
                {
                    var result = _dbContext.Review.Include(x=>x.User).Where(x => x.doctorID == doctorID).ToList();
                    if (result.Count > 0)
                    {
                        return result;
                    }
                    return null;

                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<bool> AddedBefor(Review review)
        {
            try
            {
                var result = _repository.GetAll().Result.FirstOrDefault(x => x.userID == review.userID && x.doctorID == review.doctorID);
                if (result != null)
                {
                    return true;
                }
                else
                    return false;
            }
            catch
            {

                return false;
            }

        }


        public async Task<float> GetRating(int doctorID)
        {
            try
            {
                if(doctorID > 0)
                {
                    float? average = _dbContext.Review.Where(x => x.doctorID == doctorID).Average(x => x.rate);
                    if (average != null)
                    {
                        return (float)((average / 5) * 100);

                    }
                    return 0;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {

                throw;
            }  
        }
    }
}
