using System;
using System.ComponentModel.DataAnnotations;

namespace ReportsWebApp.Models
{
    public class TaskRequest
    {
        [DataType(DataType.Date)]
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Status { get; set; }
#nullable enable
        public string? Comment { get; set; }
#nullable disable
    }
}
