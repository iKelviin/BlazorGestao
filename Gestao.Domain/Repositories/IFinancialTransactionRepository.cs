﻿using Gestao.Domain.Libraries.Utilities;
using Gestao.Domain;
using Gestao.Domain.Enums;

namespace Gestao.Data.Repositories
{
    public interface IFinancialTransactionRepository
    {
        Task Add(FinancialTransaction entity);
        Task Delete(int id);
        Task<FinancialTransaction?> Get(int id);
        Task<PaginatedList<FinancialTransaction>> GetAll(int companyId, TypeFinancialTransaction type, int pageIndex, int pageSize, string searchWord = "");
        Task Update(FinancialTransaction entity);
    }
}