using Application.Common.Domain.Dtos;
using Application.Common.Infraestructure.Entities;

namespace Application.Common.Domain.Interfaces
{
    public interface IApproval_RangeService
    {
        Task<Approval_Range> Create(Approval_Range item);
        Task<bool> Delete(int id);
        Task<Approval_Range> Get(int id);
        Task<IEnumerable<Approval_Range>> List();
        Task<IEnumerable<Approval_Range>> List(Pagination pagination);
        Task<Approval_Range> Update(Approval_Range item);
    }
}
