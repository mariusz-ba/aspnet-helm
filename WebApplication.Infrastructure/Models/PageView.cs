using System.ComponentModel.DataAnnotations;

namespace WebApplication.Infrastructure.Models
{
    public class PageView
    {
        [Key]
        public string Name { get; set; }
        public int Count { get; set; }
    }
}