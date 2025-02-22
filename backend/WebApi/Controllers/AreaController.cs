using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        LogsDbContext db;
        public AreaController(LogsDbContext context)
        {
            db = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Area>>> Get()
        {
            return await db.AreaNumbers.ToListAsync();
        }
        // GET api/logrecords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Area>> Get(string id)
        {
            Area area = await db.AreaNumbers.FirstOrDefaultAsync(x => x.AreaNumber == id);
            if (area == null)
                return NotFound();
            return new ObjectResult(area);
        }
    }
}
