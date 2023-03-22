using System.ComponentModel.DataAnnotations;

namespace poststackserver.Data;

internal sealed class Post
{
    [Key]
    public int PostId { get; set; }

    [Required]
    [MaxLength(100)]
    public String Title { get; set; } = String.Empty;
    
    [Required]
    [MaxLength(100000)]
    public String Content { get; set; } = String.Empty;
}