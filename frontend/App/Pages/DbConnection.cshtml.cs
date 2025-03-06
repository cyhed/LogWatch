using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain;
using App;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace App.Pages
{
    public class DbConnectionModel : PageModel
    {
        private readonly ILogger<DbConnectionModel> _logger;

        public string apiAddress;
        private readonly IConfiguration Configuration;
        [BindProperty]
        public DbConnection Connection { get; set; } = new DbConnection();
        [BindProperty]
        public string Message { get; set; }

        public DbConnectionModel(ILogger<DbConnectionModel> logger, IConfiguration configuration) {
            Configuration = configuration;
            apiAddress = Configuration.GetValue("ServerI", "http://localhost:14000");
            _logger = logger;
        }
        public void OnGet()
        {
        }
        public async Task OnPostAsync()
        {
            _logger.LogInformation("OnPostAsync");
            // получаем производителя товара
            DbConnection? connection = Connection;

            var handler = new HttpClientHandler();
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback =
                (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                };
            
            var httpClient = new HttpClient(handler);
            HttpResponseMessage response = await Network.PostAsJson(apiAddress + "/api/db", Network.SerializeToJson(connection), httpClient);
            string responseAsString = await response.Content.ReadAsStringAsync();
            _logger.LogInformation(responseAsString);
            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                var data = JObject.Parse(responseAsString)["errors"];
                string errors = data.ToString();                
                _logger.LogInformation(errors);                
                Message = errors;
            }
        }
    }
}
