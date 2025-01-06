namespace TodoList.Api.Dtos;

public record class TaskDto(
    int Id,
    string Name,
    string Genre,
    decimal Price,
    DateOnly ReleaseDate);