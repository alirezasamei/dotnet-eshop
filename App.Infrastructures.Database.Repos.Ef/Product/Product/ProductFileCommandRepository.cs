using App.Domain.Core.Product.Contacts.Repositories.Product;
using App.Domain.Core.Product.Dtos;
using App.Domain.Core.Product.Entities;
using App.Infrastructures.Database.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructures.Database.Repos.Ef.Product.Product
{
    public class ProductFileCommandRepository : IProductFileCommandRepository
    {
        private readonly AppDbContext _context;

        public ProductFileCommandRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public async Task Add(ProductFileDto dto)
        {
            await _context.ProductFiles.AddAsync(new ProductFile
            {
                Name = dto.Name,
                FileTypeId = dto.FileTypeId,
                ProductId = dto.ProductId,
                CreationDate = dto.CreationDate,
                IsDeleted = dto.IsDeleted,
            });
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var record = await _context.ProductColors.Where(p => p.Id == id).FirstAsync();
            _context.Remove(record);
            await _context.SaveChangesAsync();
        }
    }
}
