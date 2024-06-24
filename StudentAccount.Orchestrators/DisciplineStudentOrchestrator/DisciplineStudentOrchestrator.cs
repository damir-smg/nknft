using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StudentAccount.Model.Discipline;
using StudentAccount.Model.DisciplineStudent;
using StudentAccount.Model.Student;
using StudentAccount.Platform.BlobStorage;

namespace StudentAccount.Orchestrators.DisciplineStudentOrchestrator;

public class DisciplineStudentOrchestrator : IDisciplineStudentOrchestrator
{
    private readonly IBlobStorage _blobStorage;
    private readonly IDisciplineOrchestrator _disciplineOrchestrator;
    private readonly IStudentOrchestrator _studentOrchestrator;

    public DisciplineStudentOrchestrator(IStudentOrchestrator studentOrchestrator,
        IDisciplineOrchestrator disciplineOrchestrator, IBlobStorage blobStorage)
    {
        _studentOrchestrator = studentOrchestrator;
        _disciplineOrchestrator = disciplineOrchestrator;
        _blobStorage = blobStorage;
    }

    public async Task<DisciplineStudent> CreateAsync(Guid disciplineId, int studentId)
    {
        var student = await _studentOrchestrator.GetByIdAsync(studentId);
        var discipline = await _disciplineOrchestrator.GetByIdAsync(disciplineId);

        var relationFileName = $"{disciplineId:N}_{studentId}";
        var exists = await _blobStorage.ContsinsFileByNameAsync(relationFileName);

        if (!exists) await _blobStorage.PutContentAsync(relationFileName);

        return new DisciplineStudent
        {
            StudentId = studentId,
            DisciplineId = disciplineId
        };
    }

    public async Task<List<int>> GetStudentsAsync(Guid disciplineId)
    {
        var course = await _disciplineOrchestrator.GetByIdAsync(disciplineId);

        var studentIds = _blobStorage.FindByDiscipline(disciplineId);

        return studentIds;
    }
}