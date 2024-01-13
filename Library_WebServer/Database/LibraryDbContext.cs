using Library_WebServer.Enums;
using Library_WebServer.Models.Database;
using Library_WebServer.Models.Requests;
using Microsoft.EntityFrameworkCore;

namespace Library_WebServer.Database
{
    public class LibraryDbContext : DbContext
    {
        private const string CONNECTION_STRING = "Server=localhost;Port=5432;Database=library;User Id=admin;Password=admin;";
        public DbSet<UserDbModel> Users { get; set; }
        public DbSet<AuthorDbModel> Authors { get; set; }
        public DbSet<CommentDbModel> Comments { get; set; }
        public DbSet<PublicationDbModel> Publications { get; set; }
        public DbSet<RentalDbModel> Rentals { get; set; }
        public DbSet<ReservationDbModel> Reservations { get; set; }
        public DbSet<PublicationGenreDbModel> Genres { get; set; }
        public DbSet<PublicationStatusDbModel> Statuses { get; set; }
        public DbSet<PublicationTypeDbModel> PublicationTypes { get; set; }
        public DbSet<UserAccountTypeDbModel> AccountTypes { get; set; }

        public LibraryDbContext(DbContextOptions options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseNpgsql("dupa");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDbModel>().ToTable("Users");

            modelBuilder.Entity<AuthorDbModel>().ToTable("Authors");
            modelBuilder.Entity<CommentDbModel>().ToTable("Comments");
            modelBuilder.Entity<PublicationDbModel>().ToTable("Publications");
            modelBuilder.Entity<RentalDbModel>().ToTable("Rentals");
            modelBuilder.Entity<ReservationDbModel>().ToTable("Reservations");

            modelBuilder.Entity<PublicationGenreDbModel>().ToTable("Genres");
            modelBuilder.Entity<PublicationStatusDbModel>().ToTable("Statuses");
            modelBuilder.Entity<PublicationTypeDbModel>().ToTable("PublicationTypes");
            modelBuilder.Entity<UserAccountTypeDbModel>().ToTable("AccountTypes");

            SeedEnumValues<PublicationGenreDbModel, LibraryObjectGenreEnum>(modelBuilder, x => new PublicationGenreDbModel(x));
            SeedEnumValues<PublicationStatusDbModel, LibraryObjectStatusEnum>(modelBuilder, x => new PublicationStatusDbModel(x));
            SeedEnumValues<PublicationTypeDbModel, LibraryObjectTypeEnum>(modelBuilder, x => new PublicationTypeDbModel(x));
            SeedEnumValues<UserAccountTypeDbModel, UserAccountTypeEnum>(modelBuilder, x => new UserAccountTypeDbModel(x));
        }

        public static void SeedEnumValues<T, TEnum>(ModelBuilder mb, Func<TEnum, T> converter)
            where T : class => Enum.GetValues(typeof(TEnum))
                         .Cast<object>()
                         .Select(value => converter((TEnum)value))
                         .ToList()
                         .ForEach(instance => mb.Entity<T>().HasData(instance));
    }
}
