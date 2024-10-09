using Gestao.Client.Libraries.Utilities;
using Gestao.Domain;
using Microsoft.EntityFrameworkCore;

namespace Gestao.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        //CRUD
        public async Task<PaginatedList<Category>> GetAll(int companyId, int pageIndex, int pageSize)
        {
            var items = await _db.Categories.Where(x => x.CompanyId == companyId)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var count = await _db.Categories.Where(x => x.CompanyId == companyId).CountAsync();
            int totalPages = (int)Math.Ceiling((double)count / pageSize);

            return new PaginatedList<Category>(items, pageIndex, totalPages);
        }

        public async Task<List<Category>> GetAll(int companyId)
        {
            return await _db.Categories.Where(x => x.CompanyId == companyId).ToListAsync();

        }
        public async Task<Category?> Get(int id)
        {
            return await _db.Categories.SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task Add(Category entity)
        {
            _db.Categories.Add(entity);
            await _db.SaveChangesAsync();
        }
        public async Task Update(Category entity)
        {
            _db.Categories.Update(entity);
            await _db.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var entity = await Get(id);
            if (entity != null)
            {
                _db.Categories.Remove(entity);
                await _db.SaveChangesAsync();
            }

        }
    }
}
