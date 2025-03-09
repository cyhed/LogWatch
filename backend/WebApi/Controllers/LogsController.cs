using Application.Interface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using WebApi.Entity;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        const int DEFAULT_NUMBER_OF_RECORD_RETURN = 500;
        const string DEFAULT_SORT_ORDER = "data";

        LogsDbContext db;
        IDbConnectionStorage _dbConnectionStorage;
        IContextProvider<LogsDbContext> _contextProvider;
        public LogsController(LogsContextProvider LogsContextProvider,IDbConnectionStorage dbConnectionStorage)
        {
            _dbConnectionStorage = dbConnectionStorage;
            _contextProvider = LogsContextProvider;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OutputRecord>>> Get(string dbConnentId,
            string sortOrder = DEFAULT_SORT_ORDER, 
            int skip = 0, 
            int take = DEFAULT_NUMBER_OF_RECORD_RETURN,
            DateTime? startDateRange = null,
            DateTime? endDateRange = null)
        {
            DbConnection currentConnection = _dbConnectionStorage.Connections.First(p => p.Id.ToString().ToLower() == dbConnentId.ToLower());
            if(currentConnection == null)
                return BadRequest("Connection Id not found");
            db = _contextProvider.GetContext(currentConnection);


            IQueryable<LogRecord> logs = db.Logs.AsQueryable();
            IQueryable<OutputRecord> queryable = Join(logs, db.LogsStatusCodes, db.AreaNumbers);


            queryable = Sort(queryable, sortOrder);

            if(startDateRange is not null)
                queryable = queryable.Where(p =>  startDateRange <= p.DateTime);
            if (endDateRange is not null)
                queryable = queryable.Where(p => p.DateTime <= endDateRange);

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
