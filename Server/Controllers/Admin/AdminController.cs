using System.Reflection;
using DataContext.Postgresql;
using EntityModels.Postgresql;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Server.Controllers.Admin;

[ApiController]
[Route("/api/admin")]
public class AdminController : ControllerBase
{
    private MHIdleContext _db;

    public AdminController(MHIdleContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task UpdateSeeds()
    {
        //  TODO Add identity check

        //  TODO Change to HttpPut with line below
        //  TODO Add file and name parameter for individual reseeding with custom files through API
        await ReseedAll();

        return;
    }

    private async Task ReseedAll()
    {
        Reseed<Item>();
        Reseed<Region>();
        Reseed<Territory>();
        Reseed<TerritoryEvent>();
        
        await _db.SaveChangesAsync();
    }

    private void Reseed<T>() where T : class
    {
        var newObjects = EntitySeeding.Seeding<T>().ToArray();
        var table = _db.Set<T>();

        //  TODO Set up Equals for Entities to update entities without deleting all the time

        //  Delete all current rows and add new from Seeds file
        // _db.Database.ExecuteSqlRaw($"TRUNCATE \"{typeof(T).Name}\" RESTART IDENTITY");
        foreach (var obj in newObjects)
        {
            if (table.AsNoTracking().AsEnumerable().Any(r => r.GetType().GetProperty("id") == obj.GetType().GetProperty("id")))
            {
                table.Update(obj);
            }
            else
            {
                table.Add(obj);
            }
        }

        _db.SaveChanges();
    }
}