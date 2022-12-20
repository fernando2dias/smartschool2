using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.DTOs;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        public readonly IRepository _repo;
        private readonly IMapper _mapper;
        public AlunoController(IRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;


        }

        [HttpGet]
        public IActionResult Get()
        {
            var alunos = _repo.GetAllAlunos(true);

            return Ok(_mapper.Map<IEnumerable<AlunoDTO>>(alunos));

        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAlunoById(id, false);
            if (aluno == null)
                return BadRequest("Aluno não encontrado!");

            var alunoDTO = _mapper.Map<AlunoDTO>(aluno);

            return Ok(alunoDTO);
        }


        [HttpPost]
        public IActionResult Post(AlunoRegistradorDTO model)
        {
            var aluno = _mapper.Map<Aluno>(model);

            _repo.Add(aluno);
            if (_repo.SaveChanges())
                return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDTO>(aluno));
            return BadRequest("Erro ao cadastrar =(");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, AlunoRegistradorDTO model)
        {
            var aluno = _repo.GetAlunoById(id, false);
            if (aluno == null)
                return BadRequest("Aluno não encontrado!");

            _mapper.Map(model, aluno);

            _repo.Update(aluno);
            if (_repo.SaveChanges())
                return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDTO>(aluno));
            return BadRequest("Erro ao atualizar =(");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, AlunoRegistradorDTO model)
        {

            var aluno = _repo.GetAlunoById(id, false);
            if (aluno == null)
                return BadRequest("Aluno não encontrado!");

            _mapper.Map(model, aluno);

            _repo.Update(aluno);
            if (_repo.SaveChanges())
                return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDTO>(aluno));
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