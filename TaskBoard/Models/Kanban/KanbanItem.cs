using TaskBoard.Enums;

namespace TaskBoard.Models.Kanban;

public class KanbanItem
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Priority Priority { get; set; } = Priority.Medium;
    public KanbanStatus Status { get; set; }
}