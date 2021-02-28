using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Database
{
    public class Contact
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required, StringLength(250)]
        public string Phone { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        [Required, StringLength(250)]
        public string Location { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
