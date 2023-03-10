namespace RestaurantManager;

static class Program
{
    public static readonly DatabaseConnection Database = new DatabaseConnection("DatabaseCredentials.json");
    
    public static void Main(string[] args)
    {
        foreach (Menu menu in MenuManager.Menus)
        {
            Console.WriteLine($"---- {menu.ID} - {menu.Name} ----");
            
            foreach (MenuCategory category in menu.Categories)
            {
                Console.WriteLine($"-- {category.ID} - {category.Name} --");
                
                foreach (Dish dish in category.Dishes)
                {
                    Console.WriteLine($"{dish.ID} - {dish.Name} - {dish.Price}");
                }
            }
        }
    }
}