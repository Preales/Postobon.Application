using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Application.Common.Infraestructure.Entities;
using Application.Common.Infraestructure.DataAccess.Configurations.Base;
namespace Application.Common.Infraestructure.DataAccess.Configurations
{
	internal class MinimunWageConfig : BaseEntityConfig<MinimunWage>
	{
		public override void Configure(EntityTypeBuilder<MinimunWage> builder)
		{
			builder.ToTable("TBL_MinimunWage");
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Year)
				.IsRequired()
				.HasColumnName("NYear");

			builder.Property(x => x.Salary)
				.IsRequired()
				.HasColumnName("NSalary");

			builder.Property(x => x.IsActive)
				.IsRequired()
				.HasColumnName("BIsActive");

			base.Configure(builder);
		}
	}
}
