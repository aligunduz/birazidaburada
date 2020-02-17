using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
   public class Chart
    {
        //public Chart()
        //{
        //    Products = new List<Product>();
        //}
            
        
        public int Id { get; set; }

        public int UserId { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();




    }
}
