using System.Diagnostics.CodeAnalysis;

namespace Application.Common.Infraestructure.Entities.Base;

[ExcludeFromCodeCoverage]
public abstract class BaseEntity
{
    public DateTime? CreationDate { get; set; }
    public string CreationUser { get; set; } = string.Empty;
    public DateTime? ModificationDate { get; set; }
    public string ModificationUser { get; set; } = string.Empty;
    public bool Deleted { get; set; }
}