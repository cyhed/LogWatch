using Domain;

namespace Application.Interface
{
    public interface IDbConnectionStorage
    {
        List<DbConnection> Connections { get; set; }
    }
}
