using Application.Interface;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class DbConnnectionStorage : IDbConnectionStorage
    {
        public List<DbConnection> Connections { get ; set; } = new List<DbConnection>();
    }
}
