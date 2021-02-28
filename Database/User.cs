using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Database
{
    public class User
    {
        public User()
        {
            Contacts = new List<Contact>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; }

        [Required, StringLength(250)]
        public string Name { get; set; }

        [Required, StringLength(250)]
        public string SurName { get; set; }

        [Required, StringLength(250)]
        public string Firm { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public bool IsActive { get; set; }

        public virtual List<Contact> Contacts { get; set; }
    }
}
