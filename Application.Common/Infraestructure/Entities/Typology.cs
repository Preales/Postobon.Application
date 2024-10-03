using System;
using Application.Common.Infraestructure.Entities.Base;
using Application.Common.Utility;

namespace Application.Common.Infraestructure.Entities
{
	public class Typology : BaseEntity
	{

        [Required]
        public int Id { get; set; }

        [Required]
		[MaxLength(MaxLength = 200 , Message = "The field NameTypology accept 200 character(s)")]
		public string NameTypology{ get; set; }

	}
}
