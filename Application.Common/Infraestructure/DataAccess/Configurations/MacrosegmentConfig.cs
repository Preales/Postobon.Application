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
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd()
                .HasColumnName("Id");

            builder.Property(x => x.NameMacrosegment)
                .HasMaxLength(200)
                .IsRequired()
                .HasColumnName("SNameMacrosegment");

            base.Configure(builder);
        }
    }
}
