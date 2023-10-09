using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryBank : Repository<Bank>, IRepositoryBank
    {
        public RepositoryBank(MyDBContext dbContext) : base(dbContext)
        {

        }
    }
}
