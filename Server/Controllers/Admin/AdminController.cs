﻿using DataContext.Postgresql;
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
        ReseedItems();
        Reseed<Region>();
        Reseed<Territory>();
        Reseed<ResourceNode>();
        ReseedMonster();
        Reseed<TerritoryEventItem>();
        Reseed<TerritoryEventProportion>();
        Reseed<Recipe>();
        Reseed<RecipeMaterial>();

        await _db.SaveChangesAsync();
    }

    private void Reseed<T>() where T : class
    {
        var newObjects = EntitySeeding.Seeding<T>().ToArray();
        var table = _db.Set<T>();

        //  TODO Think out some clean way to updateOrAdd only when not equals (Equals() seems like not a clean way) 
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

    private void ReseedItems()
    {
        Reseed<Resource>();
        Reseed<Instrument>();
    }

    private void ReseedMonster()
    {
        Reseed<Monster>();
        Reseed<MonsterPart>();
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