
namespace Repository.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        ICategoryRepository Category { get; }
        void save();
    }
}
