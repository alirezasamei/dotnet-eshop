using App.Domain.Core.Product.Contacts.Repositories.Product;
using App.Domain.Core.Product.Dtos;
using App.Infrastructures.Database.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructures.Database.Repos.Ef.Product.Product
{
    public class ProductQueryRepository : IProductQueryRepository
    {
        private readonly AppDbContext _context;

        public ProductQueryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<ProductShowDto>?> GetAll()
        {
            return await _context.Products.Select(p => new ProductShowDto()
            {
                Id = p.Id,
                CategoryId = p.CategoryId,
                CategoryName = p.Category.Name,
                BrandId = p.BrandId,
                BrandName = p.Brand.Name,
                Weight = p.Weight,
                IsOrginal = p.IsOrginal,
                Description = p.Description,
                Count = p.Count,
                ModelId = p.ModelId,
                ModelName = p.Model.Name,
                Price = p.Price,
                IsShowPrice = p.IsShowPrice,
                IsActive = p.IsActive,
                OperatorId = p.OperatorId,
                Name = p.Name,
                IsDeleted = p.IsDeleted,
                CreationDate = p.CreationDate,
                FileNames = p.ProductFiles.Select(f => f.Name).ToList(),
                Colors = p.Colors.Select(c => new ColorBrifDto
                {
                    Id = c.Id,
                    Code = c.Code,
                    Name = c.Name
                }).ToList(),
            }).ToListAsync();
        }

        public async Task<ProductShowDto?> Get(int id)
        {
            var record = await _context.Products.Where(p => p.Id == id).Select(p => new ProductShowDto()
            {
                Id = p.Id,
                CategoryId = p.CategoryId,
                CategoryName=p.Category.Name,
                BrandId = p.BrandId,
                BrandName=p.Brand.Name,
                Weight = p.Weight,
                IsOrginal = p.IsOrginal,
                Description = p.Description,
                Count = p.Count,
                ModelId = p.ModelId,
                ModelName=p.Model.Name,
                Price = p.Price,
                IsShowPrice = p.IsShowPrice,
                IsActive = p.IsActive,
                OperatorId = p.OperatorId,
                Name = p.Name,
                IsDeleted = p.IsDeleted,
                CreationDate = p.CreationDate,
                FileNames = p.ProductFiles.Select(f => f.Name).ToList(),
                Colors = p.Colors.Select(c => new ColorBrifDto
                {
                    Id = c.Id,
                    Code = c.Code,
                    Name = c.Name
                }).ToList(),                
            }).SingleOrDefaultAsync();
            return record;
        }

        public async Task<ProductShowDto?> Get(string name)
        {
            var record = await _context.Products.Where(p => p.Name == name).Select(p => new ProductShowDto()
            {
                Id = p.Id,
                CategoryId = p.CategoryId,
                CategoryName = p.Category.Name,
                BrandId = p.BrandId,
                BrandName = p.Brand.Name,
                Weight = p.Weight,
                IsOrginal = p.IsOrginal,
                Description = p.Description,
                Count = p.Count,
                ModelId = p.ModelId,
                ModelName = p.Model.Name,
                Price = p.Price,
                IsShowPrice = p.IsShowPrice,
                IsActive = p.IsActive,
                OperatorId = p.OperatorId,
                Name = p.Name,
                IsDeleted = p.IsDeleted,
                CreationDate = p.CreationDate,
                FileNames = p.ProductFiles.Select(f => f.Name).ToList(),
                Colors = p.Colors.Select(c => new ColorBrifDto
                {
                    Id = c.Id,
                    Code = c.Code,
                    Name = c.Name
                }).ToList(),
            }).SingleOrDefaultAsync();
            return record;
        }
    }
}
