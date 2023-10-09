using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryNationality : Repository<Nationality>, IRepositoryNationality
    {
        public RepositoryNationality(MyDBContext dbContext) : base(dbContext)
        {

        }
    }
}
