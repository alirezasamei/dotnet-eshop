using System;
using System.Collections.Generic;

namespace App.Domain.Core.Product.Entities
{
    public partial class Collection
    {
        public Collection()
        {
            Products = new HashSet<Product>();
            CollectionProducts = new HashSet<CollectionProduct>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<CollectionProduct> CollectionProducts { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
