using Gestao.Domain.Libraries.Utilities;
using Gestao.Domain.Repositories;
using Gestao.Domain;
using Microsoft.EntityFrameworkCore;

namespace Gestao.Data.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _db;

        public CompanyRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        //CRUD
        public async Task<PaginatedList<Company>> GetAll(Guid ApplicationUserId, int pageIndex, int pageSize, string? searchWord = "")
        {
            var items = await _db.Companies
                .Where(x => x.UserId == ApplicationUserId)
                .Where(x=> x.TradeName.Contains(searchWord) || x.LegalName.Contains(searchWord))
                .OrderBy(x=> x.TradeName)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var count = await _db.Companies
                .Where(x => x.UserId == ApplicationUserId)
                .Where(x => x.TradeName.Contains(searchWord) || x.LegalName.Contains(searchWord))
                .CountAsync();

            int totalPages = (int)Math.Ceiling((double)count / pageSize);

            return new PaginatedList<Company>(items, pageIndex, totalPages);
        }
        public async Task<Company?> Get(int id)
        {
            return await _db.Companies.SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task Add(Company entity)
        {
            _db.Companies.Add(entity);
            await _db.SaveChangesAsync();
        }
        public async Task Update(Company entity)
        {
            _db.Companies.Update(entity);
            await _db.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var entity = await Get(id);
            if (entity != null)
            {
                _db.Companies.Remove(entity);
                await _db.SaveChangesAsync();
            }

        }
    }
}
