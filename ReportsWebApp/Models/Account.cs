using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReportsWebApp.Models
{
    public class Account
    {
        [Key]
        public Guid Id { get; set; }

        [EmailAddress]
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        public ICollection<UserTask> UserTasks { get; set; }
    }
}
