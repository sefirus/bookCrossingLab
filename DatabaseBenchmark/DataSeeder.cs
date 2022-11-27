using Core.Entities;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseBenchmark;

public class DataSeeder
{
    private bool _isDataSeeded = false;
    private BookCrossingContext _bookCrossingContext;
    public DataSeeder(BookCrossingContext context)
    {
        _bookCrossingContext = context;
    }

    private async Task OverrideDataAsync(int count)
    {
        if (_isDataSeeded)
        {
            var existingShelves = await _bookCrossingContext.Shelves.ToListAsync();
            _bookCrossingContext.Shelves.RemoveRange(existingShelves);
            await _bookCrossingContext.SaveChangesAsync();
        }
        var r = new Random();
        var newShelves = new List<Shelf>();
        for (int i = 0; i < count; i++)
        {
            var newShelf = new Shelf()
            {
                Title = Guid.NewGuid().ToString(),
                FormattedAddress = Guid.NewGuid().ToString(),
                Latitude = r.NextDouble(),
                Longitude = r.NextDouble(),
                CreatedAt = DateTime.UtcNow
            };
            newShelves.Add(newShelf);
        }
        _bookCrossingContext.AddRange(newShelves);
        await _bookCrossingContext.SaveChangesAsync();
        _isDataSeeded = true;
    }

    public async Task SeedTwentyAsync()
    {
        await OverrideDataAsync(20);
    }

    public async Task SeedHundredThousandsAsync()
    {
        await OverrideDataAsync(100000);
    }
}
