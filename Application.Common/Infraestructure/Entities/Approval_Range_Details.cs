using System;
using Application.Common.Infraestructure.Entities.Base;
using Application.Common.Utility;

namespace Application.Common.Infraestructure.Entities
{
	public class Approval_Range_Details : BaseEntity
	{
		[Required]
		public int ApprovalRangeCode { get; set; }

		[Required]
		public int LevelCode { get; set; }

		public decimal? InitialEffectiveContributionRange { get; set; }

		public decimal? FinalEffectiveContributionRange { get; set; }

		public decimal? InitialRangePercentageInvestment { get; set; }

		public decimal? FinalRangePercentageInvestment { get; set; }

	}
}
