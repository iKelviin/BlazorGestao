using Gestao.Domain;
using Gestao.Domain.Libraries.Utilities;
using Gestao.Domain.Repositories;
using System.Net.Http.Json;

namespace Gestao.Client.Services
{
    public class AccountService : IAccountRepository
    {
        private readonly HttpClient _httpClient;

        public AccountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        Task IAccountRepository.Add(Account entity)
        {
            throw new NotImplementedException();
        }

        Task IAccountRepository.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Task<Account?> IAccountRepository.Get(int id)
        {
            throw new NotImplementedException();
        }

        Task<List<Account>> IAccountRepository.GetAll(int companyId)
        {
            throw new NotImplementedException();
        }

        async Task<PaginatedList<Account>> IAccountRepository.GetAll(int companyId, int pageIndex, int pageSize, string searchWord)
        {
            var url = $"/api/accounts?companyId={companyId}&pageIndex={pageIndex}&searchWord={searchWord}";
            var response = await _httpClient.GetFromJsonAsync<PaginatedList<Account>>(url);

            return response!;
        }

        Task IAccountRepository.Update(Account entity)
        {
            throw new NotImplementedException();
        }
    }
}
