using App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.Product.Entities
{
    public partial class Color
    {
        public Color()
        {
            Products = new HashSet<Product>();
            ProductColors = new HashSet<ProductColor>();
        }

        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<ProductColor> ProductColors { get; set; }
    }
}
