namespace MyTodoAppBackend.Models
{
 public class TodoItem
 {
  public long Id { get; set; }
  public string Name { get; set; } = string.Empty; // Added an empty string as a default value to avoid CS8618 warning.
  public bool IsComplete { get; set; }
 }
}
