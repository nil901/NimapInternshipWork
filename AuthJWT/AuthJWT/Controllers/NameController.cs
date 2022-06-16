using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthJWT.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NameController : ControllerBase
    { 

        private readonly IjwtAuthicationManager jwtAuthicationManager;
        public NameController(IjwtAuthicationManager jwtAuthicationManager)
        {
           this.jwtAuthicationManager = jwtAuthicationManager;
        }
        // GET: api/<NameController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "New Jersey", "Nwe York" };
        }

        // GET api/<NameController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        [AllowAnonymous]
        [HttpPost("authentcat")]
        public IActionResult Authentcate([FromBody] UserCred userCred ) 
         {
       var token =  jwtAuthicationManager.Authenticate(userCred.UserName, userCred.Passworld);
            if (token == null)
            
            return Unauthorized();
             
             return Ok(token); 

        }
    }
}
