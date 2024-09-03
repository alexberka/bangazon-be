namespace bangazon_be.Apis
{
    public class CategoriesApi
    {
        public static void Map(WebApplication app)
        {
            //Get all categories
            app.MapGet("/categories", (BangazonBeDbContext db) =>
            {
                return db.Categories.ToList();
            });
        }
    }
}