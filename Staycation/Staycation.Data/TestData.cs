namespace Staycation.Data;

public static class TestData
{
    public static ICollection<Location> Locations = new List<Location>
    {
        new Location{ Id = 1, Name = "Argos", PostalCode = "21200", ImageUrl = "https://images2.imgbox.com/66/33/4ll057fa_o.jpg" },
        new Location{ Id = 2, Name = "Chania", PostalCode = "74212", ImageUrl = "https://images2.imgbox.com/62/d7/3rJYe9p9_o.jpg" },
        new Location{ Id = 3, Name = "Nafplion", PostalCode = "21100", ImageUrl = "https://images2.imgbox.com/34/8f/yeONFHwj_o.jpg" },
        new Location{ Id = 4, Name = "Osijek", PostalCode = "31000", ImageUrl = "https://images2.imgbox.com/fd/3b/xYT7BlSR_o.jpg" }
    };

    public static ICollection<Accommodation> Accommodations = new List<Accommodation>
    {
        new Accommodation{
            Id = 1,
            Title = "Adama",
            ImageUrl = "https://picsum.photos/800/600",
            Categorisation = 4,
            Description = "Family hotel",
            FreeCancellation = false,
            LocationId = 3,
            PersonCount = 230,
            Price = 133.99m,
            Subtitle = "Your getaway",
            Type = "Hotel"
        },
        new Accommodation{
            Id = 2,
            Title = "CasaKrystal",
            ImageUrl = "https://picsum.photos/800/600",
            Categorisation = 4,
            Description = "Villa in Nafplion",
            FreeCancellation = true,
            LocationId = 3,
            PersonCount = 310,
            Price = 199.99m,
            Subtitle = "Villa",
            Type = "Villa"
        },
        new Accommodation{
            Id = 3,
            Title = "Epoketa",
            ImageUrl = "https://picsum.photos/800/600",
            Categorisation = 3,
            Description = "Cozy studio near big parks",
            FreeCancellation = true,
            LocationId = 4,
            PersonCount = 230,
            Price = 49.99m,
            Subtitle = "Apartment in heart of Osijek",
            Type = "Apartment"
        },
    };

    public static ICollection<Reservation> Reservations = new List<Reservation>
    {
        new Reservation{ Id = 1, PersonCount = 2, AccommodationId = 3, Confirmed = true, Email = "mjmail@himail.com",
                        CheckIn = new DateOnly(2023,11,11), CheckOut = new DateOnly(2023,11,21) },
        new Reservation{ Id = 2, PersonCount = 9, AccommodationId = 1, Confirmed = true, Email = "pero@himail.com",
                        CheckIn = new DateOnly(2023,2,1), CheckOut = new DateOnly(2023,2,8) },
        new Reservation{ Id = 3, PersonCount = 4, AccommodationId = 3, Confirmed = true, Email = "lara@himail.com",
                        CheckIn = new DateOnly(2023,7,18), CheckOut = new DateOnly(2023,7,22) },
        new Reservation{ Id = 4, PersonCount = 5, AccommodationId = 2, Confirmed = true, Email = "info@gert.hr",
                        CheckIn = new DateOnly(2023,5,25), CheckOut = new DateOnly(2023,6,11) },
    };
}
