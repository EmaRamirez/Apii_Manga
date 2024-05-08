using Api_Tienda.Models;
using Microsoft.EntityFrameworkCore;


namespace Api_Tienda.Data
{
    public class Context : DbContext
    {
        
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<manga> Mangas { get; set; }
        public DbSet<editorial> Editoriales { get; set; }
        public DbSet<autor> Autores { get; set; }
        public DbSet<mangaDetails> MangaDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<manga>()
            .HasOne(x => x.autor)
            .WithMany(x => x.mangas)
            .HasForeignKey(x => x.idAutor)
            .HasPrincipalKey(x => x.idAutor);

            modelBuilder.Entity<manga>()
            .HasOne(x => x.editorial)
            .WithMany(x => x.mangas)
            .HasForeignKey(x => x.idEditorial)
            .HasPrincipalKey(x => x.idEditorial);


            modelBuilder.Entity<mangaDetails>()
            .HasOne(x => x.mangaInfo)
            .WithMany(x => x.mangasDetails)
            .HasForeignKey(x => x.idManga)
            .HasPrincipalKey(x => x.idManga);



            base.OnModelCreating(modelBuilder);
        }
    }
}