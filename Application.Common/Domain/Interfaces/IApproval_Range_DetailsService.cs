using Application.Common.Domain.Dtos;
using Application.Common.Infraestructure.Entities;

namespace Application.Common.Domain.Interfaces
{
    public interface IApproval_Range_DetailsService
    {
        Task<Approval_Range_Details> Create(Approval_Range_Details item);
        Task<bool> Delete(int id);
        Task<Approval_Range_Details> Get(int id);
        Task<IEnumerable<Approval_Range_Details>> List();
        Task<IEnumerable<Approval_Range_Details>> List(Pagination pagination);
        Task<Approval_Range_Details> Update(Approval_Range_Details item);
    }
}
