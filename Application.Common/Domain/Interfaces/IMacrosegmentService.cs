using Application.Common.Domain.Dtos;
using Application.Common.Infraestructure.Entities;

namespace Application.Common.Domain.Interfaces
{
    public interface IMacrosegmentService
    {
        Task<Macrosegment> Create(Macrosegment item);
        Task<bool> Delete(int id);
        Task<Macrosegment> Get(int id);
        Task<IEnumerable<Macrosegment>> List();
        Task<IEnumerable<Macrosegment>> List(Pagination pagination);
        Task<Macrosegment> Update(Macrosegment item);
    }
}