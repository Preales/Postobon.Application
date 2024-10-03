using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Application.Common.Infraestructure.Entities;
using Application.Common.Infraestructure.DataAccess.Configurations.Base;
namespace Application.Common.Infraestructure.DataAccess.Configurations
{
	internal class Approval_RangeConfig : BaseEntityConfig<Approval_Range>
	{
		public override void Configure(EntityTypeBuilder<Approval_Range> builder)
		{
			builder.ToTable("TBL_Approval_Range");
			builder.HasKey(x => x.Id);

			builder.Property(x => x.CompanyCode)
				.IsRequired()
				.HasColumnName("NCompanyCode");

			base.Configure(builder);
		}
	}
}
