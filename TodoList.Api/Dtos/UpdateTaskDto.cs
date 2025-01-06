using System.ComponentModel.DataAnnotations;

namespace TodoList.Api.Dtos;

public record class UpdateTaskDto
(
    [Required][StringLength(50)] string Name,
    [Required][StringLength(20)] string Genre,
    [Range(1, 100)] decimal Price,
    DateOnly ReleaseDate
);
