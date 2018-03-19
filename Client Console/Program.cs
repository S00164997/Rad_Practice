using System;
using Common_Objects;
using Product_Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //            // Scenario Implemented here
            //            // Login and set Token for a valid user account
            //            // 
            //            ClientApiLib.baseWebAddress = "http://localhost:49614/";
            //            if (ClientApiLib.login("fflynstone", "Flint$12345"))
            //            {
            //                List<ProductDTO> reorderList = ClientApiLib.getOrorderList();
            //                foreach (var item in reorderList)
            //                {
            //                    Console.WriteLine("{0} {1} {2}", item.Description, item.ReorderLevel, item.Quantity);
            //                }
            //                // Create a new Product with associated supplier
            //                ProductDTO newprod = new ProductDTO
            //                {
            //                    Description = "glass hammers",
            //                    Price = 200f,
            //                    Quantity = 2,
            //                    ReorderLevel = 5,
            //                    Supplier = new SupplierDTO { Name = "Supplier 1", Address = "1 Sup Road" }
            //                };

            //                // add the supplier and product. Console -> Product Client: Post ProductDTO -> Product Server: Purchases add/SupplierProduct Action
            //                // return Product from Product Server. NOTE: json serialiser will map approriate fields to Product DTO on deserialsation based
            //                // on naming convention of matching fields          
            //                ProductDTO ProductInserted = ClientApiLib.addSupplierProduct(newprod);
            //                // if it was inserted by the server 
            //                if (ProductInserted != null)
            //                {
            //                    Console.WriteLine(ProductInserted.ToString());
            //                }
            //                // Delete the newly inserted supplier. Note if you want to stop 
            //                SupplierDTO deleted = ClientApiLib.delete(ProductInserted.SupplierID);
            //                if (deleted != null)
            //                {
            //                    Console.WriteLine(deleted.ToString() + " Was deleted ");
            //                }

            //                Console.ReadKey();
            //            }
        }
    }
}
