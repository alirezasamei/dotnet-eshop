
using App.Domain.Core.Product.Contacts.Repositories.Product;
using App.Domain.Core.Product.Contacts.Services;
using App.Domain.Core.Product.Dtos;
using App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Product
{
    public class ProductService : IProductService
    {

        private readonly IProductCommandRepository _productCommandRepository;
        private readonly IProductQueryRepository _productQueryRepository;
        private readonly IProductColorCommandRepository _productColorCommandRepository;
        private readonly IProductFileCommandRepository _productFileCommandRepository;

        public ProductService(IProductCommandRepository productCommandRepository,
            IProductQueryRepository productQueryRepository,
            IProductColorCommandRepository productColorCommandRepository,
            IProductFileCommandRepository productFileCommandRepository)
        {
            _productQueryRepository = productQueryRepository;
            _productColorCommandRepository = productColorCommandRepository;
            _productFileCommandRepository = productFileCommandRepository;
            _productCommandRepository = productCommandRepository;
        }

        public async Task Delete(int id)
        {
            await _productCommandRepository.Delete(id);
        }

        public async Task EnsureDoesNotExist(string name)
        {
            var record = await _productQueryRepository.Get(name);
            if (record != null)
            {
                throw new Exception($"Category {name} Already Exists!");
            }
        }

        public async Task EnsureExists(string name)
        {
            var record = await _productQueryRepository.Get(name);
            if (record == null)
            {
                throw new Exception($"Category {name} Doesn't Exists!");
            }
        }

        public async Task EnsureExists(int id)
        {
            var record = await _productQueryRepository.Get(id);
            if (record == null)
            {
                throw new Exception($"Category {id} Doesn't Exists!");
            }
        }

        public async Task<ProductShowDto> Get(int id)
        {
            var record = await _productQueryRepository.Get(id);
            if (record == null)
            {
                throw new Exception($"Category {id} Doesn't Exists!");
            }
            return record;
        }

        public async Task<ProductShowDto> Get(string name)
        {
            var record = await _productQueryRepository.Get(name);
            if (record == null)
            {
                throw new Exception($"Category {name} Doesn't Exists!");
            }
            return record;
        }

        public async Task<List<ProductShowDto>?> GetAll()
        {
            return await _productQueryRepository.GetAll();
        }

        public async Task<int> Set(ProductCreateDto dto)
        {
            return await _productCommandRepository.Add(dto);
        }

        public async Task Set(ProductColorDto dto)
        {
            await _productColorCommandRepository.Add(dto);
        }

        public async Task Set(ProductFileDto dto)
        {
            await _productFileCommandRepository.Add(dto);
        }

        public async Task Update(ProductShowDto dto)
        {
            await _productCommandRepository.Update(dto);
        }

    }
}