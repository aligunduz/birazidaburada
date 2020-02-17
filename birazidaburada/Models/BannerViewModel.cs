using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace birazidaburada.Models
{
    public class BannerViewModel
    {
       public List<SelectListItem> Products { get; set; }

        public List<SelectListItem> BannerTypes { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Product must be selected")]
        public int ProductId { get; set; }


        public int BannerType { get; set; }
    }
}