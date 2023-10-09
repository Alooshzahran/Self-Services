using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryJobDescription : Repository<JobDescription>, IRepositoryJobDescription
    {
        public RepositoryJobDescription(MyDBContext dbContext) : base(dbContext)
        {

        }
    }
}
