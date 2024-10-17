using Application.Common.Infraestructure.DataAccess.Configurations.Base;
using Application.Common.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Common.Infraestructure.DataAccess.Configurations
{
    internal class MacrosegmentConfig : BaseEntityConfig<Macrosegment>
    {
        public override void Configure(EntityTypeBuilder<Macrosegment> builder)
        {
            builder.ToTable("TBL_Macrosegment");
            builder.HasKey(x => x.Code);

            builder.Property(x => x.Code)
                .HasMaxLength(3)
                .IsRequired()
                .HasColumnName("SCode");

            builder.Property(x => x.Description)
                .HasMaxLength(20)
                .IsRequired()
                .HasColumnName("SDescription");

            builder.Property(x => x.IsActive)
                .IsRequired()
                .HasColumnName("BIsActive");

            base.Configure(builder);

        }
    }
}
