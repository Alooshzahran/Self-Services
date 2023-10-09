using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connecter.Client
{
    public interface IClientTimeAttendance
    {
        public Task<string> GetTimeAttendance(int Id);
    }
}
