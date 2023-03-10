namespace RestaurantManager;

public class Dish
{
    public int ID;
    public string Name;
    public decimal Price;

    public Dish(int id, string name, decimal price)
    {
        this.ID = id;
        this.Name = name;
        this.Price = price;
    }
}    