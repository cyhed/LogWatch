namespace WebApi.Entity
{
    public class OutputRecord
    {
        public string Guid { get; set; }
        public DateTime DateTime { get; set; }
        public string AreaNumber { get; set; } = string.Empty;
        public string LineId { get; set; } = string.Empty;
        public bool Importance { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
