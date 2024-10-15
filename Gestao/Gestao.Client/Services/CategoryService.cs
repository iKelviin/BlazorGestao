using Gestao.Data;
using Gestao.Domain;
using Gestao.Domain.Libraries.Utilities;
using Gestao.Domain.Repositories;
using System.Net.Http.Json;

namespace Gestao.Client.Services
{
    public class CategoryService : ICategoryRepository
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        Task ICategoryRepository.Add(Category entity)
        {
            throw new NotImplementedException();
        }

        Task ICategoryRepository.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Task<Category?> ICategoryRepository.Get(int id)
        {
            throw new NotImplementedException();
        }

        Task<List<Category>> ICategoryRepository.GetAll(int companyId)
        {
            throw new NotImplementedException();
        }

        async Task<PaginatedList<Category>> ICategoryRepository.GetAll(int companyId, int pageIndex, int pageSize)
        {
            var url = $"/api/categories?companyId={companyId}&pageIndex={pageIndex}";
            var response = await _httpClient.GetFromJsonAsync<PaginatedList<Category>>(url);

            return response!;
        }

        Task ICategoryRepository.Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
