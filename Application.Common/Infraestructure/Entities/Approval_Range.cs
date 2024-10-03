using System;
using Application.Common.Infraestructure.Entities.Base;
using Application.Common.Utility;

namespace Application.Common.Infraestructure.Entities
{
	public class Approval_Range : BaseEntity
	{
		[Required]
		public int CompanyCode { get; set; }

	}
}
