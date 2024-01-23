using AspNetCore.Identity.MongoDbCore.Models;
using MongoDB.Entities;
using MongoDbGenericRepository.Attributes;

namespace LicenceStore.Domain.Entities;

[CollectionName("Users")]
public class ApplicationUser : MongoIdentityUser<Guid>, IModifiedOn, IEntity
{
    public string? Name { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public override string? Email { get; set; }
    public List<Licence> Licences { get; set; }
    public List<string> Roles { get; set; }
    public double Balance { get; set; }
    
    public DateTime ModifiedOn { get; set; }
    public string GenerateNewID()
    {
        throw new NotImplementedException();
    }

    public string? ID { get; set; }
    
    public ApplicationUser()
    {
       
    }
}
