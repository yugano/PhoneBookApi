using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Database;

namespace WebApplication2.Models
{
    public class UserWithContactModel
    {
        public UserWithContactModel()
        {
            Contacts = new List<ContactModel>();
        }
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Firm { get; set; }

        public List<ContactModel> Contacts { get; set; }
    }
}
