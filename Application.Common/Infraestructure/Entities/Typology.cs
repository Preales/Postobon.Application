using System;
using Application.Common.Infraestructure.Entities.Base;
using Application.Common.Utility;

namespace Application.Common.Infraestructure.Entities
{
	public class Typology : BaseEntity
	{
		[Required]
		[MaxLength(MaxLength = 200 , Message = "The field NameTypology accept 200 character(s)")]
		public string NameTypology{ get; set; }

	}
}
