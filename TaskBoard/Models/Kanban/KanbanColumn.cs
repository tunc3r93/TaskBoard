using TaskBoard.Enums;

namespace TaskBoard.Models.Kanban;

public class KanbanColumn
{
    public string Title { get; }
    public KanbanStatus Status { get; }
    public List<KanbanItem> Items { get; } = new();

    public KanbanColumn(string title, KanbanStatus status)
    {
        Title = title;
        Status = status;
    }
}