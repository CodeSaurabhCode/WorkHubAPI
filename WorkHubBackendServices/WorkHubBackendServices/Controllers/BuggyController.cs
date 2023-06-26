using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkHubBackEndServices.Data;
using WorkHubBackEndServices.Errors;

namespace WorkHubBackEndServices.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly ApplicationDbContext _db;

        public BuggyController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet("notfound")]

        public ActionResult GetNotFoundRequest()
        {
            var thing = _db.Items.Find(42);
            if (thing == null)
            {
                return NotFound(new ApiResponse(400));
            }
                
            return Ok();
        }

        [HttpGet("servererror")]

        public ActionResult GetServerError()
        {
            var thing = _db.Items.Find(42);
            var thingtoreturn = thing.ToString();


            return Ok();
        }

        [HttpGet("badrequest")]

        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(401));
        }

        [HttpGet("badrequest/{id}")]

        public ActionResult GetBadRequest(int id)
        {
            return BadRequest();
        }
    }
}
