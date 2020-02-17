namespace DataAccessLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductImage
    {
        public int Id { get; set; }

        [NotMapped]
        public string FilePath {
            get
            {
                return Product_Id + "_" + Id+".jpg";
            }
                
                }
        
        public bool IsMain { get; set; }

        public DateTime CreateDate { get; set; }

        public int? Product_Id { get; set; }

        public virtual Product Product { get; set; }
    }
}
