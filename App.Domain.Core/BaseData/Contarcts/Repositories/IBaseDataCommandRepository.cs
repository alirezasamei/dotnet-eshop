using App.Domain.Core.BaseData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contarcts.Repositories
{
    public interface IBaseDataCommandRepository
    {
        Task AddFileType(string name, int fileTypeExtentionId, DateTime creationDate, bool isDeleted);
        Task DeleteFileType(int id);
    }
}
