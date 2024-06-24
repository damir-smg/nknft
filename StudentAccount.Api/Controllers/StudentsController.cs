using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAccount.Model.Student;
using StudentAccount.Orchestrators.Student.Contract;

namespace StudentAccount.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IStudentOrchestrator _studentOrchestrator;

    public StudentsController(IMapper mapper,
        IStudentOrchestrator studentOrchestrator)
    {
        _mapper = mapper;
        _studentOrchestrator = studentOrchestrator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Student>>> Get()
    {
        var students = await _studentOrchestrator.GetAllAsync();

        return Ok(students);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var student = await _studentOrchestrator.GetByIdAsync(id);
        return Ok(student);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateStudentRequest studentRequest)
    {
        var student = _mapper.Map<Student>(studentRequest);
        var createdModel = await _studentOrchestrator.CreateAsync(student);

        return Ok(createdModel);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateStudentRequest studentRequest)
    {
        var student = _mapper.Map<Student>(studentRequest);
        student.Id = id;
        var updatedModel = await _studentOrchestrator.UpdateAsync(id, student);

        return Ok(updatedModel);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deletedModel = await _studentOrchestrator.DeleteAsync(id);

        return Ok(deletedModel);
    }
}