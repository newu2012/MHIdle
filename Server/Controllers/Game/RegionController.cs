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
        return _db.Regions.ToArray();
    }

    [HttpGet("/api/region/{i:int}")]
    public Territory[] SelectedRegionInfo(int i)
    {
        //  TODO select all resources that Region mentions
        // var regionInfo = (from r in _db.Regions
        //     join t in _db.Territories on r.Id equals t.RegionId
        //     select new { Reg = r, Ter = t }).ToArray();

        var territory = _db.Territories.Where(t => t.RegionId == i).ToArray();

        return territory;
    }

    [HttpGet("/api/territory")]
    public Territory[] TerritoriesInfo()
    {
        return _db.Territories.Include(t => t.ResourceNodeProportions).ToArray();
    }

    [HttpGet("/api/item")]
    public Item[] ItemsInfo()
    {
        return _db.Items.ToArray();
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