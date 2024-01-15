using MongoDB.Entities;

namespace RenatalCar.Domain.Entities;

[Collection("cars")]
public class Car : BaseEntity
{
    [Field("name")]
    public string Name { get; private set; }

    [Field("year_production")]
    public int YearProduction { get; private set; }
    
    [Field("vendor")]
    public One<Vendor> Vendor { get; private set; }

    public Car(string name)
    {
        Name = name;
    }

    private Car()
    {
    }

    public Car AddYearProduction(int yearProduction)
    {
        YearProduction = yearProduction;

        return this;
    }
    
    public Car AddVendor(One<Vendor> vendor)
    {
        Vendor = vendor;

        return this;
    }
}
