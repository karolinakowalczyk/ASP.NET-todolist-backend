using TodoList.Api.Data;
using TodoList.Api.Dtos;
using TodoList.Api.Entities;
using TodoList.Api.Mapping;
using Task = TodoList.Api.Entities.Task;

namespace TodoList.Api.Endpoints;

public static class TasksEndpoints
{
    const string getTaskEndpointName = "GetTask";
    private static readonly List<TaskDto> tasks = [
        new (
        1,
        "Street Fighter II",
        "Fighting",
        19.99M,
        new DateOnly(1992, 7, 15)
        ),
        new (
            2,
            "Final Fantasy XIV",
            "Roleplaying",
            59.99M,
            new DateOnly(2010, 9, 30)
        ),
        new (
            3,
            "FIFA 23",
            "Sports",
            69.99M,
            new DateOnly(2022, 9, 27)
        ),
    ];

    public static RouteGroupBuilder MapTasksEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("tasks").WithParameterValidation();

        // GET /tasks
        group.MapGet("/", () => tasks);

        //GET /tasks/1
        group.MapGet("/{id}", (int id) =>
        {
            TaskDto? task = tasks.Find(task => task.Id == id);

            return task is null ? Results.NotFound() : Results.Ok(task);
        })
        .WithName(getTaskEndpointName);


        // POST /tasks
        group.MapPost("/", (CreateTaskDto newTask, TaskStoreContext dbContext) =>
        {
            // TaskDto task = new(
            //     tasks.Count + 1,
            //     newTask.Name,
            //     newTask.Genre,
            //     newTask.Price,
            //     newTask.ReleaseDate
            // );

            // tasks.Add(task);

            // Task task = new()
            // {
            //     Name = newTask.Name,
            //     Genre = dbContext.Genres.Find(newTask.GenreId),
            //     GenreId = newTask.GenreId,
            //     Price = newTask.Price,
            //     ReleaseDate = newTask.ReleaseDate
            // };

            Task task = newTask.ToEntity();
            task.Genre = dbContext.Genres.Find(newTask.GenreId);

            dbContext.Tasks.Add(task);
            dbContext.SaveChanges();

            // TaskDto taskDto = new(
            //     task.Id,
            //     task.Name,
            //     task.Genre!.Name,
            //     task.Price,
            //     task.ReleaseDate
            // );

            return Results.CreatedAtRoute(getTaskEndpointName, new { id = task.Id }, task.ToDto());
        });

        // PUT /tasks
        group.MapPut("/{id}", (int id, UpdateTaskDto updatedTask) =>
        {
            var index = tasks.FindIndex(task => task.Id == id);

            if (index == -1)
            {
                // Another approach: here I can create new task.
                return Results.NotFound();
            }

            tasks[index] = new TaskDto(
                id,
                updatedTask.Name,
                updatedTask.Genre,
                updatedTask.Price,
                updatedTask.ReleaseDate
            );

            return Results.NoContent();
        });

        //DELETE /tasks/1
        group.MapDelete("/{id}", (int id) =>
        {
            tasks.RemoveAll(task => task.Id == id);

            return Results.NoContent();
        });

        return group;
    }
}
