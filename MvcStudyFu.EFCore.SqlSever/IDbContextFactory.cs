using Microsoft.EntityFrameworkCore;
using StudyMVCFu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcStudyFu.EFCore.SQLSever
{
    public interface IDbContextFactory
    {
        public StudyMVCDBContext CreateDbContext(ReadWriteEnum readWriteEnum);

    }
}
