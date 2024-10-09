using Gestao.Client.Libraries.Utilities;
using Gestao.Domain;
using Gestao.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Gestao.Data.Repositories
{
    public class FinancialTransactionRepository : IFinancialTransactionRepository
    {
        private readonly ApplicationDbContext _db;

        public FinancialTransactionRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        //CRUD
        public async Task<PaginatedList<FinancialTransaction>> GetAll(int companyId, TypeFinancialTransaction type, int pageIndex, int pageSize)
        {
            var items = await _db.FinancialTransactions.Where(x => x.CompanyId == companyId && x.TypeFinancialTransaction == type)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var count = await _db.FinancialTransactions.Where(x => x.CompanyId == companyId && x.TypeFinancialTransaction == type).CountAsync();
            int totalPages = (int)Math.Ceiling((double)count / pageSize);

            return new PaginatedList<FinancialTransaction>(items, pageIndex, totalPages);
        }
        public async Task<FinancialTransaction?> Get(int id)
        {
            return await _db.FinancialTransactions.Include(x=> x.Documents).SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task Add(FinancialTransaction entity)
        {
            _db.FinancialTransactions.Add(entity);
            await _db.SaveChangesAsync();
        }
        public async Task Update(FinancialTransaction entity)
        {
            _db.FinancialTransactions.Update(entity);
            await _db.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var entity = await Get(id);
            if (entity != null)
            {
                _db.FinancialTransactions.Remove(entity);
                await _db.SaveChangesAsync();
            }

        }
    }
}
