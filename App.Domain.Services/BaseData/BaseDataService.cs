using App.Domain.Core.BaseData.Contarcts.Repositories;
using App.Domain.Core.BaseData.Contarcts.Services;
using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.BaseData
{
    public class BaseDataService : IBaseDataService
    {
        private readonly IBaseDataQueryRepository _baseDataQueryRepository;
        private readonly IBaseDataCommandRepository _baseDataCommandRepository;

        public BaseDataService(IBaseDataQueryRepository baseDataQueryRepository,
            IBaseDataCommandRepository baseDataCommandRepository)
        {
            _baseDataQueryRepository = baseDataQueryRepository;
            _baseDataCommandRepository = baseDataCommandRepository;
        }
        public async Task<int?> GetFileTypeId(string name)
        {
            var id = await _baseDataQueryRepository.GetFileTypeId(name);
            if (id == null)
                throw new Exception($"FileType name = {name} Doesn't Exists!");
            return id;
        }
        public async Task EnsureFileTypeExists(string name)
        {
            var id = await _baseDataQueryRepository.GetFileTypeId(name);
            if (id == null)
                throw new ArgumentNullException($"FileType name = {name} Doesn't Exists!");
        }
        //public async Task AddFileTypeIfNotExists(string name)
        //{
        //    var id = await _baseDataQueryRepository.GetFileTypeId(name);
        //    if (id == null)
        //        _baseDataCommandRepository.AddFileType(name)
        //}
    }
}
