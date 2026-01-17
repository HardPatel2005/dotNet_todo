namespace MyTodoAppBackend.Models
{
    public class TodoItem
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsComplete { get; set; }
        public string? UserId { get; set; } // Foreign key to link to a user
        public ApplicationUser? User { get; set; } // Navigation property
    }
}