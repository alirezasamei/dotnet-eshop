using App.Domain.Core.Product.Dtos;
namespace App.Domain.Core.Product.Contacts.Services
{
    public interface IProductService
    {
        Task<List<ProductShowDto>?> GetAll();
        Task<int> Set(ProductCreateDto dto);
        Task Set(ProductColorDto dto);
        Task Set(ProductFileDto dto);
        Task<ProductShowDto> Get(int id);
        Task<ProductShowDto> Get(string name);
        Task Update(ProductShowDto dto);
        Task Delete(int id);
        Task EnsureDoesNotExist(string name);
        Task EnsureExists(string name);
        Task EnsureExists(int id);
    }
}
