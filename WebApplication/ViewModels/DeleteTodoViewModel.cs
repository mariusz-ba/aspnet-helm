using System.ComponentModel.DataAnnotations;
using System;

namespace WebApplication.ViewModels
{
    public class DeleteTodoViewModel
    {
        [Required]
        public Guid? Id { get; set; }
    }
}