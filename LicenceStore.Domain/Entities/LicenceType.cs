using LicenceStore.Domain.Common;
using MongoDB.Entities;

namespace LicenceStore.Domain.Entities;

[Collection("licenceType")]
public class LicenceType : AuditableEntity
{
    [Field("name")]
    public string Name
    {
        get;
        set;
    }

    public LicenceType()
    {
        
    }
    
}