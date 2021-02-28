using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Database;
using WebApplication2.Extensions;
using WebApplication2.Management;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]/{userId}")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        ContactManagement contactManagement;
        UserManagement userManagement;
        public ContactsController()
        {
            userManagement = new UserManagement();
            contactManagement = new ContactManagement();
        }


        [HttpGet]
        public IActionResult Get(Guid userId)
        {
            var user = userManagement.GetUserById(userId);
            if (user == null)
            {
                return NotFound();
            }

            var result = contactManagement.GetUsersAllContact(user.Id).ChangeContactListToModel();

            return Ok(result);
        }

        [HttpGet("{Id}")]
        public IActionResult Get(Guid userId, int Id)
        {
            var user = userManagement.GetUserById(userId);
            if (user == null)
            {
                return NotFound("Kullanıcı Bulunamadı");
            }

            var contact = contactManagement.GetContactById(user.Id, Id);
            if (contact == null)
            {
                return NotFound("İletişim Bilgisi Bulunamadı");
            }

            return Ok(contact.ChangeContactToModel());
        }

        [HttpGet]
        [Route("GetUserWithContact")]
        public IActionResult GetUserWithContact(Guid userId)
        {
            var result = userManagement.GetUserById(userId);
            if (result == null)
            {
                return NotFound();
            }

            var userContacts = userManagement.GetUserWithContacts(userId);


            return Ok(userContacts.UserModelWithContacts());
        }

        [HttpPost]
        public IActionResult CreateContact(Guid userId, ContactModel contactModel)
        {
            var user = userManagement.GetUserById(userId);
            if (user == null)
            {
                return NotFound("Kullanıcı Bulunamadı");
            }

            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            var contact = contactModel.ChangeModelToContact();
            contact.UserId = user.Id;

            var result = contactManagement.Create(contact);

            if (result == null)
            {
                return Problem(detail: "Kayıt Sırasında Hata Meydana Geldi");
            }

            return CreatedAtAction("Get", new { userId = userId, Id = result.Id }, result.ChangeContactToModel());
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(Guid userId, int Id)
        {
            var user = userManagement.GetUserById(userId);
            if (user == null)
            {
                return NotFound("Kullanıcı Bulunamadı");
            }

            var model = contactManagement.GetContactById(user.Id, Id);
            if (model == null)
            {
                return NotFound("Kayıt Bulunamadı");
            }

            var result = contactManagement.Delete(Id);
            if (!result)
            {
                return Problem(detail: "Silme İşlemi Sırasında Hata Meydana Geldi");
            }

            return NoContent();
        }
    

    
    }
}
