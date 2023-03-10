namespace RestaurantManager;

public class MenuCategory
{
    public int ID;
    public string Name;
    public List<Dish> Dishes;
    
    public MenuCategory(int id, string name)
    {
        this.ID = id;
        this.Name = name;
        this.Dishes = LoadDishesFromDatabase();
    }
    
    private List<Dish> LoadDishesFromDatabase()
    {
        List<List<object>> categories = Program.Database.Execute(
            """
            SELECT dishes.*
            FROM dishes
            JOIN category_dish_links cdl ON dishes.id = cdl.dish_id
            WHERE cdl.category_id = %s
            """, ID);

        return categories.Select(d => new Dish(
            (int)(long)d[0], 
            (string)d[1], 
            Convert.ToDecimal(d[2]))).ToList();
    }
}