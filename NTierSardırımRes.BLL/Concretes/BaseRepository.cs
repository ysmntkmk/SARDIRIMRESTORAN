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
        private  DbSet<T> _entities;

        public BaseRepository(SardirimContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        public  async Task<string> CreateAsync(T entity)
        {
            try
            {
                await _entities.AddAsync(entity);
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
                await UpdateAsync(entity);
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
                _entities.RemoveRange(entity);
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
                _entities.Remove(entity);
                await _context.SaveChangesAsync();
                return "Data has been destroyed successfully.";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public IEnumerable<T> GetActive()
        {
            var activeData = _entities.Where(x => x.Status != Entities.Enums.DataStatus.Deleted).ToList();
            return activeData;
        }


        public async Task<Tuple<T?,string>> GetByIdAsync(int id)
        {
            T? data = await _entities.FirstOrDefaultAsync(x => x.ID == id);
            if (data != null)
                return Tuple.Create<T?,string>(data, "Veri basarılı sekilde bulundu");
            return Tuple.Create(default(T), "Veri bulunamadı");
          
        }

        public IEnumerable<T> GetIncative()
        {
            var activeData = _entities.Where(x => x.Status == Entities.Enums.DataStatus.Deleted  ).ToList();
            return activeData;
        }

        public async Task<string> UpdateAsync(T entity)
        {
            try
            {
                _entities.Update(entity);
                await _context.SaveChangesAsync();
                return "Entity has been updated successfully.";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            
            return await _entities.ToListAsync();
        }

       
    }
}

       