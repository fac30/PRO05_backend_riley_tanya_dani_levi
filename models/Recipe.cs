using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class Recipe
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    [StringLength(100)]
    public required string Title { get; set; }

    [Required]
    public required string Ingredients { get; set; }

    public required string Description { get; set; }

    public bool IsPublic { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public int? CookingTime { get; set; }

    // Navigation properties
    [ForeignKey(nameof(UserId))]
    public  User? User { get; set; }

    public ICollection<CollectionRecipe>? CollectionRecipes { get; set; }

    public static implicit operator Recipe(Recipe v)
    {
        throw new NotImplementedException();
    }
}

