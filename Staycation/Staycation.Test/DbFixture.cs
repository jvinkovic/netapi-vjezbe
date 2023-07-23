using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Staycation.Data;
using Staycation.Data.Entities;

namespace Staycation.Test;

public class DbFixture : IDisposable

{
    public readonly StaycationContext Context;

    public DbFixture()
    {
        Context = new StaycationContext(CreateNewContextOptions(useSqlite: true));

        Context.Database.EnsureCreated();

        SeedData(Context);
    }

    private DbContextOptions<StaycationContext> CreateNewContextOptions(bool useSqlite = false)
    {
        DbContextOptions<StaycationContext> options;
        if (useSqlite)
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            options = new DbContextOptionsBuilder<StaycationContext>()
                        .UseSqlite(connection)
                        .EnableSensitiveDataLogging()
                        .Options;
        }
        else
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            options = new DbContextOptionsBuilder<StaycationContext>()
                        .UseInMemoryDatabase(databaseName: "staycation-db")
                        .UseInternalServiceProvider(serviceProvider)
                        .EnableSensitiveDataLogging()
                        .Options;
        }

        return options;
    }

    private void SeedData(StaycationContext context)
    {
        context.Locations.AddRange(new Location { Id = 1, Name = "Argos", PostalCode = "21200", ImageUrl = "https://images2.imgbox.com/66/33/4ll057fa_o.jpg" },
                    new Location { Id = 2, Name = "Chania", PostalCode = "74212", ImageUrl = "https://images2.imgbox.com/62/d7/3rJYe9p9_o.jpg" },
                    new Location { Id = 3, Name = "Nafplion", PostalCode = "21100", ImageUrl = "https://images2.imgbox.com/34/8f/yeONFHwj_o.jpg" },
                    new Location { Id = 4, Name = "Osijek", PostalCode = "31000", ImageUrl = "https://images2.imgbox.com/fd/3b/xYT7BlSR_o.jpg" });

        context.Accommodations.AddRange(
            new Accommodation
            {
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
            new Accommodation
            {
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
            new Accommodation
            {
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
            });

        context.Reservations.AddRange(
            new Reservation
            {
                Id = 1,
                PersonCount = 2,
                AccommodationId = 3,
                Confirmed = true,
                Email = "mjmail@himail.com",
                CheckIn = new DateOnly(2023, 11, 11),
                CheckOut = new DateOnly(2023, 11, 21)
            },
            new Reservation
            {
                Id = 2,
                PersonCount = 9,
                AccommodationId = 1,
                Confirmed = true,
                Email = "pero@himail.com",
                CheckIn = new DateOnly(2023, 2, 1),
                CheckOut = new DateOnly(2023, 2, 8)
            },
            new Reservation
            {
                Id = 3,
                PersonCount = 4,
                AccommodationId = 3,
                Confirmed = true,
                Email = "lara@himail.com",
                CheckIn = new DateOnly(2023, 7, 18),
                CheckOut = new DateOnly(2023, 7, 22)
            },
            new Reservation
            {
                Id = 4,
                PersonCount = 5,
                AccommodationId = 2,
                Confirmed = true,
                Email = "info@gert.hr",
                CheckIn = new DateOnly(2023, 5, 25),
                CheckOut = new DateOnly(2023, 6, 11)
            });
    }

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (disposed)
        {
            return;
        }

        if (disposing)
        {
            if (Context != null)
            {
                Context.Dispose();
            }
        }

        disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~DbFixture()
    {
        Dispose(false);
    }
}
