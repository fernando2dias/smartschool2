using Microsoft.AspNetCore.Mvc;

namespace SmartSchool.WebAPI.Controllers
{
    public class ProfessorController : ControllerBase
    {
        public ProfessorController()
        {

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Professores: Fernando, Anderson, Lucas, Bruno");
        }
    }
}