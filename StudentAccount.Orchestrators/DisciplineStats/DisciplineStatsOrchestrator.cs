using System.Collections.Generic;
using System.Threading.Tasks;
using StudentAccount.Model.DisciplineStats;
using StudentAccount.Platform.ServiceBus;

namespace StudentAccount.Orchestrators.DisciplineStats;

public class DisciplineStatsOrchestrator : IDisciplineStatsOrchestrator
{
    private readonly ISubscriber _subscriber;

    public DisciplineStatsOrchestrator(ISubscriber subscriber)
    {
        _subscriber = subscriber;
    }

    public async Task<List<string>> GetStatsAsync()
    {
        return _subscriber.Data;
    }
}