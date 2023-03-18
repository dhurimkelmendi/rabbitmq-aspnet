using HashApi.Models;
using HashApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HashApi.Controllers
{
    [Route("api/hashes")]
    [ApiController]
    public class HashesController : ControllerBase
    {
        private readonly IHashService _hashService;

        public HashesController(IHashService hashService)
        {
            _hashService = hashService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var hashes = _hashService.GetHashesByDay(10);

            return Ok(hashes);
        }

        [HttpPost]
        public IActionResult Post()
        {
            _hashService.GenerateRandomSHA1Hashes(4);

            return Ok();
        }
    }
}
