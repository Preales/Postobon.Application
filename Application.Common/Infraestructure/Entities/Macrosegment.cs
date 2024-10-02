using System;
using Application.Common.Infraestructure.Entities.Base;
using Application.Common.Utility;

namespace Application.Common.Infraestructure.Entities
{
	public class Macrosegment : BaseEntity
	{
		[Required]
		[MaxLength(MaxLength = 200 , Message = "The field NameMacrosegment accept 200 character(s)")]
		public string NameMacrosegment{ get; set; }

	}
}
