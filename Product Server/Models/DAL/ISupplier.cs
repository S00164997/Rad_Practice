using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static Product_Server.Models.ProductDbContext;

namespace Product_Server.Models.DAL
{
    public interface ISupplier : IRepository<Supplier>
    {
        //IEnumerable<Supplier> GetSuppliers();
        //Product GetSupplierByID(int SupplierID);
        //void InsertSupplier(Supplier supplier);
        //void DeleteSuppliert(int SupplierID);
        //void UpdateSupplier(Supplier supplier);
        //void Save();

       
            Task<IList<Product>> SupplierProducts();
        
    }
}