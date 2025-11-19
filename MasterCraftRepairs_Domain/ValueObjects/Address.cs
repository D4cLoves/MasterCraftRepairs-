namespace MasterCraftRepairs.Domain.ValueObjects;

public record Address(string value)
{
    public string Value { get; init; } = Validate(value);
    
    private static string Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("ошибка - пусто");

        string cleaned = value.Trim();
        
        return cleaned.ToUpper();
    }
    public override string ToString() => Value;
}