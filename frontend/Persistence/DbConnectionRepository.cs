using App;
using Domain;
using System.Net.Http.Headers;


namespace Persistence
{
    public class DbConnectionRepository
    {
        readonly string _api = "/api/db";
        HttpClient _httpClient;
        public DbConnectionRepository(Uri baseAddress)
        {
            var handler = new HttpClientHandler();
            /*handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback =
                (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                };*/

            _httpClient = new HttpClient(handler);
            _httpClient.BaseAddress = baseAddress;
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<List<DbConnection>> ListAllAsync()
        {
            string uri = _api;
            string response = await _httpClient.GetStringAsync(uri);
            List<DbConnection>? instance = Network.DeserializeStringJson<List<DbConnection>>(response);
            if (instance != null)
                return instance;
            return null;
        }
    }
}
