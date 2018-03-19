using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Product_Server.Models;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Product_Server.Models.DAL
{
    public class SupplierProductRepository : IProductRepository, ISupplier, IDisposable
    {
        private ProductDbContext context;

        public SupplierProductRepository(ProductDbContext context)
        {
            this.context = context;
        }
        async Task<IList<Product>> ISupplier.SupplierProducts()
        {
            // As connection only goes from Products to Supplier we have to do it from the 
            // Product side but the supplier will be included
            // This would not be great in production (we would implement the navigation on Both sides)
            return await context.Products.Include("associatedSupplier").ToListAsync();
        }

        async Task<Product> IProductRepository.OrderItem(Product p, int Quantity)
        {
            if (p.Quantity - Quantity > 0)
            {
                p.Quantity -= Quantity;
                context.Entry(p).State = EntityState.Modified;
                try
                {
                    await context.SaveChangesAsync();
                    return p; // Return changed product accepted
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(p.ProductId))
                    {
                        return null;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return p; // return unchanged product
        }

        public void Dispose()
        {
            this.Dispose();
        }

        bool IProductRepository.CheckStock(int productID, int quantityPurchased)
        {
            var found = context.Products.Find(productID);
            if (found != null)
            {
                if (found.Quantity - quantityPurchased < 0) return false;
                else return true;
            }
            return false;

        }


        async Task<IList<Supplier>> IRepository<Supplier>.getEntities()
        {
            return await context.Suppliers.ToListAsync();
        }

        async Task<IList<Product>> IRepository<Product>.getEntities()
        {
            return await context.Products.ToListAsync();
        }

        async Task<Product> IRepository<Product>.GetEntity(int id)
        {
            Product product = await context.Products.FindAsync(id);
            if (product == null)
            {
                return null;
            }

            return product;

        }

        async Task<Supplier> IRepository<Supplier>.GetEntity(int id)
        {
            Supplier supplier = await context.Suppliers.FindAsync(id);
            if (supplier == null)
            {
                return null;
            }

            return supplier;
        }

        async Task<IList<Product>> IProductRepository.GetReorderList()
        {
            return await context.Products.Where(p => p.Quantity <= p.ReorderLevel).ToListAsync();
        }


        float IProductRepository.GetStockCost(int ProductID)
        {
            Product p = context.Products.Find(ProductID);
            if (p != null)
            {
                return (p.Price * p.Quantity);
            }
            return -999f;
        }

        async Task<Supplier> IRepository<Supplier>.PostEntity(Supplier Entity)
        {
            context.Suppliers.Add(Entity);
            await context.SaveChangesAsync();
            return Entity;
        }

        async Task<Product> IRepository<Product>.PostEntity(Product Entity)
        {
            context.Products.Add(Entity);
            await context.SaveChangesAsync();
            return Entity;

        }

        async Task<Supplier> IRepository<Supplier>.PutEntity(Supplier Entity)
        {
            context.Entry(Entity).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
                return Entity;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplierExists(Entity.ID))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

        }
        private bool SupplierExists(int id)
        {
            return context.Suppliers.Count(e => e.ID == id) > 0;
        }
        private bool ProductExists(int id)
        {
            return context.Products.Count(e => e.ProductId == id) > 0;
        }
        async Task<Product> IRepository<Product>.PutEntity(Product Entity)
        {
            context.Entry(Entity).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
                return Entity;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Entity.ProductId))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

        }

        async Task<Supplier> IRepository<Supplier>.Delete(int id)
        {
            Supplier supplier = await context.Suppliers.FindAsync(id);
            if (supplier == null)
            {
                return null;
            }
            context.Suppliers.Remove(supplier);
            await context.SaveChangesAsync();

            return supplier;

        }

        async Task<Product> IRepository<Product>.Delete(int id)
        {
            Product product = await context.Products.FindAsync(id);
            if (product == null)
            {
                return null;
            }
            context.Products.Remove(product);
            await context.SaveChangesAsync();
            return product;
        }

        public Task<Product> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Product>> SupplierProducts()
        {
            throw new NotImplementedException();
        }

        //Task<Supplier> IRepository<Supplier>.Delete(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}