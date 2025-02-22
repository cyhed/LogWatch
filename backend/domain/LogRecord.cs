namespace Domain
{
    public class LogRecord
    {
        public string Guid { get; set; } = string.Empty;
        public DateTime DateTime { get; set; }
        public string AreaNumber { get; set; } = string.Empty;
        public string LineId { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
