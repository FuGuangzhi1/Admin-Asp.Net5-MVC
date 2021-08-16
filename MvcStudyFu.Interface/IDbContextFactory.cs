using Microsoft.EntityFrameworkCore;
using MvcStudyFu.Common.Enum;
using MvcStudyFu.EFCore.SQLSever;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcStudyFu.Interface
{
    public interface IDbContextFactory
    {
        public StudyMVCDBContext CreateDbContext(ReadWriteEnum readWriteEnum);

    }
}
