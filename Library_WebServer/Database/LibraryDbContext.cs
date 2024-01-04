using Library_WebServer.Enums;
using Library_WebServer.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_WebServer.Database
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<LibraryAuthor> Authors { get; set; }
        public DbSet<LibraryComment> Comments { get; set; }
        public DbSet<LibraryPublication> Publications { get; set; }
        public DbSet<LibraryReservation> Reservations { get; set; }
        public DbSet<LibraryObjectGenre> Genres { get; set; }
        public DbSet<LibraryObjectStatus> Statuses { get; set; }
        public DbSet<LibraryObjectType> PublicationTypes { get; set; }
        public DbSet<UserAccountType> AccountTypes{ get; set; }

        public LibraryDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");

            modelBuilder.Entity<LibraryAuthor>().ToTable("Authors");
            modelBuilder.Entity<LibraryComment>().ToTable("Comments");
            modelBuilder.Entity<LibraryPublication>().ToTable("Publications");
            modelBuilder.Entity<LibraryReservation>().ToTable("Reservations");

            modelBuilder.Entity<LibraryObjectGenre>().ToTable("Genres");
            modelBuilder.Entity<LibraryObjectStatus>().ToTable("Statuses");
            modelBuilder.Entity<LibraryObjectType>().ToTable("PublicationTypes");
            modelBuilder.Entity<UserAccountType>().ToTable("AccountTypes");

            SeedEnumValues<LibraryObjectGenre, LibraryObjectGenreEnum>(modelBuilder, x => new LibraryObjectGenre(x));
            SeedEnumValues<LibraryObjectStatus, LibraryObjectStatusEnum>(modelBuilder, x => new LibraryObjectStatus(x));
            SeedEnumValues<LibraryObjectType, LibraryObjectTypeEnum>(modelBuilder, x => new LibraryObjectType(x));
            SeedEnumValues<UserAccountType, UserAccountTypeEnum>(modelBuilder, x => new UserAccountType(x));
        }

        public static void SeedEnumValues<T, TEnum>(ModelBuilder mb, Func<TEnum, T> converter)
            where T : class => Enum.GetValues(typeof(TEnum))
                         .Cast<object>()
                         .Select(value => converter((TEnum)value))
                         .ToList()
                         .ForEach(instance => mb.Entity<T>().HasData(instance));
    }
}
