using AutoMapper;
using SmartSchool.WebAPI.DTOs;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Helpers

{
    public class SmartSchoolProfile : Profile
    {
        public SmartSchoolProfile()
        {
            CreateMap<Aluno, AlunoDTO>()
                    .ForMember(
                        dest => dest.Nome,
                        opt => opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}")
                    )
                    .ForMember(
                        dest => dest.Idade,
                        opt => opt.MapFrom(src => src.DataNascimento.GetCurrentAge())
                    );
            CreateMap<AlunoDTO, Aluno>();
            CreateMap<Aluno, AlunoRegistradorDTO>().ReverseMap();
        }
    }
}