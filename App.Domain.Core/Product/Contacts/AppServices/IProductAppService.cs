using App.Domain.Core.Product.Dtos;
using App.Domain.Core.Product.Entities;

namespace App.Domain.Core.Product.Contacts.AppServices
{
    public interface IProductAppService
    {
        Task<List<ProductShowDto>> GetAll();
        Task Set(ProductCreateDto dto);
        Task<ProductShowDto> Get(int id);
        Task<ProductShowDto> Get(string name);
        Task Update(ProductShowDto dto);
        Task Delete(int id);
    }
}
