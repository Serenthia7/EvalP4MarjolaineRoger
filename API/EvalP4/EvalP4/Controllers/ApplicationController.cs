using Microsoft.AspNetCore.Mvc;
using Repositories.Entities;
using Services.Services;
using Services.ServicesContracts;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationsController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        // GET: api/applications
        [HttpGet]
        public ActionResult<IEnumerable<Application>> GetApplications()
        {
            var applications = _applicationService.GetAllApplications();
            return Ok(applications);
        }

        // POST: api/applications
        [HttpPost]
        public ActionResult AddApplication(Application application)
        {
            _applicationService.AddApplication(application);
            return Ok();
        }

        // POST: api/applications/addpassword
        [HttpPost("addpassword")]
        public ActionResult AddPasswordToApplication(int applicationId, int passwordId)
        {
            _applicationService.AddPasswordToApplication(applicationId, passwordId);
            return Ok();
        }
    }
}
