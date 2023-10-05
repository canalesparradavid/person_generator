using Microsoft.AspNetCore.Mvc;
using PersonGenerator.Models;
using PersonGenerator.Services;

namespace PersonGenerator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {

        private readonly IPersonProvider _personProvider;

        public PersonController(IPersonProvider personProvider)
        {
            _personProvider = personProvider;
        }

        [HttpGet("Get/{quantity}", Name = "Get")]
        public ICollection<Person> Get(int quantity = 1)
        {
            return _personProvider.Get(quantity);
        }
    }
}