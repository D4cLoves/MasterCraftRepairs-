namespace MasterCraftRepairs.Domain.ValueObjects;

public class Serial(string value)
{
    public string Value { get; init; } = Validate(value);

    private static string Validate(string? input)
    {
        if (string.IsNullOrWhiteSpace(input))
            throw new ArgumentException("Серийный номер не может быть пустым или null");

        var trimmed = input.Trim();

        if (trimmed.Length == 0)
            throw new ArgumentException("Серийный номер не может состоять только из пробелов");

        return trimmed.ToUpper();
    }

    public override string ToString() => Value;
}