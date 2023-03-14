namespace RestaurantManager;

static class Program
{
    public static readonly DatabaseConnection Database = new DatabaseConnection("DatabaseCredentials.json");

    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        MainMenu();
    }

    private static void MainMenu()
    {
        int selection = InputManager.GetSelection(new List<string>()
        {
            "Tafel reserveren",
            "Eten / drinken bestellen",
            "Informatie over reservering"
        }, "1111");

        switch (selection)
        {
            case 0:
                MakeReservation();
                break;
            
            case 1:
                Order();
                break;
            
            case 2:
                ReservationInfo();
                break;
            
            case -1:
                AdminPanel();
                break;
        }
        
        MainMenu();
    }

    private static void MakeReservation()
    {
        DateTime date = InputManager.GetDate("Enter the date:");
        int amountOfPeople = InputManager.GetInt("Enter the amount of people:", i => i > 0);
    }

    private static void Order()
    {
        
    }

    private static void ReservationInfo()
    {
        
    }

    private static void AdminPanel()
    {
        
    }
}