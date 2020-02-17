using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace birazidaburada.Models
{
    public class HomeViewModel
    {
        public List<Product> products
        {
            get;
            set;
        }

        public Banner bannerTop { get; set; }


        public List<Banner> bannerMiddle { get; set; }
        public List<Banner> bannerBottom { get; set; }


    }
}