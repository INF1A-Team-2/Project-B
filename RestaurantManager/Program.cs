using RestaurantManager;

static class Program
{
    public static readonly DatabaseConnection Database = new DatabaseConnection("DatabaseCredentials.json");
    
    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
    }
}