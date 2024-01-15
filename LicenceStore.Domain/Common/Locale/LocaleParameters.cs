using Ardalis.GuardClauses;

namespace LicenceStore.Domain.Common.Locale;

public class LocaleParameters
{
    public string Slug { get; private set; }

    public string Name { get; private set; }

    public string? Description { get; private set; }

    private LocaleParameters()
    {
    }

    public LocaleParameters(string slug, string name, string? description)
    {
        Slug = Guard.Against.NullOrWhiteSpace(slug,
            nameof(slug));

        Name = Guard.Against.NullOrWhiteSpace(name,
            nameof(name));

        Description = description;
    }
}
