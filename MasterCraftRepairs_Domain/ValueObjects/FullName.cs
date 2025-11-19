namespace MasterCraftRepairs.Domain.ValueObjects;

public record FullName(string FirstName, string LastName)
{
    public string FirstName { get; init; } = ValidateName(FirstName, nameof(FirstName));
    public string LastName { get; init; } = ValidateName(LastName, nameof(LastName));

    private static string ValidateName(string? value, string paramName)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Имя не может быть пустым", paramName);

        return value.Trim();
    }
    
    public override string ToString() => $"{LastName} {FirstName}";
}
