using System.Globalization;

namespace RestaurantManager;

class Reservation
{
    public int ID;
    public DateTime Time;
    public int People;
    public MenuType MenuType;
    public int TableID;
    public string Code;

    public Reservation(int id, DateTime dateTime, int people, MenuType menuType, int tableId, string code)
    {
        this.ID = id;
        this.Time = dateTime;
        this.People = people;
        this.MenuType = menuType;
        this.TableID = tableId;
        this.Code = code;
    }

    public override string ToString() =>
        $"ID: {ID}; Time: {Time}; People: {People}; MenuType: {MenuType}; TableID: {TableID}; Code: {Code}"; 

    private static Reservation Parse(List<object> data)
    {
        return new Reservation(
            (int)(long)data[0],
            DateTime.Parse((string)data[1], null, DateTimeStyles.AdjustToUniversal),
            (int)(long)data[2],
            (MenuType)(int)(long)data[3],
            (int)(long)data[4],
            (string)data[5]);
    }

    public static List<Reservation> GetAllReservations()
    {
        return Program.Database.Execute("SELECT * FROM reservations").Select(r => Parse(r)).ToList();
    }

    public static Reservation? GetReservationByID(int id)
    {
        List<List<object>> res = Program.Database.Execute(
            "SELECT * FROM reservations WHERE id = %s",
            id);

        if (res.Count == 0)
            return null;

        return Parse(res[0]);
    }
}