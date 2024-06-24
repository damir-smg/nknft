using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentAccount.Model.Student;

namespace StudentAccount.Dal.Student;

public class StudentRepository : IStudentRepository
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    public StudentRepository(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<Model.Student.Student>> GetAllAsync()
    {
        var entities = await _dbContext.Students.AsNoTracking().ToListAsync();

        return _mapper.Map<List<Model.Student.Student>>(entities);
    }

    public async Task<Model.Student.Student> GetByIdAsync(int id)
    {
        var entity = await _dbContext.Students.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        return _mapper.Map<Model.Student.Student>(entity);
    }

    public async Task<Model.Student.Student> CreateAsync(Model.Student.Student model)
    {
        var entity = _mapper.Map<StudentDao>(model);
        var result = await _dbContext.Students.AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        return _mapper.Map<Model.Student.Student>(result.Entity);
    }

    public async Task<Model.Student.Student> UpdateAsync(Model.Student.Student model)
    {
        var existingEntity = _mapper.Map<StudentDao>(model);
        var entityEntry = _dbContext.Students.Update(existingEntity);

        await _dbContext.SaveChangesAsync();

        return _mapper.Map<Model.Student.Student>(entityEntry.Entity);
    }

    public async Task DeleteAsync(int id)
    {
        var existingEntity = await _dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);

        if (_dbContext.Entry(existingEntity).State == EntityState.Detached)
            _dbContext.Students.Attach(existingEntity);

        _dbContext.Students.Remove(existingEntity);
        await _dbContext.SaveChangesAsync();
    }
}