using Microsoft.AspNetCore.Mvc;

namespace Antiforgery.Controllers {

    public class Person {
        public string Name { set; get; }
    }

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HelloController : ControllerBase {
        [HttpGet()]
        public ActionResult<dynamic> Hi() {
            return new {
                Message = "Hello, world!"
            };
        }

        [HttpPost()]
        public ActionResult<dynamic> Who(Person person) {
            return new {
                Message = "Who know"
            };
        }
    }
}