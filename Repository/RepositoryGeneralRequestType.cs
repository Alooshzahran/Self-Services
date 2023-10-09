using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryGeneralRequestType : Repository<GeneralRequestType>, IRepositoryGeneralRequestType
    {
        public RepositoryGeneralRequestType(MyDBContext dbContext) : base(dbContext)
        {

        }
    }
}
