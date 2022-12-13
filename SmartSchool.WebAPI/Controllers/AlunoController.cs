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

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null)
            {
                return BadRequest("Aluno não encontrado!");
            }

            return Ok(aluno);
        }

        [HttpGet("byName/{nome}")]
        public IActionResult GetByName(string nome)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(nome));
            if (aluno == null)
            {
                return BadRequest("Aluno não encontrado!");
            }

            return Ok(aluno);
        }


        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok("Aluno removido!");
        }

    }
}