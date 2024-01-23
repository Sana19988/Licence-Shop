using LicenceStore.Domain.Common;
using MongoDB.Entities;

namespace LicenceStore.Domain.Entities;

[Collection("orders")]
public class Order : AuditableEntity
{
    public ApplicationUser Customer { get; set; }

    public List<Licence> Licences { get; set; }
    
    public string Status { get; set; }
    
    public double TotalPrice { get; set; }
    
    public long OrderCode { get; set; }
    
    public Order()
    {
    }

    public Order CalculateTotalPrice()
    {
        TotalPrice = this.Licences.Sum(l => l.Price);
        return this;
    }
}