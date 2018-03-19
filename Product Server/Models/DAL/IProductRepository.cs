using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static Product_Server.Models.ProductDbContext;

namespace Product_Server.Models.DAL
{
    public interface IProductRepository : IRepository<Product>
    {
        //IEnumerable<Product> GetProducts();
        //Product GetProductByID(int ProductID);
        //void InsertProduct(Product product);
        //void DeleteProduct(int ProductID);
        //void UpdateProduct(Product product);
        //void Save();

       
            Task<IList<Product>> GetReorderList();
            float GetStockCost(int ProductID);
            bool CheckStock(int productID, int quantityPurchased);
            Task<Product> OrderItem(Product p, int Quantity);
        
    }
}