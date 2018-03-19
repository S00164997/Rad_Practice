using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Product_Server.Models
{
    [Table(name: "Supplier")]
    public class Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Supplier ID")]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}