namespace Staycation.Data;

public class Reservation : BaseEntity
{
    public string Email { get; set; }
    public int AccommodationId { get; set; }
    public DateOnly CheckIn;
    public DateOnly CheckOut;
    public bool Confirmed { get; set; }
    public int PersonCount { get; set; }
}
