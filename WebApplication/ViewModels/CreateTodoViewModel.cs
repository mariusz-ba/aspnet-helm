using System.ComponentModel.DataAnnotations;

namespace WebApplication.ViewModels
{
    public class CreateTodoViewModel
    {
        [Required]
        public string Title { get; set; }
    }
}