using Connecter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connecter.Client
{
    public class ClientTimeAttendance : Client<DTO.TimeAttendance>, IClientTimeAttendance
    {
        public ClientTimeAttendance(HttpClient httpClient, IOptions<ServiceSetting> serviceSetting, IHttpContextAccessor httpContext) : base(httpClient, serviceSetting, httpContext)
        {
            
        }
        public async Task<string> GetTimeAttendance(int Id)
        {
            HttpResponseMessage response = await _HttpClient.GetAsync("TimeAttendance/GetTimeAttendanceWhereEmpId?Id=" + Id);
            if (response.IsSuccessStatusCode)
            {
                var TimeAttendace = await response.Content.ReadAsStringAsync();
        
                return TimeAttendace;
            }
            return null;
        }
    }
}
