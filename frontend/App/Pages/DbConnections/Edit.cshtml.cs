using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence;
using System.Text;

namespace App.Pages.DbConnections
{
    public class EditModel : PageModel
    {
        private readonly ILogger<EditModel> _logger;

        public string apiAddress;
        private readonly IConfiguration Configuration;

        [BindProperty]
        public DbConnection Connection { get; set; } 
        public EditModel(ILogger<EditModel> logger, IConfiguration configuration)
        {
            Configuration = configuration;
            apiAddress = Configuration.GetValue("ServerIp", "http://localhost:14000");
            _logger = logger;
        }


        public async Task<IActionResult> OnGetAsync(string? id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            DbConnectionRepository dbConnectionRepository = new DbConnectionRepository();
            var connection = await dbConnectionRepository.GetById(apiAddress, (string)id);
            if (connection == null)
            {
                return NotFound();
            }
            Connection = connection;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            var httpClient = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage
            {
                Content = new StringContent(Network.SerializeToJson(Connection), Encoding.UTF8, "application/json"),
                Method = HttpMethod.Put,
                RequestUri = new Uri(apiAddress + "/api/db" + $"/{Connection.Id}")
            };
            var response = await httpClient.SendAsync(request);

            _logger.LogInformation(response.RequestMessage.ToString());



            return RedirectToPage("/Index");
        }
    }
}
