using Application.Common.Infraestructure.Entities.Base;


namespace Application.Common.Infraestructure.Entities
{
    public class LogExceptionInfo : BaseEntity
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(MaxLength = 100, Message = "The field Class accept 50 character(s)")]
        public required string Name { get; set; }

        [Required]
        [MaxLength(MaxLength = 50, Message = "The field Class accept 50 character(s)")]
        public string Class { get; set; }

        [MaxLength(MaxLength = 2000, Message = "The field Message accept 2000 character(s)")]
        public string Message { get; set; }

        [Required]
        [MaxLength(MaxLength = 100, Message = "The field Method accept 100 character(s)")]
        public string Method { get; set; }

        [MaxLength(MaxLength = 2000, Message = "The field Source accept 2000 character(s)")]
        public string Source { get; set; }

        public string Stack { get; set; }

        [Required]
        [MaxLength(MaxLength = 50, Message = "The field Type accept 50 character(s)")]
        public string Type { get; set; }

        [Required]
        [MaxLength(MaxLength = 255, Message = "The field Description accept 2000 character(s)")]
        public string Description { get; set; }
    }
}
