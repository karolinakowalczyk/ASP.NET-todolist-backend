using System.ComponentModel.DataAnnotations;

namespace TodoList.Api.Dtos;

public record class CreateTaskDto(
    [Required][StringLength(50)] string Name,
    int GenreId,
    [Range(1, 100)] decimal Price,
    DateOnly ReleaseDate
);
