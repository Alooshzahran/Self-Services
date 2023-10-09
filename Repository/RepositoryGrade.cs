using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryGrade : Repository<Grade>, IRepositoryGrade
    {
        public RepositoryGrade(MyDBContext dbContext) : base(dbContext)
        {

        }
    }
}
