using Gestao.Domain;

namespace Gestao.Data.Repositories
{
    public interface IDocumentsRepository
    {
        Task Add(Documents entity);
        Task Delete(int id);
        Task<Documents?> Get(int id);
        Task Update(Documents entity);
    }
}