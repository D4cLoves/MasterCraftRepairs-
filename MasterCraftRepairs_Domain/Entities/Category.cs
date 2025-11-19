namespace MasterCraftRepairs.Domain.Entities;

public class Category
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string CategoryName { get; init; }
}