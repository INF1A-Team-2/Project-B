namespace RestaurantManager;

static class Config
{
    public static TimeOnly OpeningTime = new TimeOnly(17, 0, 0);
    public static TimeOnly ClosingTime = new TimeOnly(23, 30, 0);

    public static TimeSpan ReservationInterval = new TimeSpan(0, 15, 0);
    
    public static TimeSpan RoundTime = new TimeSpan(0, 45, 0);
}