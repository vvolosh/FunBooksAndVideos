using FunBooksAndVideos.Enums;

namespace FunBooksAndVideos.Entities.Products;

public abstract class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public virtual ProductType ProductType { get; set; }
}

public class Customer
{
    public int Id { get; set; }
    public string UserName { get; set; }
    
}

public class CustomerMembership
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int MembershipId { get; set; }
    public string UserName { get; set; }
    
}

