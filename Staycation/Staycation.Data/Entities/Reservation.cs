using System.ComponentModel.DataAnnotations.Schema;

namespace Staycation.Data.Entities;

public class Reservation : BaseEntity
{
    public string Email { get; set; }

    [ForeignKey(nameof(Accommodation))]
    public int AccommodationId { get; set; }

    public virtual Accommodation Accommodation { get; set; }

    public DateOnly CheckIn;
    public DateOnly CheckOut;
    public bool Confirmed { get; set; }
    public int PersonCount { get; set; }
}
