using App.Domain.Core.Product.Dtos;

namespace App.Domain.Core.Product.Contacts.Repositories.Product
{
    public interface IProductFileCommandRepository
    {
        Task Add(ProductFileDto dto);
        Task Delete(int id);
    }
}
