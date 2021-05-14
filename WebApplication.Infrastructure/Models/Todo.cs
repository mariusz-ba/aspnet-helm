using System.ComponentModel.DataAnnotations;
using System;

namespace WebApplication.Infrastructure.Models
{
    public class Todo
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}