using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;


namespace Service.Interface
{
    public interface IOfferPhotosService
    {
        Task<bool> AddOfferPhotos(OfferPhotos offer);
        Task<IEnumerable<OfferPhotos>> DeleteOfferPhotos(int id);
        Task<IEnumerable<OfferPhotos>> GetOfferPhotosById(int id);
    }
}
