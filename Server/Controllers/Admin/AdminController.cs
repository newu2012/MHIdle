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

        await ReseedAll();
        return;
    }

    private async Task ReseedAll()
    {
        //  TODO Think out how to split Item.json to Resource.json and other types of items
        Reseed<Item>();
        Reseed<Region>();
        Reseed<Territory>();
        Reseed<ResourceNodeEvent>();
        Reseed<ResourceNodeItem>();
        Reseed<ResourceNodeProportion>();
        Reseed<Recipe>();
        Reseed<RecipeMaterial>();

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
            if (table.AsNoTracking().AsEnumerable().Any(r => PropertiesAreEqual(r, obj)))
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

    private bool PropertiesAreEqual<T>(T val, T obj)
    {
        var valId = (int)(val?.GetType().GetProperty("Id")?.GetValue(val) ?? 0);
        var objId = (int)(obj?.GetType().GetProperty("Id")?.GetValue(obj) ?? 0);
        Console.WriteLine(valId);
        Console.WriteLine(objId);

        return valId == objId;
    }
}