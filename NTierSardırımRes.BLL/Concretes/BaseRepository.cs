using Microsoft.EntityFrameworkCore;
using NTierSardırımRes.BLL.Abstracts;
using NTierSardırımRes.DAL.Context;
using NTierSardırımRes.Entities.Base;
using NTierSardırımRes.Entities.Interfaces;

namespace NTierSardırımRes.BLL.Concretes
{
    public class BaseRepository<T> : IRepository<T> where T : class,IEntity
    {
        private readonly SardirimContext _context;
        private DbSet<T> _entities;

        public BaseRepository(SardirimContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        public  async Task<string> CreateAsync(T entity)
        {
            try
            {
                await _context.Set<T>().AddAsync(entity);
                await _context.SaveChangesAsync();
                return "Entity has been created successfully.";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public async Task<string> DeleteAsync(T entity)
        {
            try
            {
                
                entity.Status = Entities.Enums.DataStatus.Deleted;
                UpdateAsync(entity);
                return "Entity has been delete successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> DestroyAllData(List<T> entity)
        {
            try
            {
                _context.Set<T>().RemoveRange(entity);
                await _context.SaveChangesAsync();
                return "All data has been destroyed successfully.";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public async Task<string> DestroyData(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
                return "Data has been destroyed successfully.";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public IEnumerable<T> GetActiveAsync()
        {
            var activeData = _entities.Where(x => x.IsActive == true).ToList();
            return activeData;
        }


        public async Task<T> GetById(int id)
        {
            var data = await _entities.FirstOrDefaultAsync(x => x.ID == id);
            return data;
        }

        public IEnumerable<T> GetIncativeAsync()
        {
            var activeData = _entities.Where(x => x.IsActive == false).ToList();
            return activeData;
        }

        public async Task<string> UpdateAsync(T entity)
        {
            try
            {
                _context.Set<T>().Update(entity);
                await _context.SaveChangesAsync();
                return "Entity has been updated successfully.";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        IEnumerable<T> IRepository<T>.GetAllAsync()
        {
            return _entities.ToList();
        }
    }
}

       