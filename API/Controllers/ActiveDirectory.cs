using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Services;
using System.Diagnostics;
using System.DirectoryServices;
using System.Reflection.PortableExecutable;
using DirectoryEntry = System.DirectoryServices.DirectoryEntry;
using SearchResult = System.DirectoryServices.SearchResult;

namespace API.Controllers
{
    [Route("api/ldap")]
    [ApiController]
    public class ActiveDirectory : ControllerBase
    {
        public ActiveDirectory()
        {
            
        }
        [HttpGet]
        [Route("GetCurrentDomainPath")]
        public string GetCurrentDomainPath()
        {
            DirectoryEntry de = new DirectoryEntry("LDAP://RootDSE");

            return "LDAP://" + de.Properties["defaultNamingContext"][0].ToString();
        }
        [HttpGet]
        [Route("GetAllUsers")]
        public void GetAllUsers()
        {
            SearchResultCollection results;
            DirectorySearcher ds = null;
            DirectoryEntry de = new DirectoryEntry(GetCurrentDomainPath());

            ds = new DirectorySearcher(de);
            ds.Filter = "(&(objectCategory=User)(objectClass=person))";

            results = ds.FindAll();

            foreach (SearchResult sr in results)
            {
                // Using the index zero (0) is required!
                Debug.WriteLine(sr.Properties["name"][0].ToString());
            }
        }
    }
}
