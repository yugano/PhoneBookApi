using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Database;
using WebApplication2.Models;

namespace WebApplication2.Extensions
{
    public static class ContactExtensions
    {
        public static ContactModel ChangeContactToModel(this Contact model)
        {
            var contactModel = new ContactModel
            {
                Id = model.Id,
                Phone = model.Phone,
                Email = model.Email,
                Location = model.Location
            };

            return contactModel;
        }

        public static List<ContactModel> ChangeContactListToModel(this List<Contact> model)
        {
            var result = model.Select(x => new ContactModel
            {
                Id = x.Id,
                Phone = x.Phone,
                Email = x.Email,
                Location = x.Location
            })
            .ToList();

            return result;
        }
    
        public static Contact ChangeModelToContact(this ContactModel model)
        {
            var contact = new Contact
            {
                Id = model.Id,
                Phone = model.Phone,
                Email = model.Email,
                Location = model.Location
            };

            return contact;
        }
    
    }
}
