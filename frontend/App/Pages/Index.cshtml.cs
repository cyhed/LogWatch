using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using App.Entity;
using Microsoft.Extensions.Configuration;
namespace App.Pages
{
    public class IndexModel : PageModel
    {
        public string baseAddress;
        private readonly IConfiguration Configuration;       
        private readonly ILogger<IndexModel> _logger;

        public string test;

        public string DateSort { get; set; }
        public string GuidSort { get; set; }
        public string AreaNumberSort { get; set; }
        public string LineIdSort { get; set; }
        public string StatusSort { get; set; }
        public string ImportanceSort { get; set; }
        public string CurrentSort { get; set; }

        public int PageSize {get; set; }
        public int PageIndex { get; set; } = 0;

    public List<LogRecord> DisplayedLogRecord { get; private set; } = new();
        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration)
        {
            Configuration = configuration;
            _logger = logger;
            baseAddress = Configuration.GetValue("ServerIp", "https://localhost:14001");
            PageSize = Configuration.GetValue("DefaultPageSize", 40);
        }

        
       
        public async Task OnGetAsync(string sortOrder, int pageIndex = 0)
        {
            ChooseSort(sortOrder);
            PageIndex = pageIndex;
            string tableUrl = "/api/logs";

            //шоб на ssl не жаловался
            var handler = new HttpClientHandler();
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback =
                (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                };
            using (var httpClient = new HttpClient(handler))
            {
                string json = await httpClient.GetStringAsync(baseAddress + tableUrl + "?sortOrder=" + sortOrder + "&skip=" + (PageIndex* PageSize) + "&take=" +  (PageSize +1));
                List<LogRecord>? instance = JsonConvert.DeserializeObject<List<LogRecord>>(json);
                if (instance != null)
                    DisplayedLogRecord = DisplayedLogRecord.Concat(instance).ToList();
            }

        }
        private void ChooseSort(string sortOrder)
        {
            CurrentSort = sortOrder;
            GuidSort = sortOrder == "guid" ? "guid_desc" : "guid";
            DateSort = String.IsNullOrEmpty(sortOrder) ? "date_desc" : "";
            AreaNumberSort = sortOrder == "areaNumber" ? "areaNumber_desc" : "areaNumber";
            LineIdSort = sortOrder == "lineId" ? "lineId_desc" : "lineId";
            StatusSort = sortOrder == "status" ? "status_desc" : "status";
            ImportanceSort = sortOrder == "importance" ? "importance_desc" : "importance";
        }
    }
}
