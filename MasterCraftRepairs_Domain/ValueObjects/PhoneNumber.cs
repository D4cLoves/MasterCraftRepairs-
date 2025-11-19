namespace MasterCraftRepairs.Domain.ValueObjects;

public record PhoneNumber(string Phone)
{
    public string Value {get; init;} = Validate(Phone);

    private static string Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("пустой тел");

        var cleaned = value.Replace(" ", "").Replace("-", "");

        if (!cleaned.StartsWith("+7") && !cleaned.StartsWith("8"))
            throw new ArgumentException("без чурок бро, санкции");
        
        if (cleaned.Length < 11)
            throw new ArgumentException("не то");
        
        return cleaned.StartsWith("+7") ? cleaned.ToUpper() : "+" + cleaned.ToUpper();
    }
    public override string ToString() => Value;
}