using Application.Common.Infrastructure.DataAccess.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;


namespace Application.Common.Infraestructure.DataAccess.Configurations.Base
{
    [ExcludeFromCodeCoverage]
    internal class BaseEntityConfig<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(e => e.CreationDate)
                .HasColumnName("DCreationDate")
                .HasColumnType("datetime");

            builder.Property(e => e.CreationUser)
                .HasColumnName("SCreationUser")
                .HasMaxLength(300)
                .IsUnicode(false);

            builder.Property(e => e.ModificationDate)
                .HasColumnName("DModificationDate")
                .HasColumnType("datetime");

            builder.Property(e => e.ModificationUser)
                .HasColumnName("SModificationUser")
                .HasMaxLength(300)
                .IsUnicode(false);

            builder.Property(e => e.Deleted)
                .HasColumnName("BDeleted")
                .IsUnicode(false);
        }
    }
}
