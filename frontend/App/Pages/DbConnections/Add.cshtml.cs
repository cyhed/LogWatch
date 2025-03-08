using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace App.Pages.DbConnections
{
    public class AddModel : PageModel
    {
        private readonly ILogger<AddModel> _logger;

        public string apiAddress;
        private readonly IConfiguration Configuration;
        [BindProperty]
        public DbConnection Connection { get; set; } = new DbConnection();
        [BindProperty]
        public string Message { get; set; }

        public AddModel(ILogger<AddModel> logger, IConfiguration configuration)
        {
            Configuration = configuration;
            apiAddress = Configuration.GetValue("ServerIp", "http://localhost:14000");
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
            string responseAsString = default;
            try {
                HttpResponseMessage response = await Network.PostAsJson(apiAddress + "/api/db", Network.SerializeToJson(connection), httpClient);
                responseAsString = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)            {
                
                _logger.LogInformation(ex.Message);
                            }
            catch (Exception ex)
            {
                
            }            
            _logger.LogInformation(responseAsString);
            
            
        }
    }
}
