using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Domain;

using Microsoft.AspNetCore.Mvc.Rendering;
using Persistence;
using System;

namespace App.Pages
{
    public class IndexModel : PageModel
    {
        public string baseAddress;
        private readonly IConfiguration Configuration;       
        private readonly ILogger<IndexModel> _logger;

        public string DateSort { get; set; }
        public string GuidSort { get; set; }
        public string AreaNumberSort { get; set; }
        public string LineIdSort { get; set; }
        public string StatusSort { get; set; }
        public string ImportanceSort { get; set; }
        public string CurrentSort { get; set; }
        public string CurrentDbConnection { get; set; }

        public int PageSize {get; set; }
        public int PageIndex { get; set; } = 0;

        [BindProperty]
        public DbConnection Connection { get; set; } = new();
        public List<DbConnection> DisplayConnections { get; set; } = new();


        [BindProperty]
        public List<LogRecord> DisplayedLogRecord { get; private set; } = new();

        [BindProperty]
        public DateTime? StartTimeRange { get; set; }
        [BindProperty]
        public DateTime? EndTimeRange { get; set; }
        [BindProperty]
        public int? LineIdFilter { get; set; }


        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration)
        {
            Configuration = configuration;
            _logger = logger;
            baseAddress = Configuration.GetValue("ServerIp", "http://localhost:14000");
            PageSize = Configuration.GetValue("DefaultPageSize", 40);

            DbConnectionRepository dbConnectionRepository = new();
            try { DisplayConnections = dbConnectionRepository.ListAllAsync(baseAddress).Result; }
            catch (Exception ex){
                _logger.LogWarning(ex.Message);
            }
            
            Connection = DisplayConnections.FirstOrDefault();
        }



        public async Task OnGetAsync(string dBConnectionId,string sortOrder, int pageIndex = 0, string startTimeRange = "", string endTimeRange = "",int? lineIdFilter = null)
        {
            ChooseSort(sortOrder);
            ChooseDbConnection(dBConnectionId);
            ChooseTimeRange(startTimeRange, endTimeRange);
            ChooseLine(lineIdFilter);

            PageIndex = pageIndex;
            
            DbConnectionRepository dbConnectionRepository = new();
            try { DisplayConnections = dbConnectionRepository.ListAllAsync(baseAddress).Result; }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
            }


            LogRecordRepository logRecordRepository = new();
            if (dBConnectionId != null)
                if (!(String.IsNullOrEmpty(dBConnectionId) && dBConnectionId.Length == 36))
                    try
                    {
                        DisplayedLogRecord = await logRecordRepository.ListAllAsync(baseAddress, 
                            CurrentDbConnection, 
                            CurrentSort, 
                            skip: PageIndex * PageSize,
                            take: PageSize + 1,
                            startTimeRange: StartTimeRange,
                            endTimeRange: EndTimeRange,
                            lineId: LineIdFilter);
                    }
                    catch (Exception ex) 
                    { 
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
        private void ChooseDbConnection(string dBConnectionId)
        {
            CurrentDbConnection = dBConnectionId;
        }
        private void ChooseTimeRange(string startTimeRange , string endTimeRange = null)
        {
            
            StartTimeRange = null;
            EndTimeRange = null;
            DateTime tmp = new();
            if (DateTime.TryParse(startTimeRange, out tmp))           
                StartTimeRange = tmp;


            if (DateTime.TryParse(endTimeRange, out tmp))
                EndTimeRange = tmp;   
            
            
        }
        private void ChooseLine(int? lineId)
        {
            if (lineId < 0)
                lineId = null;
            LineIdFilter = lineId;
        }
    }
}
