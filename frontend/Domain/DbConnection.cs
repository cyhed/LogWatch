using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class DbConnection
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Server { get; set; }

        [Range(0, 65535)]       
        public int Port { get; set; }
        public string Database { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
