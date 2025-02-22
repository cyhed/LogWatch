using System.ComponentModel;

namespace App.Entity
{
    public class LogRecord
    {
        [DisplayName("Guid")]
        public string Guid { get; set; } = string.Empty;
        [DisplayName("Время")]
        public DateTime DateTime { get; set; }
        [DisplayName("Зона")]
        public string AreaNumber { get; set; } = string.Empty;
        [DisplayName("Линия")]
        public string LineId { get; set; } = string.Empty;
        [DisplayName("Важность")]
        public bool Importance { get; set; }
        [DisplayName("Статус")]
        public string Status { get; set; } = string.Empty;
    }
}
