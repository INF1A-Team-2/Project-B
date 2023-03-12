namespace RestaurantManager;

class Reservation
{
    public int ID;
    public DateOnly Date;
    public TimeOnly Time;
    public int People;
    public MenuType MenuType;
    public string Code;

    public Reservation(int id, DateOnly date, TimeOnly time, int people, MenuType menuType, string code)
    {
        this.ID = id;
        this.Date = date;
        this.Time = time;
        this.People = people;
        this.MenuType = menuType;
        this.Code = code;
    }
}