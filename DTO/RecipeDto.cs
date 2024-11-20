public class RecipeDto
{
    public required string Title { get; set; }
    public List<string> Ingredients { get; set; } = new List<string>();
    public required string Description { get; set; }
    public int CookingTime { get; set; }
    public int UserId { get; set; }
}