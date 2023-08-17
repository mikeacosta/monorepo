using System.ComponentModel.DataAnnotations;

namespace PizzaApi.Models;

public class PizzaForUpdateDto
{
    [Required(ErrorMessage = "Name is required")]
    [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Description is required")]
    [StringLength(100, ErrorMessage = "Description can't be longer than 500 characters")]
    public string Description { get; set; }
}