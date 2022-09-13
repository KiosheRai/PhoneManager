namespace PhoneManager.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(PhoneManagerDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
