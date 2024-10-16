using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.KoiModel
{
    public class KoiOwner
    {
        public string KoiName { get; set; }
        public decimal Weight { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Varieties { get; set; }
        public IFormFile KoiImage { get; set; }
    }
}
