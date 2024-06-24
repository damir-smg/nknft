using AutoMapper;
using StudentAccount.Orchestrators.Discipline.Contract;

namespace StudentAccount.Orchestrators.Discipline;

public class DisciplineOrchestratorMappingProfile : Profile
{
    public DisciplineOrchestratorMappingProfile()
    {
        CreateMap<CreateDisciplineRequest, Model.Discipline.Discipline>().ReverseMap();
        CreateMap<UpdateDisciplineRequest, Model.Discipline.Discipline>().ReverseMap();
    }
}