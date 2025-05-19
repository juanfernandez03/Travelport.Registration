using System.Text.RegularExpressions;

namespace Travelport.Domain.ValueObjects;

public sealed class PassportNumber : IEquatable<PassportNumber>
{
    private static readonly Regex Format = new(@"^[PL]{1}[A-Z]{1}[0-9]{7}$");

    public string Value { get; }

    private PassportNumber(string value)
    {
        Value = value;
    }

    public static PassportNumber Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Passport number is required.");

        if (!Format.IsMatch(value))
            throw new ArgumentException("Invalid passport number format.");

        return new PassportNumber(value);
    }

    public override string ToString() => Value;

    public bool Equals(PassportNumber? other) =>
        other is not null && Value == other.Value;

    public override bool Equals(object? obj) =>
        obj is PassportNumber other && Equals(other);

    public override int GetHashCode() => Value.GetHashCode();
}
