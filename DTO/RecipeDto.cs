public class RecipeDto
{
    public string Title { get; set; }
    public List<string> Ingredients { get; set; }
    public string Description { get; set; }
    public int CookingTime { get; set; }
    public int UserId { get; set; }
}