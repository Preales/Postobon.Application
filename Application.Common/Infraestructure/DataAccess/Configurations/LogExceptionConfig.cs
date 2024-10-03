using Application.Common.Infraestructure.DataAccess.Configurations.Base;
using Application.Common.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Common.Infraestructure.DataAccess.Configurations
{
    internal sealed class LogExceptionConfig : BaseEntityConfig<LogExceptionInfo>
    {
        public override void Configure(EntityTypeBuilder<LogExceptionInfo> builder)
        {
            builder.ToTable("TBL_LogException");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Type).HasMaxLength(50).IsRequired().HasColumnName("Type");
            builder.Property(x => x.Class).HasMaxLength(50).IsRequired().HasColumnName("Class");
            builder.Property(x => x.Method).HasMaxLength(100).IsRequired().HasColumnName("Method");
            builder.Property(x => x.Message).HasMaxLength(2000).HasColumnName("Message");
            builder.Property(x => x.Source).HasMaxLength(2000).HasColumnName("Source");
            builder.Property(x => x.Stack).HasColumnName("Stack");
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired().HasColumnName("Name");
            builder.Property(x => x.Description).HasMaxLength(255).HasColumnName("Description");


            base.Configure(builder);
        }
    }
}