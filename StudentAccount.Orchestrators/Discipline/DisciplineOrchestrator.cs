using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StudentAccount.Model.Discipline;
using StudentAccount.Platform.ServiceBus;

namespace StudentAccount.Orchestrators.Discipline;

public class DisciplineOrchestrator : IDisciplineOrchestrator
{
    private readonly IDisciplineRepository _disciplineRepository;
    private readonly IPublisher _publisher;

    public DisciplineOrchestrator(IDisciplineRepository disciplineRepository, IPublisher publisher)
    {
        _disciplineRepository = disciplineRepository;
        _publisher = publisher;
    }

    public async Task<Model.Discipline.Discipline> GetByIdAsync(Guid id)
    {
        var discipline = await _disciplineRepository.GetByIdAsync(id);

        if (discipline == null)
            throw new Exception($"Discipline with id {id.ToString()} not found");

        return discipline;
    }

    public async Task<List<Model.Discipline.Discipline>> GetAllAsync()
    {
        return await _disciplineRepository.GetAllAsync();
    }

    public async Task<Model.Discipline.Discipline> CreateAsync(Model.Discipline.Discipline model)
    {
        var discipline = await _disciplineRepository.CreateAsync(model);
        await _publisher.PublishAsync(discipline.Id);
        
        return discipline;
    }

    public async Task<Model.Discipline.Discipline> UpdateAsync(Guid id, Model.Discipline.Discipline modelToUpdate)
    {
        var discipline = await GetByIdAsync(id);

        discipline.Name = modelToUpdate.Name;
        discipline.Mark = modelToUpdate.Mark;

        return await _disciplineRepository.UpdateAsync(discipline);
    }

    public async Task<Model.Discipline.Discipline> DeleteAsync(Guid id)
    {
        var discipline = await GetByIdAsync(id);
        await _disciplineRepository.DeleteAsync(id);

        return discipline;
    }
}