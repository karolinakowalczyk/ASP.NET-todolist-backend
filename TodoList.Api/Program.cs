using TodoList.Api.Data;
using TodoList.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("TaskStore");
builder.Services.AddSqlite<TaskStoreContext>(connString);

var app = builder.Build();

app.MapTasksEndpoints();

app.MigrateDb();

app.Run();
