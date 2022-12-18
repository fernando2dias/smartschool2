using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        public readonly IRepository _repo;
        public AlunoController(IRepository repo)
        {
            _repo = repo;


        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllAlunos(true);
            return Ok(result);

        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAlunoById(id, false);
            if (aluno == null)
                return BadRequest("Aluno não encontrado!");

            return Ok(aluno);
        }


        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _repo.Add(aluno);
            if (_repo.SaveChanges())
                return Ok(aluno);
            return BadRequest("Erro ao cadastrar =(");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alu = _repo.GetAlunoById(id, false);
            if (alu == null)
                return BadRequest("Aluno não encontrado!");

            _repo.Update(aluno);
            if (_repo.SaveChanges())
                return Ok(aluno);
            return BadRequest("Erro ao atualizar =(");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {

            var alu = _repo.GetAlunoById(id, false);
            if (alu == null)
                return BadRequest("Aluno não encontrado!");

            _repo.Update(aluno);
            if (_repo.SaveChanges())
                return Ok(aluno);
            return BadRequest("Erro ao atualizar =(");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _repo.GetAlunoById(id, false);

            if (aluno == null)
                return BadRequest("Aluno não encontrado!");

            _repo.Delete(aluno);
            if (_repo.SaveChanges())
                return Ok("Aluno removido");
            return BadRequest("Erro ao remover =(");
        }

    }
}