using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StudentAccount.Model.Student;

namespace StudentAccount.Orchestrators.Student;

public class StudentOrchestrator : IStudentOrchestrator
{
    private readonly IStudentRepository _studentRepository;

    public StudentOrchestrator(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<IEnumerable<Model.Student.Student>> GetAllAsync()
    {
        return await _studentRepository.GetAllAsync();
    }

    public async Task<Model.Student.Student> GetByIdAsync(int id)
    {
        var student = await _studentRepository.GetByIdAsync(id);

        if (student == null)
            throw new Exception($"Student with id {id} not found");

        return student;
    }

    public async Task<Model.Student.Student> CreateAsync(Model.Student.Student studentRequest)
    {
        return await _studentRepository.CreateAsync(studentRequest);
    }

    public async Task<Model.Student.Student> UpdateAsync(int id, Model.Student.Student updatedStudent)
    {
        var student = await GetByIdAsync(id);

        student.FirstName = updatedStudent.FirstName;
        student.LastName = updatedStudent.LastName;

        return await _studentRepository.UpdateAsync(student);
    }

    public async Task<Model.Student.Student> DeleteAsync(int id)
    {
        var student = await GetByIdAsync(id);
        await _studentRepository.DeleteAsync(id);

        return student;
    }
}