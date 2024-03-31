using Domian;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<T> entities;
        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            entities = _dbContext.Set<T>();

        }

        public async Task<bool> Add(T entity)
        {

            try
            {
                entities.Add(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {

                var result = await entities.Where(e => e.Id == id).FirstOrDefaultAsync();
                if (result != null)
                {
                    entities.Remove(result);
                   await _dbContext.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public async Task<IEnumerable<T>> GetAll()
        {
            try
            {
                return await entities.AsNoTracking().ToListAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }

       
        public async Task<T> GetById(int? id)
        {
            try
            {
                return await entities.FirstOrDefaultAsync(x => x.Id == id);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async void SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> Update(T entity)
        {
            try
            {
                entities.Update(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
