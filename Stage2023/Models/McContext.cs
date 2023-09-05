using Microsoft.EntityFrameworkCore;
using Stage2023.Configuration;

namespace Stage2023.Models
{
    public class McContext : DbContext
    {

       


            //public MtraceContext(DbContextOptions<MtraceContext> options)
            //    : base(options)
            //{

            //}
            public McContext()
            {
            }
            public McContext(DbContextOptions<McContext> options)
                : base(options)
            {

            }
            public virtual DbSet<Poste> Postes { get; set; }
        public virtual DbSet<TypePoste> TypePostes { get; set; }
        public virtual DbSet<FamillePoste> FamillePostes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
             => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Stage;Trusted_Connection=True;MultipleActiveResultSets=true");
            protected override void OnModelCreating(ModelBuilder builder)
            {
                base.OnModelCreating(builder);
            builder.ApplyConfiguration(new PosteConfiguration());
            builder.ApplyConfiguration(new TypePosteConfiguration());
            builder.ApplyConfiguration(new FamillePosteConfiguration());
        }
        }
}
