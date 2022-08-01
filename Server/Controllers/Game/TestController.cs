using DataContext.Postgresql;
using EntityModels.Postgresql;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers.Game;

[ApiController]
[Route("")]
public class TestController : ControllerBase
{
    private MHIdleContext _db;

    public TestController(MHIdleContext db)
    {
        _db = db;
    }

    [HttpGet("/test")]
    public Region[] Index()
    {
        return _db.Regions.ToArray();
    }
}