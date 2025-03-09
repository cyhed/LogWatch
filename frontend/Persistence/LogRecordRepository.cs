using App;
using Domain;
using System.Net.Http.Headers;

namespace Persistence
{
    public class LogRecordRepository : IDisposable
    {
        readonly string _api = "/api/logs";
        HttpClient _httpClient;
        public LogRecordRepository() {
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

        public void Dispose()
        {
            _httpClient.Dispose();
        }

        public async Task<List<LogRecord>> ListAllAsync(string baseAddress,
            string dbConnectionId,
            string sortOrder, 
            int skip, int take, 
            DateTime? startTimeRange = null, 
            DateTime? endTimeRange = null )
        {
            string uri = baseAddress +_api
                + "?"
                + $"dbConnentId={dbConnectionId}"
                +"&"
                + $"sortOrder={sortOrder}"
                + "&"
                + $"skip={skip}"
                + "&"
                + $"take={take}"
                + "&"
                + $"startDateRange={(startTimeRange == null? "" : startTimeRange)}"
                + "&"
                + $"endDateRange={(endTimeRange == null ? "" : endTimeRange)}";

            string response = await _httpClient.GetStringAsync(uri);
                List<LogRecord>? instance = Network.DeserializeStringJson<List<LogRecord>>(response);
                if (instance != null)
                    return instance;
                return new List<LogRecord>();
            
        }
    }
}
