using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contarcts.Services
{
    public interface IBaseDataService
    {
        Task EnsureFileTypeExists(string name);
        Task<int?> GetFileTypeId(string name);
    }
}
