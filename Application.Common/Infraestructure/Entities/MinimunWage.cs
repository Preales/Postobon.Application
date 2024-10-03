using Application.Common.Infraestructure.Entities.Base;

namespace Application.Common.Infraestructure.Entities
{
    public class MinimunWage : BaseEntity
	{
        [Required]
        public int Id { get; set; }

        [Required]
		public int Year { get; set; }

		[Required]
		public decimal  Salary { get; set; }

		[Required]
		public bool IsActive { get; set; }

	}
}
