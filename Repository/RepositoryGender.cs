using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryGender : Repository<Gender>, IRepositoryGender
    {
        public RepositoryGender(MyDBContext dbContext) : base(dbContext)
        {

        }
    }
}
