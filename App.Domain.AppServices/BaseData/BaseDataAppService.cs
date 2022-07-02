using App.Domain.Core.BaseData.Contarcts.AppServices;
using App.Domain.Core.BaseData.Contarcts.Services;
using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.BaseData
{
    public class BaseDataAppService : IBaseDataAppService
    {
        private readonly IBaseDataService _baseDataService;

        public BaseDataAppService(IBaseDataService baseDataService)
        {
            _baseDataService = baseDataService;
        }
        public async Task<int?> GetFileTypeId(string name)
        {
            await _baseDataService.EnsureFileTypeExists(name);
            return await _baseDataService.GetFileTypeId(name);
        }
    }
}
