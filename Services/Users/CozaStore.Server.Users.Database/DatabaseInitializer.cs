using Microsoft.EntityFrameworkCore;

namespace CozaStore.Server.Users.Database;

public static class DatabaseInitializer
{
    public static void Initialize(DbContext context)
    {
        context.Database.EnsureCreated();
    }
}
