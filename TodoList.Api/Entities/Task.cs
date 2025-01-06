namespace TodoList.Api.Entities;

public class Task
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public Genre? Genre { get; set; }

    public int GenreId { get; set; }

    public decimal Price { get; set; }

    public DateOnly ReleaseDate { get; set; }
}
