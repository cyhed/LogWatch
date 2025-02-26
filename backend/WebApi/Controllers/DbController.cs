using Application.Interface;
using Domain;

using Microsoft.AspNetCore.Mvc;
using Persistence;
using WebApi.Entity;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbController : ControllerBase
    {
        IDbConnectionStorage _dbConnectionStorage;
        public DbController(IDbConnectionStorage dbConnectionStorage) {
            _dbConnectionStorage = dbConnectionStorage;
        }

        [HttpPost]
        public async Task<ActionResult<DbConnection>> Post([FromBody] DbConnection connection)
        {
            if (connection == null)
            {
                return BadRequest();
            }
            if(_dbConnectionStorage.Connections.Find(p => p.Id == connection.Id) is null)
                this._dbConnectionStorage.Connections.Add(connection);    
            else
            {
                return BadRequest("a record with such ID exists");
            }
            return Ok(connection);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DbConnection>>> Get()
        {         
            
            return  _dbConnectionStorage.Connections;
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<DbConnection>> Delete(string id)
        {
            DbConnection record = _dbConnectionStorage.Connections.FirstOrDefault(x => x.Id.ToString().ToLower() == id.ToLower());
            if (record == null)
            {
                return NotFound();
            }
            _dbConnectionStorage.Connections.Remove(record);
            
            return Ok(record);
        }
    }
}
