using DataContext.Postgresql;
using EntityModels.Postgresql;
using Microsoft.AspNetCore.Mvc;

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
        //  TODO Change to HttpPut with line below
        //  TODO Add file and name parameter for individual reseeding with custom files through API
        Reseed();
        await _db.SaveChangesAsync();

        return;
    }

    private void Reseed()
    {
        var newResources = EntitySeeding.Seeding<Resource>().ToArray();
        //  TODO Delete items that are not in Seed file 
        for (var i = 0; i < newResources.Length; i++)
        {
            if (_db.Resources.Any(r => r.ResourceId == newResources[i].ResourceId))
            {
                _db.Resources.Update(newResources[i]);
            }
            else
            {
                _db.Resources.Add(newResources[i]);
            }
        }
    }
}