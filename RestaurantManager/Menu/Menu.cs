namespace RestaurantManager;

public class Menu
{
    public int ID;
    public string Name;
    public List<MenuCategory> Categories;

    public Menu(int id, string name)
    {
        this.ID = id;
        this.Name = name;
        this.Categories = LoadCategoriesFromDatabase();
    }
    
    
    private List<MenuCategory> LoadCategoriesFromDatabase()
    {
        List<List<object>> categories = Program.Database.Execute(
            """
            SELECT mc.*
            FROM menu_categories mc
            JOIN menu_category_links mcl ON mc.id = mcl.category_id
            WHERE mcl.menu_id = %s
            """, ID);
        
        return categories.Select(c => new MenuCategory(
            (int)(long)c[0], 
            (string)c[1])).ToList();
    }
}