using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryBankBranch : Repository<BankBranch>, IRepositoryBankBranch
    {
        public RepositoryBankBranch(MyDBContext dbContext) : base(dbContext)
        {

        }
    }
}
