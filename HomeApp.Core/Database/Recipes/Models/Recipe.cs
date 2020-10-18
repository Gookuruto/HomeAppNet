namespace HomeApp.Core.Databse.Recipes.Models
{
    public class Recipe
    {
        public int RecipeId { get; private set; }
        public string Url { get; private set; }

        public Recipe(int recipeId ,string url)
        {
            RecipeId = recipeId;
            Url = url;
        }
    }
}
