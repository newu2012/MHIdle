using DataContext.Postgresql;
using EntityModels.Postgresql;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Server.Controllers.Game;

[ApiController]
[Route("/api/region")]
public class RegionController : ControllerBase
{
    private MHIdleContext _db;

    public RegionController(MHIdleContext db)
    {
        _db = db;
    }

    [HttpGet("/api/region")]
    public Region[] RegionsInfo()
    {
        return _db.Regions.Include(r => r.Territories).ToArray();
    }

    [HttpGet("/api/territory")]
    public Territory[] TerritoriesInfo()
    {
        return _db.Territories.Include(t => t.ResourceNodeProportions).ToArray();
    }

    [HttpGet("/api/resource")]
    public Resource[] ResourcesInfo()
    {
        return _db.Resources.ToArray();
    }
    
    [HttpGet("/api/instrument")]
    public Instrument[] InstrumentsInfo()
    {
        return _db.Instruments.ToArray();
    }

    [HttpGet("/api/recipe")]
    public Recipe[] RecipesInfo()
    {
        return _db.Recipe.Include(r => r.RecipeMaterials).ToArray();
    }

    [HttpGet("/api/event")]
    public ResourceNodeEvent[] EventsInfo()
    {
        return _db.ResourceNodeEvents
            .Include(rne => rne.ResourceNodeItems)
            .Include(rne => rne.ResourceNodeProportions)
            .ToArray();
    }
}