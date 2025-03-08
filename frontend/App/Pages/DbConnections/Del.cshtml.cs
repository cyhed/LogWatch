using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Persistence;
using System;
using System.Net;
using System.Text;

namespace App.Pages.DbConnections
{
    public class DelModel : PageModel
    {
        private readonly ILogger<DelModel> _logger;
        public string apiAddress;
        private readonly IConfiguration Configuration;

        [BindProperty]
        public DbConnection Connection { get; set; } = new DbConnection();
        public DelModel(ILogger<DelModel> logger, IConfiguration configuration)
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
                Method = HttpMethod.Delete,
                RequestUri = new Uri(apiAddress + "/api/db" +$"/{Connection.Id}")
            };
            var response =  await httpClient.SendAsync(request);

           


            return RedirectToPage("/Index");
        }
    }
}
