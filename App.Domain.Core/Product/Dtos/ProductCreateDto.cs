using App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Dtos
{
    public class ProductCreateDto
    {
        public string Name { get; set; } = null!;
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public decimal Weight { get; set; }
        public bool IsOrginal { get; set; }
        public string Description { get; set; } = null!;
        public int Count { get; set; }
        public int ModelId { get; set; }
        public long Price { get; set; }
        public bool IsShowPrice { get; set; }
        public bool IsActive { get; set; }
        public int OperatorId { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }
        public List<ProductFileDto> Files { get; set; } = new List<ProductFileDto>();
        public List<ProductColorDto> ProductColors { get; set; } = new List<ProductColorDto>();
    }
}
