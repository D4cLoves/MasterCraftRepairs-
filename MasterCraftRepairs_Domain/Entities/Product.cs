using MasterCraftRepairs.Domain.ValueObjects;

namespace MasterCraftRepairs.Domain.Entities;

public class Product
{
    public Guid Id { get; init; } =  Guid.NewGuid();
    public Guid CategoryId { get; init; }
    
    public Serial SerialNumber { get; init; }
    public decimal Price { get; init; }
    public DateOnly RealeseYear {get; init;}
    public Brand BrandName { get; init; }
    public Model ModelName { get; init; }
}