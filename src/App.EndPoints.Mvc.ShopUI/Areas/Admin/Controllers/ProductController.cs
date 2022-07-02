using App.Domain.Core.BaseData.Contarcts.AppServices;
using App.Domain.Core.Operator.Contract.AppServices;
using App.Domain.Core.Product.Contacts.AppServices;
using App.Domain.Core.Product.Dtos;
using App.EndPoints.Mvc.AdminUI.Models.ViewModels.Product.Product;
using App.EndPoints.Mvc.AdminUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{

    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductAppService _productAppService;
        private readonly IBrandAppService _brandAppService;
        private readonly IColorAppService _colorAppService;
        private readonly IModelAppService _modelAppService;
        private readonly ICategoryAppService _categoryAppService;
        private readonly IOperatorAppService _operatorAppService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IBaseDataAppService _baseDataAppService;

        // TODO : Operator

        public ProductController(
            IProductAppService appService,
            IBrandAppService brandAppService,
            IColorAppService colorAppService,
            IModelAppService modelAppService,
            ICategoryAppService categoryAppService,
            IOperatorAppService operatorAppService,
            IWebHostEnvironment webHostEnvironment,
            IBaseDataAppService baseDataAppService)
        {
            _webHostEnvironment = webHostEnvironment;
            _baseDataAppService = baseDataAppService;
            _productAppService = appService;
            _brandAppService = brandAppService;
            _colorAppService = colorAppService;
            _modelAppService = modelAppService;
            _categoryAppService = categoryAppService;
            _operatorAppService = operatorAppService;
        }

        public async Task<IActionResult> Index()
        {
            var records = await _productAppService.GetAll();
            var recordsProduct = records.Select(p => new ProductOutputViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                CreationDate = p.CreationDate,
                IsDeleted = p.IsDeleted,
                CategoryId = p.CategoryId,
                Weight = p.Weight,
                IsOrginal = p.IsOrginal,
                Description = p.Description,
                Count = p.Count,
                ModelId = p.ModelId,
                Price = p.Price,
                IsShowPrice = p.IsShowPrice,
                IsActive = p.IsActive,
                OperatorId = p.OperatorId,
                BrandId = p.BrandId,
                Images = p.FileNames.Select(n => new ImageViewModel
                {
                    Name = Path.GetFileNameWithoutExtension(n).Split("_")[0],
                    Url = n,
                }).ToList(),
            }).ToList();
            return View(recordsProduct);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var brands = await _brandAppService.GetAll();
            ViewBag.Brands = brands.Select
            (s => new SelectListItem
            {
                Text = s.Name,
                Value = s.Id.ToString()
            });
            var colors = await _colorAppService.GetAll();
            ViewBag.Colors = colors
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });
            var categories = await _categoryAppService.GetAll();
            ViewBag.Categories = categories
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });
            var models = await _modelAppService.GetAll();
            ViewBag.Models = models
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });

            var operators = await _operatorAppService.GetAll();
            ViewBag.Operators = operators
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductAddViewModel product, IFormFileCollection files)
        {

            if (ModelState.IsValid)
            {
                //var colors = await _colorAppService.GetAll();
                //// select the selected colors
                //var selectedColors = colors.Where(x => product.ColorIds.Contains(x.Id)).ToList();

                var dto = new ProductCreateDto
                {
                    Name = product.Name,
                    CreationDate = DateTime.Now,
                    CategoryId = product.CategoryId,
                    Weight = product.Weight,
                    IsOrginal = product.IsOrginal,
                    Description = product.Description,
                    Count = product.Count,
                    ModelId = product.ModelId,
                    Price = product.Price,
                    IsShowPrice = product.IsShowPrice,
                    IsActive = product.IsActive,
                    OperatorId = product.OperatorId,
                    BrandId = product.BrandId,
                };
                product.ColorIds.ForEach(c => dto.ProductColors.Add(new ProductColorDto { ColorId = c }));
                var fileTypes = new List<string>();
                foreach (var file in files)
                {
                    string fileName = Path.GetFileNameWithoutExtension(file.FileName) + Guid.NewGuid().ToString();
                    using (FileStream stream = new FileStream(Path.Combine(_webHostEnvironment.WebRootPath, fileName + Path.GetExtension(file.FileName)), FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                        try
                        {
                            dto.Files.Add(new ProductFileDto
                            {
                                Name = fileName,
                                FileTypeId = (int)await _baseDataAppService.GetFileTypeId(file.ContentType),

                            });
                        }
                        catch (ArgumentNullException ex)
                        {
                            fileTypes.Add(file.ContentType);
                        }
                    }
                }
                //if(fileTypes.Count > 0)
                //    return 
                await _productAppService.Set(dto);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(product);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var brands = await _brandAppService.GetAll();
            ViewBag.Brands = brands.Select
            (s => new SelectListItem
            {
                Text = s.Name,
                Value = s.Id.ToString()
            });
            var colors = await _colorAppService.GetAll();
            ViewBag.Colors = colors
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });
            var categories = await _categoryAppService.GetAll();
            ViewBag.Categories = categories
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });
            var models = await _modelAppService.GetAll();
            ViewBag.Models = models
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });
            var operators = await _operatorAppService.GetAll();
            ViewBag.Operators = operators
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });

            var dto = await _productAppService.Get(id);
            var viewProduct = new ProductUpdateViewModel
            {
                Id = dto.Id,
                Name = dto.Name,
                IsDeleted = dto.IsDeleted,
                CategoryId = dto.CategoryId,
                Weight = dto.Weight,
                IsOrginal = dto.IsOrginal,
                Description = dto.Description,
                Count = dto.Count,
                ModelId = dto.ModelId,
                Price = dto.Price,
                IsShowPrice = dto.IsShowPrice,
                IsActive = dto.IsActive,
                OperatorId = dto.OperatorId,
                BrandId = dto.BrandId,
            };

            return View(viewProduct);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductUpdateViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            var colors = await _colorAppService.GetAll();
            // select the selected colors
            var selectedColors = colors.Where(x => product.ColorIds.Contains(x.Id)).ToList();

            var dto = new ProductShowDto
            {
                Id = product.Id,
                Name = product.Name,
                IsDeleted = product.IsDeleted,
                CategoryId = product.CategoryId,
                Weight = product.Weight,
                IsOrginal = product.IsOrginal,
                Description = product.Description,
                Count = product.Count,
                ModelId = product.ModelId,
                Price = product.Price,
                IsShowPrice = product.IsShowPrice,
                IsActive = product.IsActive,
                OperatorId = product.OperatorId,
                BrandId = product.BrandId,
                //Colors = selectedColors,
            };
            await _productAppService.Update(dto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _productAppService.Delete(id);
            return RedirectToAction("Index");
        }

        public async Task<bool> CheckName(string name)
        {
            try
            {
                await _productAppService.Get(name);
                return false;
            }
            catch (Exception)
            {
                return true;
            }

        }
    }
}
