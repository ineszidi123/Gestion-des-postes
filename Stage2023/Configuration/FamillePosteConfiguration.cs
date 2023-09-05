using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stage2023.Models;

namespace Stage2023.Configuration
{
    internal class FamillePosteConfiguration : IEntityTypeConfiguration<FamillePoste>
    {
        public void Configure(EntityTypeBuilder<FamillePoste> builder)
        {
            builder.HasMany(x => x.Typepostes).WithOne(x=>x.famillePoste).HasForeignKey(x =>x.IdFamilleposteFK);

            builder.Property(x => x.Code).HasMaxLength(50);
            builder.Property(x => x.Libelle).HasMaxLength(100);
            builder.HasIndex(x => x.Code).IsUnique();


        }






        }
}
