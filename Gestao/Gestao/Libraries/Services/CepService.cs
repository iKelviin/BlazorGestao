namespace Gestao.Libraries.Services
{
    public class CepService : ICepService
    {
        public async Task<LocalAddress?> SearchByPostalCode(string postalCode)
        {
            var cep = postalCode.Replace(".", string.Empty).Replace("-", string.Empty);

            var http = new HttpClient();
            return await http.GetFromJsonAsync<LocalAddress>($"https://viacep.com.br/ws/{cep}/json/");
        }
    }
    public class LocalAddress
    {
        public string Cep { get; set; } = string.Empty;
        public string Logradouro { get; set; } = string.Empty;
        public string Complemento { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Localidade { get; set; } = string.Empty;
        public string UF { get; set; } = string.Empty;
        public string IBGE { get; set; } = string.Empty;
        public string GIA { get; set; } = string.Empty;
        public string DDD { get; set; } = string.Empty;     
        public string SIAFI { get; set; } = string.Empty;
    }
}
