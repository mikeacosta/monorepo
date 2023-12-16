using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CarvedRock.Admin.Data;

namespace CarvedRock.Admin.Models;

public class CategoryModel
{
    public int Id { get; set; }
    [Required]
    [DisplayName("CATEGORY NAME")]
    public string Name { get; set; }
    
    public static CategoryModel FromCategory(Category category)
    {
        return new CategoryModel
        {
            Id = category.Id,
            Name = category.Name
        };
    }

    public Category ToCategory()
    {
        return new Category
        {
            Id = Id,
            Name = Name
        };
    }
    
    public Category ToNewCategory()
    {
        return new Category
        {   
            Name = Name
        };
    }    
}