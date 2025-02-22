using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusCodesController : ControllerBase
    {
        LogsDbContext db;
        public StatusCodesController(LogsDbContext context)
        {
            db = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusCode>>> Get()
        {
            return await db.LogsStatusCodes.ToListAsync();
        }
        // GET api/logrecords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusCode>> Get(string id)
        {
            StatusCode statusCode = await db.LogsStatusCodes.FirstOrDefaultAsync(x => x.Status == id);
            if (statusCode == null)
                return NotFound();
            return new ObjectResult(statusCode);
        }
    }
}
