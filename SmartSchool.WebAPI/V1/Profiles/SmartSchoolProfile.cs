using AutoMapper;
using SmartSchool.WebAPI.V1.Dtos;
using SmartSchool.WebAPI.Models;
using SmartSchool.WebAPI.Helpers;

namespace SmartSchool.WebAPI.V1.Profiles
{
    public class SmartSchoolProfile : Profile // Tem que ter essa herança com o using do AutoMapper
    {
        // Construtor
        public SmartSchoolProfile()
        {
            // Toda Vez que for Chamado meu (Aluno) tem que ser mapeado com meu (AlunoDto).
            CreateMap<Aluno, AlunoDto>()
                    .ForMember(
                        dest => dest.Nome,
                        opt => opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}")
                    )
                    .ForMember(
                        dest => dest.Idade,
                        opt => opt.MapFrom(src => src.DataNasc.GetCurrentAge())
                    );

            CreateMap<AlunoDto, Aluno>();
            CreateMap<Aluno, AlunoRegistrarDto>().ReverseMap();
            CreateMap<Aluno, AlunoPatchDto>().ReverseMap();

            CreateMap<Professor, ProfessorDto>()
                .ForMember(
                    dest => dest.Nome,
                    opt => opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}")
                );
            
            CreateMap<ProfessorDto, Professor>();
            CreateMap<Professor, ProfessorRegistrarDto>().ReverseMap();

            CreateMap<DisciplinaDto, Disciplina>().ReverseMap();
            CreateMap<CursoDto, Curso>().ReverseMap();
        }
    }
}