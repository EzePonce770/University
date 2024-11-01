using Microsoft.AspNetCore.Mvc;
using UniversityService.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace University.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorService _professorService;

        public ProfessorController(IProfessorService professorService)
        {
            _professorService = professorService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_professorService.GetProfessorCourse());
        }
    }
}
