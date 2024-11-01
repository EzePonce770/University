using Microsoft.AspNetCore.Mvc;
using UniversityService.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace University.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;
        public ArticleController(IArticleService article)
        {     
            _articleService = article;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_articleService.GetResultHttp().Result);
        }
    }
}
