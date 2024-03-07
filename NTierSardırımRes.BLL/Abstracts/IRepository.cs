using NTierSardırımRes.Entities.Base;
using NTierSardırımRes.Entities.Interfaces;

namespace NTierSardırımRes.BLL.Abstracts
{
    public interface IRepository<T> where T : class,IEntity
    {
        //List
        Task<IEnumerable<T>> GetAll(); //Ienumerable bir koleksiyon içinde farklı bir koleksiyonu teslim alı ve içerde kalan koleksiyonun değerlerini döngüye ihtiyaç duymadan teslim eder.
  
        IEnumerable<T> GetActive();
  
        IEnumerable<T> GetIncative();

        //Destroy: Veritabanında veriyi doğrudan siler.
        Task<string> DestroyData(T entity);

        Task<string> DestroyAllData(List<T> entity);

        //Create
        Task<string> CreateAsync(T entity);

        //Read
        Task<Tuple<T?,string>> GetByIdAsync(int id);

        //Update
        Task<string> UpdateAsync(T entity);

        //Delete: Veri silinmeyecek, verinin durumu "Deleted" olarak güncellenecek.
        Task<string> DeleteAsync(T entity);


        
    }
}

