using Core.Entities;
using DataAccess.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


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

        await _seeder.SeedTwentyAsync();
        var stopWatch1 = new Stopwatch();
        stopWatch1.Start();
        var tplRegular20 = new Task<List<Shelf>>(_bookCrossingContext.Shelves.ToList);
        tplRegular20.Start();
        tplRegular20.Wait();
        stopWatch1.Stop();
        var tplRegular20Time =  stopWatch1.Elapsed.Ticks;
        
        await _seeder.SeedHundredThousandsAsync();
        var stopWatch2 = new Stopwatch();
        stopWatch2.Start();
        var tplRegular100000 = new Task<List<Shelf>>(_bookCrossingContext.Shelves.ToList);
        tplRegular100000.Start();
        tplRegular100000.Wait();
        stopWatch2.Stop();
        var tplRegular100000Time =  stopWatch2.Elapsed.Ticks;

        result.TplRegular = new ConcreteResultModel()
        {
            TwentyRows = tplRegular20Time,
            HundredThousandsRows = tplRegular100000Time
        };

        await _seeder.SeedTwentyAsync();
        var stopWatch3 = new Stopwatch();
        stopWatch3.Start();
        var tplParallel20 = new Task<List<Shelf>>(_bookCrossingContext.Shelves.AsParallel().ToList);
        tplParallel20.Start();
        tplParallel20.Wait();
        stopWatch3.Stop();
        var tplParallel20Time = stopWatch3.Elapsed.Ticks;

        await _seeder.SeedHundredThousandsAsync();
        var stopWatch4 = new Stopwatch();
        stopWatch4.Start();
        var tplParallel100000 = new Task<List<Shelf>>(_bookCrossingContext.Shelves.AsParallel().ToList);
        tplParallel100000.Start();
        tplParallel100000.Wait();
        stopWatch4.Stop();
        var tplParallel100000Time = stopWatch4.Elapsed.Ticks;

        result.TplParallel = new ConcreteResultModel()
        {
            TwentyRows = tplParallel20Time,
            HundredThousandsRows = tplParallel100000Time
        };

        return result;
    }
}
