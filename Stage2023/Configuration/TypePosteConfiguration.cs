using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stage2023.Models;

namespace Stage2023.Configuration
{
    internal class TypePosteConfiguration : IEntityTypeConfiguration<TypePoste>
         
    {
        public void Configure(EntityTypeBuilder<TypePoste> builder)
        {

            //  builder.HasOne(x => x.famillePoste).WithMany(x => x.Typepostes).HasForeignKey(x => x.IdFamilleposteFK);
            builder.Property(x => x.Code).HasMaxLength(50);
            builder.Property(x => x.Libelle).HasMaxLength(100);
            builder.Property(x => x.Description).HasMaxLength(200);
            builder.HasIndex(x => x.Code).IsUnique();
        }








    }
}
