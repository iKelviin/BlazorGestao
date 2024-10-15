using Gestao.Domain.Repositories;
using Gestao.Domain;
using Microsoft.EntityFrameworkCore;

namespace Gestao.Data.Repositories
{
    public class DocumentsRepository : IDocumentsRepository
    {
        private readonly ApplicationDbContext _db;

        public DocumentsRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Documents?> Get(int id)
        {
            return await _db.Documents.SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task Add(Documents entity)
        {
            _db.Documents.Add(entity);
            await _db.SaveChangesAsync();
        }
        public async Task Update(Documents entity)
        {
            _db.Documents.Update(entity);
            await _db.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var entity = await Get(id);
            if (entity != null)
            {
                _db.Documents.Remove(entity);
                await _db.SaveChangesAsync();
            }

        }
    }
}
