using LicenceStore.Domain.Common;
using MongoDB.Entities;

namespace LicenceStore.Domain.Entities;

[Collection("vendors")]
public class Vendor : AuditableEntity
{
    [Field("name")]
    public string Name
    {
        get;
        set;
    }
    
    [Field("type")]
    public string Type
    {
        get;
        set;
    }

    public Vendor()
    {
        
    }
}