using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Service.Interface
{
    public interface IContactUsService
    {
        Task<bool> Add(ContactUs contactUs);
        Task<IEnumerable<ContactUs>> GetAll();
        Task<bool> Delete(int id);

    }
}
