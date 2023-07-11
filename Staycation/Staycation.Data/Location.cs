namespace Staycation.Data;

public class Location : BaseEntity
{
    public string? Name { get; set; }

    public string PostalCode { get; set; }

    public string ImageUrl { get; set; }
}
