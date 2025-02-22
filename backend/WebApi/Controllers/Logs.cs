using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Logs : ControllerBase
    {
        LogsDbContext db;
        public Logs(LogsDbContext context)
        {
            db = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Object>>> Get(string sortOrder = "", int skip = 0, int take = 500)
        {
            IQueryable<LogRecord> logs = db.Logs.AsQueryable();
            IQueryable<OutputRecord> queryable = Join(logs, db.LogsStatusCodes, db.AreaNumbers);
            queryable = Sort(queryable, sortOrder);
            if (skip > 0)
                queryable = queryable.Skip(skip);
            if (take > 0)
                queryable = queryable.Take(take);

            
            

            if (queryable == null)
                return NotFound();
            return await queryable.ToListAsync();
        }
        
       

        private IQueryable<OutputRecord> Join(IQueryable<LogRecord> logs, Microsoft.EntityFrameworkCore.DbSet<StatusCode> logsStatusCodes, Microsoft.EntityFrameworkCore.DbSet<Area> areaNumbers) {
            var queryable = logs.Join(logsStatusCodes,
                p => p.Status,
                c => c.Status,
                (p, c) => new OutputRecord// результат
                {
                    Guid = p.Guid,
                    DateTime = p.DateTime,
                    AreaNumber = p.AreaNumber,
                    LineId = p.LineId,
                    Importance = c.Importance,
                    Status = c.Description,
                });

            queryable = queryable.Join(areaNumbers,
                p => p.AreaNumber,
                c => c.AreaNumber,
                (p, c) => new OutputRecord// результат
                {
                    Guid = p.Guid,
                    DateTime = p.DateTime,
                    AreaNumber = c.Description,
                    LineId = p.LineId,
                    Importance = p.Importance,
                    Status = p.Status,
                });

            return queryable;          
        }
        private class OutputRecord
        {
            public string Guid { get; set; }
            public DateTime DateTime { get; set; }
            public string AreaNumber { get; set; }  = string.Empty;
            public string LineId { get; set; } = string.Empty;
            public bool Importance { get; set; } 
            public string Status { get; set; } = string.Empty; 
        }

        private IQueryable<OutputRecord> Sort(IQueryable<OutputRecord> logs, string sortOrder)
        {
            switch (sortOrder)
            {
                case "guid":
                    logs = logs.OrderBy(s => s.Guid);
                    break;
                case "guid_desc":
                    logs = logs.OrderByDescending(s => s.Guid);
                    break;
                case "date_desc":
                    logs = logs.OrderBy(s => s.DateTime);
                    break;
                case "date":
                    logs = logs.OrderByDescending(s => s.DateTime);
                    break;
                case "areaNumber":
                    logs = logs.OrderBy(s => s.AreaNumber);
                    break;
                case "areaNumber_desc":
                    logs = logs.OrderByDescending(s => s.AreaNumber);
                    break;
                case "lineId":
                    logs = logs.OrderBy(s => s.LineId);
                    break;
                case "lineId_desc":
                    logs = logs.OrderByDescending(s => s.LineId);
                    break;
                case "status":
                    logs = logs.OrderBy(s => s.Status);
                    break;
                case "status_desc":
                    logs = logs.OrderByDescending(s => s.Status);
                    break;
                case "importance":
                    logs = logs.OrderBy(s => s.Importance);
                    break;
                case "importance_desc":
                    logs = logs.OrderByDescending(s => s.Importance);
                    break;

                default:
                    logs = logs.OrderByDescending(s => s.DateTime);
                    break;
            }
            return logs;
        }
    }
}
