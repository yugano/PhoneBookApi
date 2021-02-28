using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }

        [Required, StringLength(250)]
        public string Name { get; set; }

        [Required, StringLength(250)]
        public string SurName { get; set; }

        [Required, StringLength(250)]
        public string Firm { get; set; }
    }
}
