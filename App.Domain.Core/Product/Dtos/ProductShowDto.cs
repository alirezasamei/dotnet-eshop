using App.Domain.Core.Product.Dtos.Color;
using App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Dtos
{
    public class ProductShowDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string CategoryName { get; set; } = null!;
        public int CategoryId { get; set; }
        public string BrandName { get; set; } = null!;
        public int BrandId { get; set; }
        public decimal Weight { get; set; }
        public bool IsOrginal { get; set; }
        public string Description { get; set; } = null!;
        public int Count { get; set; }
        public string ModelName { get; set; }=null!;
        public int ModelId { get; set; }
        public long Price { get; set; }
        public bool IsShowPrice { get; set; }
        public bool IsActive { get; set; }
        public string OperatorName { get; set; } = null!;
        public int OperatorId { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }
        public List<string> FileNames { get; set; } = new List<string>();
        public List<ColorBrifDto> Colors { get; set; } = new List<ColorBrifDto>();
    }
}
