using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Company : BaseEntity
    {
        public string CompanyNameEN { get; set; }
        public string CompanyNameAR { get; set; }
        public string CompanyHeader { get; set; }
        public string CompanyFooter { get; set; }
        public string Logo { get; set; }
        public string BannerImage { get; set; }
        public string ThemeDarkColor { get; set; }
        public string ThemeLightColor { get; set; }

    }
}
