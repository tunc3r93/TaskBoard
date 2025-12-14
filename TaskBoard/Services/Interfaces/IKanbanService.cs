using TaskBoard.Models.Kanban;
using TaskBoard.Enums;

namespace TaskBoard.Services.Interfaces;

public interface IKanbanService
{
    Task<List<KanbanColumn>> GetBoardAsync();
    Task AddItemAsync(KanbanItem item);
    Task UpdateItemAsync(KanbanItem item);
    Task MoveItemAsync(Guid itemId, KanbanStatus newStatus);
}