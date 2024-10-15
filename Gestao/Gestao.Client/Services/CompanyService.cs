using Gestao.Domain;
using Gestao.Domain.Libraries.Utilities;
using Gestao.Domain.Repositories;
using System.Net.Http.Json;

namespace Gestao.Client.Services
{
    public class CompanyService : ICompanyRepository
    {
        private readonly HttpClient _httpClient;

        public CompanyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        Task ICompanyRepository.Add(Company company)
        {
            throw new NotImplementedException();
        }

        Task ICompanyRepository.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Task<Company?> ICompanyRepository.Get(int id)
        {
            throw new NotImplementedException();
        }

        async Task<PaginatedList<Company>> ICompanyRepository.GetAll(Guid ApplicationUserId, int pageIndex, int pageSize, string searchWord)
        {
            var url = $"/api/companies?applicationUserId={ApplicationUserId}&pageIndex={pageIndex}&searchWord={searchWord}";
            var response = await _httpClient.GetFromJsonAsync<PaginatedList<Company>>(url);

            return response!;
        }

        Task ICompanyRepository.Update(Company company)
        {
            throw new NotImplementedException();
        }
    }
}
