using Application.Common.Domain.Dtos;
using Application.Common.Infraestructure.Entities;

namespace Application.Common.Domain.Interfaces
{
    public interface IMinimunWageService
    {
        Task<MinimunWage> Create(MinimunWage item);
        Task<bool> Delete(int id);
        Task<MinimunWage> Get(int id);
        Task<IEnumerable<MinimunWage>> List();
        Task<IEnumerable<MinimunWage>> List(Pagination pagination);
        Task<MinimunWage> Update(MinimunWage item);
    }
}