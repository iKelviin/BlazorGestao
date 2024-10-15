using Gestao.Data.Repositories;
using Gestao.Domain;
using Gestao.Domain.Enums;
using Gestao.Domain.Libraries.Utilities;
using System.Net.Http.Json;

namespace Gestao.Client.Services
{
    public class FinancialTransactionService : IFinancialTransactionRepository
    {
        private readonly HttpClient _httpClient;

        public FinancialTransactionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        Task IFinancialTransactionRepository.Add(FinancialTransaction entity)
        {
            throw new NotImplementedException();
        }

        Task IFinancialTransactionRepository.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Task<FinancialTransaction?> IFinancialTransactionRepository.Get(int id)
        {
            throw new NotImplementedException();
        }

        async Task<PaginatedList<FinancialTransaction>> IFinancialTransactionRepository.GetAll(int companyId, TypeFinancialTransaction type, int pageIndex, int pageSize, string searchWord)
        {
            var url = $"/api/financial-transactions?companyId={companyId}&type={type}&pageIndex={pageIndex}&searchWord={searchWord}";
            var response = await _httpClient.GetFromJsonAsync<PaginatedList<FinancialTransaction>>(url);

            return response!;
        }

        Task IFinancialTransactionRepository.Update(FinancialTransaction entity)
        {
            throw new NotImplementedException();
        }
    }
}
