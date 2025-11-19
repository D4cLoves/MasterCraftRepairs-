namespace MasterCraftRepairs.Domain.ValueObjects;

public record PassportNumber(string passportNumber)
{
    public string Value { get; init; } = Validate(passportNumber);
    private static string Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("ошибка - пусто");

        string cleaned = value.Trim();
        
        if (cleaned.Length != 10)
            throw new ArgumentException("ошибка - неправильная длина номера паспорта");
        
        return cleaned.ToUpper();
    }
    public override string ToString() => Value;
}