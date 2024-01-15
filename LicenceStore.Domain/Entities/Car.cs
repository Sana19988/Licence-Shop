using Ardalis.GuardClauses;
using LicenceStore.Domain.Common;
using LicenceStore.Domain.Common.Locale;
using MongoDB.Entities;

namespace LicenceStore.Domain.Entities;

[Collection("Cars")]
public class Car : AuditableEntity
{
    public Locales Locales { get; private set; }
    public int NumberOfDoors { get; private set; }

    private Car()
    {
    }

    public Car(Locales locales, int numberOfDoors)
    {
        Locales = Guard.Against.Null(locales,
            nameof(locales));
        NumberOfDoors = Guard.Against.NegativeOrZero(numberOfDoors,
            nameof(numberOfDoors));
    }
}
