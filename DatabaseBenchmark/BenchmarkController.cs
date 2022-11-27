using Core.Entities;
using DataAccess.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DatabaseBenchmark;

[Route("benckmark")]
[ApiController]
public class BenchmarkController
{
    private DataSeeder _seeder;
    private BookCrossingContext _bookCrossingContext;
    public BenchmarkController(BookCrossingContext context)
    {
        _seeder = new DataSeeder(context);
        _bookCrossingContext = context;
    }

    private async Task<long> RunRegular(Task seedingTask)
    {
        await seedingTask;
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        await _bookCrossingContext.Shelves.ToListAsync();
        stopWatch.Stop();
        return stopWatch.Elapsed.Ticks;
    }
    
    private async Task<long> RunParallel(Task seedingTask)
    {
        await seedingTask;
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        _bookCrossingContext.Shelves.AsParallel().ToList();
        stopWatch.Stop();
        return stopWatch.Elapsed.Ticks;
    }

    private async Task<long> RunTplRegular(Task seedingTask)
    {
        await seedingTask;
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        var tplRegular = new Task<List<Shelf>>(_bookCrossingContext.Shelves.ToList);
        tplRegular.Start();
        tplRegular.Wait();
        stopWatch.Stop();
        return stopWatch.Elapsed.Ticks;
    }

    private async Task<long> RunTplParallel(Task seedingTask)
    {
        await seedingTask;
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        var tplParallel = new Task<List<Shelf>>(_bookCrossingContext.Shelves.AsParallel().ToList);
        tplParallel.Start();
        tplParallel.Wait();
        stopWatch.Stop();
        return stopWatch.Elapsed.Ticks;
    }

    [HttpGet]
    public async Task<BenchmarkResultModel> RunBenchmarkAsync()
    {
        var result = new BenchmarkResultModel();

        var regular20 = await RunRegular(_seeder.SeedTwentyAsync());
        var regular100000 = await RunRegular(_seeder.SeedHundredThousandsAsync());
        result.Regular = new ConcreteResultModel()
        {
            TwentyRows = regular20,
            HundredThousandsRows = regular100000
        };

        var parallel20 = await RunParallel(_seeder.SeedTwentyAsync());
        var parallel100000 = await RunParallel(_seeder.SeedHundredThousandsAsync());
        result.Parallel = new ConcreteResultModel()
        {
            TwentyRows = parallel20,
            HundredThousandsRows = parallel100000
        };

        var tplRegular20Time = await RunTplRegular(_seeder.SeedTwentyAsync());
        var tplRegular100000Time = await RunTplRegular(_seeder.SeedHundredThousandsAsync());

        result.TplRegular = new ConcreteResultModel()
        {
            TwentyRows = tplRegular20Time,
            HundredThousandsRows = tplRegular100000Time
        };

        var tplParallel20Time = await RunTplParallel(_seeder.SeedTwentyAsync());
        var tplParallel100000Time = await RunTplParallel(_seeder.SeedHundredThousandsAsync());

        result.TplParallel = new ConcreteResultModel()
        {
            TwentyRows = tplParallel20Time,
            HundredThousandsRows = tplParallel100000Time
        };

        return result;
    }
}
