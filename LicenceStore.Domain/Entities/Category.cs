using LicenceStore.Domain.Common;
using MongoDB.Entities;

namespace LicenceStore.Domain.Entities;

[Collection("category")]
public class Category : AuditableEntity
{
    [Field("name")]
    public string Name
    {
        get;
        set;
    }

    public Category()
    {
        
    }
    
}