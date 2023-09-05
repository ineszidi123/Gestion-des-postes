
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stage2023.Models;

namespace Stage2023.Configuration
{
    internal class PosteConfiguration : IEntityTypeConfiguration<Poste>
    {
 

 
            public void Configure(EntityTypeBuilder<Poste> builder)
            {
                builder.HasOne(x => x.typePoste).WithMany(x => x.postes).HasForeignKey(x => x.IdTypeposteFK);
            builder.Property(x=>x.Libelle).HasMaxLength(50);
            builder.HasIndex(x=>x.Nomreseau).IsUnique();
            }
        }
    }


