using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Product_Server.Models.DAL
{
    public interface IRepository<T> 
    {
        Task<IList<T>> getEntities();
        Task<T> GetEntity(int id);
        Task<T> PutEntity(T Entity);
        Task<T> PostEntity(T Entity);
        Task<T> Delete(int id);
    }
}