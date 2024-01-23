using LicenceStore.Domain.Common;
using MongoDB.Entities;

namespace LicenceStore.Domain.Entities;

[Collection("licences")]
public class Licence : AuditableEntity
{
    public Licence()
    {
    }
    
    [Field("name")]
    public string Name { get; set; }
    
    [Field("vendor")]
    public One<Vendor> Vendor { get; set; }
    
    [Field("category")]
    public One<Category> Category { get; set; }
    
    [Field("type")]
    public One<LicenceType> Type { get; set; }
    
    [Field("sold")]
    public bool IsSold { get; set; }
    
    [Field("bought")]
    public bool IsBought { get; set; }

    [Field("price")]
    public double Price { get; set; }
    
    [Field("img")]
    public string Img { get; set; }
    
    [Field("description")]
    public string Description { get; set; }
    
    [Field("owner")]
    public ApplicationUser? Owner { get; set; }
    
    [Field("startDate")]
    public DateTime StartDate { get; set; }
    
    [Field("endDate")]
    public DateTime EndDate { get; set; }

    public Licence AddOwner(ApplicationUser owner)
    {
        Owner = owner;
        return this;
    }
    
}