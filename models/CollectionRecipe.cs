using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class CollectionRecipe
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public int CollectionId { get; set; }

    [Required]
    public int RecipeId { get; set; }

    // Navigation properties
    [ForeignKey(nameof(CollectionId))]
    public required Collection Collection { get; set; }

    [ForeignKey(nameof(RecipeId))]
    public required Recipe Recipe { get; set; }
}