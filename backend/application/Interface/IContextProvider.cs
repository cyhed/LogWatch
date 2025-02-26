using Domain;

namespace Application.Interface
{
    public interface IContextProvider<out T>
    {
        T GetContext(DbConnection connection);
    }
}
