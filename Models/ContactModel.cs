using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class ContactModel
    {
        public int Id { get; set; }

        [Required, StringLength(250)]
        public string Phone { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        [Required, StringLength(250)]
        public string Location { get; set; }
    }
}
