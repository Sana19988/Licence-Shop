using MongoDB.Entities;

namespace RenatalCar.Domain.Entities;

[Collection("vendors")]
public class Vendor : BaseEntity
{
    #region Constructors

    private Vendor()
    {

    }

    public Vendor(string name)
    {
        Name = name;
    }

    #endregion

    #region Properties

    [Field("name")]
    public string Name { get; set; }

    #endregion
}
