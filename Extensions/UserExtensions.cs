using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Database;
using WebApplication2.Models;

namespace WebApplication2.Extensions
{
    public static class UserExtensions
    {
        public static UserModel ChangeUserToModel(this User user)
        {
            var userModel = new UserModel()
            {
                Id = user.UserId,
                Name = user.Name,
                SurName = user.SurName,
                Firm = user.Firm
            };

            return userModel;
        }

        public static User ChangeModelToUser(this UserModel userModel)
        {
            var user = new User()
            {
                UserId = userModel.Id,
                Name = userModel.Name,
                SurName = userModel.SurName,
                Firm = userModel.Firm
            };

            return user;
        }
        public static List<UserModel> ChangeUserListToModel(this List<User> users)
        {
            var result = users.Select(x => new UserModel
            {
                Id = x.UserId,
                Name = x.Name,
                SurName = x.SurName,
                Firm = x.Firm
            })
                .ToList();

            return result;
        }

        public static UserWithContactModel UserModelWithContacts(this User user)
        {
            var userWithContact = new UserWithContactModel
            {
                Id = user.UserId,
                Firm = user.Firm,
                Name = user.Name,
                Surname = user.SurName,
                Contacts = user.Contacts != null ? user.Contacts.ChangeContactListToModel() : new List<ContactModel>()
            };

            return userWithContact;
        }

    }
}
