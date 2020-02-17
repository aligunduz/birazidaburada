using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace birazidaburada.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        public int UserType { get; set; }

        public DateTime CreateDate { get; set; }
    }
}