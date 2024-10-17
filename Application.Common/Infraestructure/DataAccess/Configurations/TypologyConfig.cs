using Application.Common.Infraestructure.DataAccess.Configurations.Base;
using Application.Common.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Common.Infraestructure.DataAccess.Configurations
{
    internal class TypologyConfig : BaseEntityConfig<Typology>
    {
        public override void Configure(EntityTypeBuilder<Typology> builder)
        {
            builder.ToTable("TBL_Typology");
            builder.HasKey(x => x.Code);

            builder.Property(x => x.Code)
                .HasMaxLength(3)
                .IsRequired()
                .HasColumnName("SCode");

            builder.Property(x => x.Description)
                .HasMaxLength(200)
                .IsRequired()
                .HasColumnName("SDescription");

            builder.Property(x => x.IsActive)
                .IsRequired()
                .HasColumnName("BIsActive");

            base.Configure(builder);
        }
    }
}
