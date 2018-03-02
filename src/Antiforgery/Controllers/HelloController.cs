using Microsoft.AspNetCore.Mvc;

namespace Antiforgery.Controllers {

    public class Person {
        public string Name { set; get; }
    }

    [Route("api/[controller]/[action]")]
    public class HelloController : ControllerBase {
        [HttpGet()]
        public dynamic Hi() {
            return new {
                Message = "Hello, world!"
            };
        }

        [HttpPost()]
        public dynamic Who([FromBody] Person person) {
            return new {
                Message = "Who know"
            };
        }
    }
}