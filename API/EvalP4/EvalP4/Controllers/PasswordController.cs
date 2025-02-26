using Microsoft.AspNetCore.Mvc;
using Repositories.Entities;
using Services.Services;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordsController : ControllerBase
    {
        private readonly IPasswordService _passwordService;

        public PasswordsController(IPasswordService passwordService)
        {
            _passwordService = passwordService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Password>> GetPasswords()
        {
            var passwords = _passwordService.GetAllPasswords();
            return Ok(passwords);
        }

        [HttpPost]
        public ActionResult AddPassword(Password password)
        {
            _passwordService.AddPassword(password);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePassword(int id)
        {
            _passwordService.DeletePassword(id);
            return Ok();
        }
    }
}
