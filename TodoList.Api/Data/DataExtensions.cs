using Microsoft.EntityFrameworkCore;

namespace TodoList.Api.Data;

public static class DataExtensions
{
    public static void MigrateDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<TaskStoreContext>();
        dbContext.Database.Migrate();
    }
}
