using DataContext.Postgresql;
using EntityModels.Postgresql;
using Microsoft.AspNetCore.Mvc;

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

    //  TODO Change to     "/api/region/${i}"
    [HttpGet("/api/region")]
    public Item[] RegionInfo()
    {
        //  TODO select all resources that Region mentions
        return _db.Items.ToArray();
    }
}