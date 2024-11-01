using Microsoft.AspNetCore.Mvc;
using UniversityService.Interfaces;


namespace University.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PangramController : ControllerBase
    {
        private readonly IPangramService _service;

        public PangramController(IPangramService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Post([FromBody] List<string> pangrams)
        {
            if (pangrams == null || !pangrams.Any())
            {
                return BadRequest("Los datos ingresados son nullos o vacios, revise los mismos.");
            }

            return Ok(_service.IsPangram(pangrams));
        }

    }
}
