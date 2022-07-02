
using App.Domain.Core.Product.Contacts.AppServices;
using App.Domain.Core.Product.Contacts.Services;
using App.Domain.Core.Product.Dtos;
using App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Product
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductService _service;
        private readonly IColorService _colorService;

        public ProductAppService(IProductService categoryService,
            IColorService colorService)
        {
            _service = categoryService;
            _colorService = colorService;
        }
        public async Task Delete(int id)
        {
            await _service.EnsureExists(id);
            await _service.Delete(id);
        }

        public async Task<ProductShowDto> Get(int id)
        {
            return await _service.Get(id);
        }

        public async Task<ProductShowDto> Get(string name)
        {
            return await _service.Get(name);
        }

        public async Task<List<ProductShowDto>> GetAll()
        {
            return await _service.GetAll();
        }

        public async Task Set(ProductCreateDto dto)
        {
            await _service.EnsureDoesNotExist(dto.Name);
            dto.IsDeleted = false;
            var productId = await _service.Set(dto);

            if (dto.ProductColors.Count > 0)
                foreach (var productColor in dto.ProductColors)
                {
                    var colorName = (await _colorService.Get(productColor.ColorId)).Name;
                    productColor.ProductId = productId;
                    productColor.IsDeleted = false;
                    productColor.Name = colorName;
                    productColor.CreationDate = DateTime.Now;
                    await _service.Set(productColor);
                }

            if (dto.Files.Count > 0)
                foreach (var file in dto.Files)
                {
                    file.IsDeleted = false;
                    file.ProductId = productId;
                    file.CreationDate = DateTime.Now;
                    await _service.Set(file);
                }
        }

        public async Task Update(ProductShowDto dto)
        {
            await _service.EnsureExists(dto.Id);
            await _service.Update(dto);
        }

    }
}
