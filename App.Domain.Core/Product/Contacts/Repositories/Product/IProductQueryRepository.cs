using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contacts.Repositories.Product
{
    public interface IProductQueryRepository
    {
        Task<List<ProductShowDto>?> GetAll();
        Task<ProductShowDto?> Get(int id);
        Task<ProductShowDto?> Get(string name);
    }
}
