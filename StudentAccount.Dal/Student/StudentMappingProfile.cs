using AutoMapper;

namespace StudentAccount.Dal.Student;

public class StudentMappingProfile : Profile
{
    public StudentMappingProfile()
    {
        CreateMap<Model.Student.Student, StudentDao>().ReverseMap();
    }
}