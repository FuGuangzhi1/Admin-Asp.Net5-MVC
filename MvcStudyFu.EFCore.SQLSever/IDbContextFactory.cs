using Microsoft.EntityFrameworkCore;
using StudyMVCFu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcStudyFu.EFCore.SQLSever
{
    public interface IDBContextFactory
    {
        public StudyMVCDBContext CreateDbContext(ReadWriteEnum readWriteEnum);

        public StudyMVCDBContext CreateDbContext();

    }
}
