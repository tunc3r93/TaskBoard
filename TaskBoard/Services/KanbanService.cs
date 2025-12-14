using TaskBoard.Enums;
using TaskBoard.Models.Kanban;
using TaskBoard.Services.Interfaces;

namespace TaskBoard.Services;

public class KanbanService : IKanbanService
{
    private readonly List<KanbanColumn> _columns = new();

    public KanbanService()
    {
        _columns.Add(new("Backlog", KanbanStatus.Backlog));
        _columns.Add(new("In Bearbeitung", KanbanStatus.InProgress));
        _columns.Add(new("Review", KanbanStatus.Review));
        _columns.Add(new("Erledigt", KanbanStatus.Done));
    }

    public Task<List<KanbanColumn>> GetBoardAsync()
        => Task.FromResult(_columns);

    public Task AddItemAsync(KanbanItem item)
    {
        _columns.First(c => c.Status == item.Status).Items.Add(item);
        return Task.CompletedTask;
    }

    public Task UpdateItemAsync(KanbanItem item) => Task.CompletedTask;

    public Task MoveItemAsync(Guid itemId, KanbanStatus newStatus) => Task.CompletedTask;
}