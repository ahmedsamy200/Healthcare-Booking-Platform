using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IOfferService
    {
        Task<Offer> AddOffer(Offer offer);
        Task<bool> UpdateOffer(Offer offer, int id);
        Task<bool> DeleteOffer(int id);
        Task<Offer> GetOfferById(int id);
        Task<IEnumerable<Offer>> GetAllOffers();
        Task<IEnumerable<Offer>> GetTopOffers();
        Task<IEnumerable<Offer>> GetDoctorOffers(int doctorID);

    }
}
