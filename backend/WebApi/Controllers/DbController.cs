using Application.Interface;
using Domain;
using Microsoft.AspNetCore.Mvc;


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
                return BadRequest($"a record with such ID exists :{connection.Id}");
            }
            return Ok(connection);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DbConnection>>> Get()
        {                     
            return  _dbConnectionStorage.Connections;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DbConnection>> Get(string id)
        {
            DbConnection record = _dbConnectionStorage.Connections.FirstOrDefault(x => x.Id.ToString().ToLower() == id.ToLower());
            if (record == null)
            {
                return NotFound();
            }          
            return Ok(record);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DbConnection>> Delete(string id)
        {
            DbConnection record = _dbConnectionStorage.Connections.FirstOrDefault(x => x.Id.ToString().ToLower() == id.ToLower());
            if (record == null)
            {
                return NotFound();
            }
            if(_dbConnectionStorage.Connections.Remove(record))            
                return Ok(record);
            return BadRequest(record);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<DbConnection>> Put(string id,[FromBody] DbConnection connection)
        {
            int index = _dbConnectionStorage.Connections.FindIndex(p => p.Id.ToString().ToLower() == id.ToLower());
            if (index == -1)
            {
                return BadRequest($"A record with this ID does not exist : {id}");
            }
            connection.Id = new Guid(id);
            _dbConnectionStorage.Connections[index] = connection;               
            
            return Ok(connection);
        }
    }
}
