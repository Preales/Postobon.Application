using Application.Common.Infraestructure.Entities.Base;

namespace Application.Common.Infraestructure.Entities
{
    public class Macrosegment : BaseEntity, IEntityAudit
    {
        [Required]
        [MaxLength(MaxLength = 3, Message = "The field Code accept 3 character(s)")]
        public string Code { get; set; }

        [Required]
        [MaxLength(MaxLength = 20, Message = "The field Description accept 20 character(s)")]
        public string Description { get; set; }

        [Required]
        public bool IsActive { get; set; }

    }
}
