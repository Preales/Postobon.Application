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
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id");

            builder.Property(x => x.NameTypology)
                .HasMaxLength(200)
                .IsRequired()
                .HasColumnName("SNameTypology");

            base.Configure(builder);
        }
    }
}
