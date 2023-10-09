using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryGeneralRequest : Repository<GeneralRequest>, IRepositoryGeneralRequest
    {
        public RepositoryGeneralRequest(MyDBContext dbContext) : base(dbContext)
        {

        }
    }
}
