using FirmaData.Data.CMS;
using FirmaData.Data.Sklep;
using Microsoft.EntityFrameworkCore;

namespace FirmaData.Data
{
    public class FormaContext : DbContext
    {
        public FormaContext(DbContextOptions<FormaContext> options)
        : base(options)
        {
        }

        public DbSet<TattoArtists> TattoArtists { get; set; } = default!;
        public DbSet<Klient> Klient { get; set; } = default!;
        public DbSet<Tatto> Tatto { get; set; } = default!;
        public DbSet<Rezerwacje> Rezerwacje { get; set; } = default!;
        public DbSet<Galeria> Galeria { get; set; } = default!;
        public DbSet<Platnosc> Platnosc { get; set; } = default!;
        public DbSet<Produkt> Produkt { get; set; } = default!;
        public DbSet<Recenzja> Recenzja { get; set; } = default!;
        public DbSet<User> User { get; set; } = default!;
        public DbSet<Zamowienia> Zamowienia { get; set; } = default!;
        public DbSet<Strona> Strona { get; set; } = default!;
        public DbSet<ContentString> ContentString { get; set; } = default!;
        public DbSet<ContentImage> ContentImage { get; set; } = default!;
        public DbSet<ContentInput> ContentInput { get; set; } = default!;
    }
}
