using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOs;
using WebAPI.Filters;
using WebAPI.Model;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(ActionFilter))]
    public class SubmissionController : ControllerBase
    {
        private readonly ISubmissionService _submissionService;

        public SubmissionController(ISubmissionService submissionService)
        {
            _submissionService = submissionService;
        }
        
        [HttpGet()]
        [ActionFilter]
        public string Get()
        {
            return "value";
        }

        [HttpGet("{id}")]
        [ActionFilter]
        public string Get(int id)
        {
            return "value"+ id;
        }

    
     
      
        [HttpPost]
        public async Task<IActionResult> PostSubmission([FromForm] RegistrationModel registration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Submittionresult =_submissionService.InsertNewSubmission(registration);
            if (Submittionresult)
            {
                return Ok("successfull");
            }
            else
            {
                return BadRequest("Failed");
            }

        }
    }
}
