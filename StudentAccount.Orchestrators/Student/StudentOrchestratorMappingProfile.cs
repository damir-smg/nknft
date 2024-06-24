using AutoMapper;
using StudentAccount.Orchestrators.Student.Contract;

namespace StudentAccount.Orchestrators.Student;

public class StudentOrchestratorMappingProfile : Profile
{
    public StudentOrchestratorMappingProfile()
    {
        CreateMap<CreateStudentRequest, Model.Student.Student>().ReverseMap();
        CreateMap<UpdateStudentRequest, Model.Student.Student>().ReverseMap();
    }
}