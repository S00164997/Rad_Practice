using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Product_Server.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Product ID")]
        public int ProductId { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Quantity in Stock")]
        public int Quantity { get; set; }

        [Display(Name = "Reorder Level")]
        public int ReorderLevel { get; set; }

        [Display(Name = "Unit Price")]
        public float Price { get; set; }

        [ForeignKey("associatedSupplier")]
        public int SupplierID { get; set; }

        public virtual Supplier associatedSupplier { get; set; }
    }
}