using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Application.Common.Infraestructure.Entities;
using Application.Common.Infraestructure.DataAccess.Configurations.Base;
namespace Application.Common.Infraestructure.DataAccess.Configurations
{
	internal class Approval_Range_DetailsConfig : BaseEntityConfig<Approval_Range_Details>
	{
		public override void Configure(EntityTypeBuilder<Approval_Range_Details> builder)
		{
			builder.ToTable("TBL_Approval_Range_Details");
			builder.HasKey(x => x.Id);

			builder.Property(x => x.ApprovalRangeCode)
				.IsRequired()
				.HasColumnName("NApprovalRangeCode");

			builder.Property(x => x.LevelCode)
				.IsRequired()
				.HasColumnName("NLevelCode");

			builder.Property(x => x.InitialEffectiveContributionRange)
				.HasColumnName("NInitialEffectiveContributionRange");

			builder.Property(x => x.FinalEffectiveContributionRange)
				.HasColumnName("NFinalEffectiveContributionRange");

			builder.Property(x => x.InitialRangePercentageInvestment)
				.HasColumnName("NInitialRangePercentageInvestment");

			builder.Property(x => x.FinalRangePercentageInvestment)
				.HasColumnName("NFinalRangePercentageInvestment");

			base.Configure(builder);
		}
	}
}
