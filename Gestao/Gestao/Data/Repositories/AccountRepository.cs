using Gestao.Domain.Libraries.Utilities;
using Gestao.Domain.Repositories;
using Gestao.Domain;
using Microsoft.EntityFrameworkCore;

namespace Gestao.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _db;

        public AccountRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        //CRUD
        public async Task<PaginatedList<Account>> GetAll(int companyId, int pageIndex, int pageSize, string searhWord = "")
        {
            var items = await _db.Accounts
                .Where(x => x.CompanyId == companyId)
                .Where(x=> x.Description.Contains(searhWord))
                .OrderBy(x=> x.Description)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var count = await _db.Accounts.Where(x => x.CompanyId == companyId).Where(x => x.Description.Contains(searhWord)).CountAsync();
            int totalPages = (int)Math.Ceiling((double)count / pageSize);

            return new PaginatedList<Account>(items, pageIndex, totalPages);
        }

        public async Task<List<Account>> GetAll(int companyId)
        {
            return await _db.Accounts.Where(x => x.CompanyId == companyId).ToListAsync();

        }
        public async Task<Account?> Get(int id)
        {
            return await _db.Accounts.SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task Add(Account entity)
        {
            _db.Accounts.Add(entity);
            await _db.SaveChangesAsync();
        }
        public async Task Update(Account entity)
        {
            _db.Accounts.Update(entity);
            await _db.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var entity = await Get(id);
            if (entity != null)
            {
                _db.Accounts.Remove(entity);
                await _db.SaveChangesAsync();
            }

        }
    }
}
