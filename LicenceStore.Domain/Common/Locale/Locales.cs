namespace LicenceStore.Domain.Common.Locale;

public class Locales
{
    public LocaleParameters? Sr { get; private set; }
    public LocaleParameters? En { get; private set; }

    private Locales()
    {
    }

    public Locales(LocaleParameters? sr, LocaleParameters? en)
    {
        Sr = sr;
        En = en;
    }
}
