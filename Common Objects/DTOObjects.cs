using System.Collections.Generic;

namespace Common_Objects
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int ReorderLevel { get; set; }
        public float Price { get; set; }
        public int SupplierID { get; set; }
        public SupplierDTO Supplier { get; set; }

        public override string ToString()
        {
            return string.Concat(ProductId.ToString(), " ", Description, " ", Quantity.ToString(), SupplierID.ToString());
        }
    }

    public class SupplierDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<ProductDTO> Products { get; set; }
        public override string ToString()
        {
            return string.Concat(ID.ToString(), " ", Name, " ", Address);
        }
    }
}