using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Repository;
using Service.Interface;

namespace Service.Implementation
{
    public class OfferPhotosService : IOfferPhotosService
    {
        private readonly IRepository<OfferPhotos> _repository;

        public OfferPhotosService(IRepository<OfferPhotos> repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddOfferPhotos(OfferPhotos offer)
        {
            try
            {
                var result = await _repository.Add(offer);
                if (result)
                {
                    return true;

                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<OfferPhotos>> DeleteOfferPhotos(int id)
        {
            try
            {
                var allOfferPhotos = _repository.GetAll().Result.Where(x => x.offerID == id);
                if (allOfferPhotos == null)
                {
                    return null;
                }
                foreach (var item in allOfferPhotos)
                {
                    await _repository.Delete(item.Id);

                }
                return allOfferPhotos;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<IEnumerable<OfferPhotos>> GetOfferPhotosById(int id)
        {
            try
            {
                if (id > 0)
                {
                    var allOfferPhotos = await _repository.GetAll();
                    
                    return allOfferPhotos.Where(x=>x.offerID == id);
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
    }
}
