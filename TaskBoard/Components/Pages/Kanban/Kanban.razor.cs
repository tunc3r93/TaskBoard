using Microsoft.AspNetCore.Components;
using MudBlazor;
using TaskBoard.Models.Kanban;
using TaskBoard.Enums;

namespace TaskBoard.Components.Pages.Kanban;

public class KanbanBase : ComponentBase
{
    protected List<KanbanColumn> Columns = new();

    protected override void OnInitialized()
    {
        Columns = new List<KanbanColumn>
        {
            new KanbanColumn("Backlog", KanbanStatus.Backlog),
            new KanbanColumn("In Bearbeitung", KanbanStatus.InProgress),
            new KanbanColumn("Review", KanbanStatus.Review),
            new KanbanColumn("Erledigt", KanbanStatus.Done)
        };

        AddItem("Login", "JWT Auth", Priority.High, KanbanStatus.Backlog);
        AddItem("Kanban UI", "Drag & Drop", Priority.Medium, KanbanStatus.InProgress);
    }

    protected void AddItem(string title, string desc, Priority prio, KanbanStatus status)
    {
        var column = Columns.First(c => c.Status == status);
        column.Items.Add(new KanbanItem
        {
            Id = Guid.NewGuid(),
            Title = title,
            Description = desc,
            Priority = prio,
            Status = status
        });
    }

    protected void OnItemDropped(MudItemDropInfo<KanbanItem> info, KanbanStatus newStatus)
    {
        if (info.Item.Status == newStatus) return;

        // Alten Status entfernen
        var oldColumn = Columns.First(c => c.Items.Contains(info.Item));
        oldColumn.Items.Remove(info.Item);

        // Neuen Status hinzufügen
        info.Item.Status = newStatus;
        var newColumn = Columns.First(c => c.Status == newStatus);
        newColumn.Items.Add(info.Item);
    }

    protected void OpenEditDialog(KanbanItem item)
    {
        // Dialog öffnen – kommt später
    }
}

public class KanbanColumn
{
    public string Title { get; set; }
    public KanbanStatus Status { get; set; }
    public List<KanbanItem> Items { get; set; } = new();

    public KanbanColumn(string title, KanbanStatus status)
    {
        Title = title;
        Status = status;
    }
}