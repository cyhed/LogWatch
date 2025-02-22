using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogRecordsController : ControllerBase
    {
        LogsDbContext db;
        public LogRecordsController(LogsDbContext context)
        {
            db = context;            
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogRecord>>> Get(int skip = 0, int take = 0)
        {
            IQueryable<LogRecord> logs = db.Logs.AsQueryable();
            
            return await logs.OrderBy(p => p.DateTime).Skip(skip).Take(take).ToListAsync();
        }
        // GET api/logrecords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LogRecord>> Get(string id)
        {
            LogRecord logRecord = await db.Logs.FirstOrDefaultAsync(x => x.Guid == id);
            if (logRecord == null)
                return NotFound();
            return new ObjectResult(logRecord);
        }
    }
}
