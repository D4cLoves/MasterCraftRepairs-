namespace MasterCraftRepairs.Domain.ValueObjects;

public class Money(decimal Amount)
{
    public decimal Amount { get; init; } = Amount < 0 
        ? throw new ArgumentException("Цена не может быть отрицательной") 
        : Amount;

    public override string ToString() => $"{Amount:C}";
}