namespace TodoList.Api.Mapping;

using TodoList.Api.Dtos;
using Task = TodoList.Api.Entities.Task;


public static class TaskMapping
{
    public static Task ToEntity(this CreateTaskDto task)
    {
        return new Task()
        {
            Name = task.Name,
            GenreId = task.GenreId,
            Price = task.Price,
            ReleaseDate = task.ReleaseDate
        };
    }

    public static TaskDto ToDto(this Task task)
    {
        return new(
               task.Id,
               task.Name,
               task.Genre!.Name,
               task.Price,
               task.ReleaseDate
           );
    }
}
