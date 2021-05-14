using System;

namespace WebApplication.ViewModels
{
    public class TodoViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}