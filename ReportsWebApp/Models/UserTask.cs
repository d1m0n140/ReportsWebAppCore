using System;
using System.ComponentModel.DataAnnotations;

namespace ReportsWebApp.Models
{
    public class UserTask
    {
        [Key]
        public int TaskId { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public StatusType Status { get; set; }
#nullable enable
        public string? Comment { get; set; }
#nullable disable

        public Guid AccountId { get; set; }

        public Account Account { get; set; }

    }

    public enum StatusType
    {
        New,
        InProgress,
        Done
    }
}
