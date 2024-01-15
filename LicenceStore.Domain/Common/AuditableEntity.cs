using MongoDB.Entities;

namespace LicenceStore.Domain.Common;

public class AuditableEntity : Entity, IModifiedOn, ICreatedOn
{
    public DateTime ModifiedOn { get; set; }
    public DateTime CreatedOn { get; set; }
    public string? CreatedBy { get; set; }
    public string? ModifiedBy { get; set; }
    public bool Active { get; set; }
}
