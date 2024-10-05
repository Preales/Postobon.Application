using Application.Common.Infraestructure.Entities.Base;

namespace Application.Common.Infraestructure.Entities
{
	public class Typology : BaseEntity
	{
		[Required]
		[MaxLength(MaxLength = 3 , Message = "The field Code accept 3 character(s)")]
		public string Code { get; set; }

		[Required]
		[MaxLength(MaxLength = 200 , Message = "The field Description accept 200 character(s)")]
		public string Description { get; set; }

		[Required]
		public bool IsActive { get; set; }

	}
}
