using Domain;
using Repository;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Service.Implementation
{
    public class OfferService : IOfferService
    {
        private readonly IRepository<Offer> _repository;
        private readonly ApplicationDbContext _dbContext;

        public OfferService(IRepository<Offer> repository, ApplicationDbContext dbContext)
        {
            _repository = repository;
            _dbContext = dbContext;
        }
        public async Task<Offer> AddOffer(Offer offer)
        {
            try
            {
                offer.Doctor = null;
                offer.Id = 0;
                var result = await _repository.Add(offer);
                if (result)
                {
                    return offer;

                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteOffer(int id)
        {
            try
            {
                if (_repository.GetById(id).Result == null)
                {
                    return false;
                }
                await _repository.Delete(id);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<IEnumerable<Offer>> GetAllOffers()
        {
            try
            {
                var result = _dbContext.Offer.Include(x => x.Doctor).Include(x=>x.Doctor.City).Where(x=>x.Doctor.IsActive == true).ToList();
                if (result.Count > 0)
                {
                    return result;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Offer>> GetDoctorOffers(int doctorID)
        {
            try
            {
                if (doctorID > 0)
                {

                    return _dbContext.Offer.Include(x => x.Doctor).Include(x => x.Doctor.City).Where(x => x.doctorID == doctorID);
                }
                else
                {
                    return null;
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Offer> GetOfferById(int id)
        {
            try
            {
                if (id > 0)
                {
                    return _dbContext.Offer.Include(x => x.Doctor).Include(x => x.Doctor.City).FirstOrDefault(x=>x.Id == id && x.Doctor.IsActive == true);
                }
                else
                {
                    return null;
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Offer>> GetTopOffers()
        {
            try
            {

                return _dbContext.Offer.Include(x => x.Doctor).Include(x => x.Doctor.City).Where(x => x.Doctor.IsActive == true).OrderByDescending(x=>x.Id).Take(6);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateOffer(Offer offer, int id)
        {
            try
            {

                if (_repository.GetById(id).Result == null)
                {
                    return false;
                }
                await _repository.Update(offer);
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
