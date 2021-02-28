using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Database;

namespace WebApplication2.Management
{
    public class UserManagement
    {
        private PhoneBookDb database;

        public UserManagement()
        {
            database = new PhoneBookDb();
        }

        public List<User> GetUsers()
        {
            return database.Users.Where(x => x.IsActive).ToList();
        }

        public User GetUserById(Guid id)
        {
            var model = database.Users.FirstOrDefault(x => x.UserId == id);

            return model;
        }
      
        public User GetUserWithContacts(Guid id)
        {
            var model = database.Users.Include(x => x.Contacts).FirstOrDefault(x => x.UserId == id);

            return model;
        }
        public User Create(User user)
        {
            if (user == null)
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(user.Firm) || string.IsNullOrWhiteSpace(user.Name) || string.IsNullOrWhiteSpace(user.SurName))
            {
                return null;
            }

            user.CreatedDate = DateTime.Now;
            user.UserId = Guid.NewGuid();
            user.IsActive = true;

            try
            {
                database.Users.Add(user);
                database.SaveChanges();
            }
            catch (Exception)
            {
                return null;
            }


            return user;
        }

        public bool Update(User user)
        {
            var model = database.Users.FirstOrDefault(x => x.UserId == user.UserId);
            if (model == null)
            {
                return false;
            }

            model.Name = user.Name;
            model.SurName = user.SurName;
            model.Firm = user.Firm;
            model.UpdatedDate = DateTime.Now;

            try
            {
                database.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool RemoveUser(Guid id)
        {
            var model = database.Users.FirstOrDefault(x => x.UserId == id);
            if (model == null)
            {
                return false;
            }

            model.IsActive = false;
            database.SaveChanges();

            return true;
        }

        public bool DeleteUser(Guid id)
        {
            var model = database.Users.Include(x => x.Contacts).FirstOrDefault(x => x.UserId == id);
            if (model == null)
            {
                return false;
            }

            try
            {
                foreach (var item in model.Contacts)
                {
                    database.Contacts.Remove(item);
                }


                database.Users.Remove(model);
                database.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool IsUserExist(Guid id)
        {
            return database.Users.Any(x => x.UserId == id);
        }
    }
}
