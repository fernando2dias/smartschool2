using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>()
        {
            new Aluno()
            {
                Id = 1,
                Nome = "Juliana",
                Sobrenome = "Michelsen",
                Telefone = "132132134"
            },
            new Aluno()
            {
                Id = 2,
                Nome = "Francisco",
                Sobrenome = "Michelsen",
                Telefone = "16564334"
            },
            new Aluno()
            {
                Id = 3,
                Nome = "Preta",
                Sobrenome = "Michelsen",
                Telefone = "454534345"
            },
            new Aluno()
            {
                Id = 4,
                Nome = "Fernando",
                Sobrenome = "Motta",
                Telefone = "145454333"
            },


        };

        public AlunoController()
        {

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null)
            {
                return BadRequest("Aluno não encontrado!");
            }

            return Ok(aluno);
        }

    }
}