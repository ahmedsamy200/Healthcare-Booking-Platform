using Domain;
using Microsoft.EntityFrameworkCore;
using Repository;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class ContactUsService:IContactUsService
    {
        private readonly IRepository<ContactUs> _repository;

        public ContactUsService(IRepository<ContactUs> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Add(ContactUs contactUs)
        {
            try
            {
                var result = await _repository.Add(contactUs);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Delete(int id)
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

        public async Task<IEnumerable<ContactUs>> GetAll()
        {
            try
            {
                 return await _repository.GetAll();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
