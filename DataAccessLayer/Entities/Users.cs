namespace DataAccessLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            Wishes = new HashSet<Product>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        public int UserType  { get; set; }

        public DateTime CreateDate { get; set; }

        public virtual ICollection<Product> Wishes { get; set; }


    }
}
