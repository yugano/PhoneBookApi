using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Database;
using WebApplication2.Management;
using WebApplication2.Extensions;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        UserManagement userManagement;
        ContactManagement contactManagement;
        public UsersController()
        {
            userManagement = new UserManagement();
            contactManagement = new ContactManagement();
        }


        [HttpGet]
        public IActionResult Get()
        {
            var result = userManagement.GetUsers().ChangeUserListToModel();

            return Ok(result);
        }

        [HttpGet("{userId}")]
        public IActionResult Get(Guid userId)
        {
            var result = userManagement.GetUserById(userId);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result.ChangeUserToModel());
        }

        [HttpGet("Get/Report")]
        public IActionResult GetReport()
        {
            var result = contactManagement.GetContactReport();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserModel user)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            var newUser = user.ChangeModelToUser();
            var result = userManagement.Create(newUser);

            if (result == null)
            {
                return Problem(detail: "Kayıt Sırasında Hata Meydana Geldi.");
            }

            return CreatedAtAction("Get", new { userId = result.UserId }, result.ChangeUserToModel());
        }

        [HttpPut]
        public IActionResult Put([FromBody] UserModel user)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            var isUserExist = userManagement.IsUserExist(user.Id);
            if (!isUserExist)
            {
                return NotFound();
            }


            var result = userManagement.Update(user.ChangeModelToUser());
            if (!result)
            {
                return Problem(detail: "Güncelleme Sırasında Hata Meydana Geldi");
            }


            return Ok();
        }

        [HttpDelete("{userId}")]
        public IActionResult Delete(Guid userId)
        {
            if (!userManagement.IsUserExist(userId))
            {
                return NotFound();
            }

            var result = userManagement.DeleteUser(userId);
            if (!result)
            {
                return Problem(detail: "Silme İşlemi Sırasında Hata Meydana Geldi");
            }

            return NoContent();
        }
    
       
    
    }
}
