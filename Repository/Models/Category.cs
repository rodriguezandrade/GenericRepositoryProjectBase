using System;
using System.ComponentModel.DataAnnotations;

namespace Repository.Models
{
    public class Category
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string Name { get; set; }
    }
}
