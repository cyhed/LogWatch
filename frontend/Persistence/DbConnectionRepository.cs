using App;
using Domain;
using System.Net.Http.Headers;


namespace Persistence
{
    public class DbConnectionRepository
    {
        readonly string _api = "/api/db";
        HttpClient _httpClient;
        public DbConnectionRepository()
        {
            var handler = new HttpClientHandler();
            /*handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback =
                (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                };*/

            _httpClient = new HttpClient(handler);            
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<List<DbConnection>> ListAllAsync(string baseAddress)
        {
            string uri = baseAddress + _api;
            string response = await _httpClient.GetStringAsync(uri);
            List<DbConnection>? instance = Network.DeserializeStringJson<List<DbConnection>>(response);
            if (instance != null)
                return instance;
            return null;
        }
        public async Task<DbConnection> GetById(string baseAddress, string id)
        {
            string uri = baseAddress + _api + $"/{id}";
            string response = await _httpClient.GetStringAsync(uri);
            DbConnection? instance = Network.DeserializeStringJson<DbConnection>(response);
            if (instance != null)
                return instance;
            return null;
        }
    }
}
