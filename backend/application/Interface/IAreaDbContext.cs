using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IAreaDbContext
    {
        DbSet<Area> AreaNumbers { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellation);
    }
}
