using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Banner
    {
        public int Id { get; set; }

        [Required]
        [Range(1,int.MaxValue,ErrorMessage ="Product must be selected")]
        public int ProductId { get; set; }

        public int BannerType { get; set; }//0:head,1bottom,2middle

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [NotMapped]
        public string ImageUrl
        {
            get
            {
                return "/MyImages/" + Product.Id + "_" + Product.ProductImages.First(c => c.IsMain).Id+".jpg";
            }
        }

        [NotMapped]
        public string BannerTypeDesc
        {
            get
            {
                switch (BannerType)
                {
                    case 3:
                        return "Top";
                    case 1:
                        return "Bottom";
                    case 2:
                        return "Middle";
                    default: return "Middle";
                }

            }
        }

    }

}
