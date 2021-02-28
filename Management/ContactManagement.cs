using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Database;
using WebApplication2.Models;

namespace WebApplication2.Management
{
    public class ContactManagement
    {
        private PhoneBookDb database;

        public ContactManagement()
        {
            database = new PhoneBookDb();
        }

        public Contact GetContactById(int userId, int Id)
        {
            var model = database.Contacts.FirstOrDefault(x => x.Id == Id && x.UserId == userId);

            return model;
        }

        public List<Contact> GetUsersAllContact(int userId)
        {
            var model = database.Contacts.Where(x => x.UserId == userId).ToList();

            return model;
        }

        public List<Contact> GetAllContacts()
        {
            var result = database.Contacts.ToList();

            return result;
        }
        public Contact Create(Contact model)
        {
            if (model == null)
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(model.Phone) || string.IsNullOrWhiteSpace(model.Email) || string.IsNullOrWhiteSpace(model.Location))
            {
                return null;
            }

            model.Location = model.Location.Trim().ToUpper().First() + model.Location.Trim().ToLower().Substring(1);

            try
            {
                database.Contacts.Add(model);
                database.SaveChanges();

                return model;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool Delete(int Id)
        {
            var model = database.Contacts.FirstOrDefault(x => x.Id == Id);
            if (model == null)
            {
                return false;
            }

            try
            {
                database.Contacts.Remove(model);
                database.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    
       public List<ContactReport> GetContactReport()
        {
            var result = database.Contacts
                                 .ToList()
                                 .GroupBy(x => x.Location)
                                 .ToDictionary(x => x.Key, y => y.ToList())
                                 .Select(x => new ContactReport
                                 {
                                         Location = x.Key,
                                         LocationCount = x.Value.Count,
                                         PeopleInLocation = x.Value.Select(l => l.UserId).Distinct().Count(),
                                         PhonesInLocation = x.Value.ToList().Count()
                                 })
                                .OrderByDescending(x => x.LocationCount)
                                .ToList();

            return result;
        }
    
    }
}
