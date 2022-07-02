using App.Domain.Core.Product.Contacts.Repositories.Product;
using App.Domain.Core.Product.Dtos;
using App.Domain.Core.Product.Entities;
using App.Infrastructures.Database.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructures.Database.Repos.Ef.Product.Product
{
    public class ProductColorCommandRepository : IProductColorCommandRepository
    {
        private readonly AppDbContext _context;

        public ProductColorCommandRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public async Task Add(ProductColorDto dto)
        {
            await _context.ProductColors.AddAsync(new ProductColor
            {
                ColorId = dto.ColorId,
                ProductId = dto.ProductId,
                Name = dto.Name,
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
