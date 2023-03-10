namespace RestaurantManager;

public static class MenuManager
{
    public static List<Menu> Menus = LoadMenusFromDatabase();

    private static List<Menu> LoadMenusFromDatabase()
    {
        List<List<object>> menus = Program.Database.Execute("SELECT * FROM menus");

        return menus.Select(m => new Menu((int)(long)m[0], (string)m[1])).ToList();
    }
}
