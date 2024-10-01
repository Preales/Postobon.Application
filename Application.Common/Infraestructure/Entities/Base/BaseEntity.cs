using System.Diagnostics.CodeAnalysis;

namespace Application.Common.Infrastructure.DataAccess.Entities.Base
{
    [ExcludeFromCodeCoverage]
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime? CreationDate { get; set; }
        public string CreationUser { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string ModificationUser { get; set; }
        public bool Deleted { get; set; }
    }
}