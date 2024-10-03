using Application.Common.Domain.Dtos;
using Application.Common.Domain.Interfaces;
using Application.Common.Infraestructure.DataAccess;
using Application.Common.Infraestructure.Entities;

namespace Application.Common.Domain.Services
{
    public class MinimunWageService : IMinimunWageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ExceptionModule _exceptionModule;
        public MinimunWageService(IUnitOfWork unitOfWork,
                ExceptionModule exceptionModule)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _exceptionModule = exceptionModule ?? throw new ArgumentNullException(nameof(exceptionModule));
        }

        public async Task<MinimunWage> Create(MinimunWage item)
        {
            MinimunWage result = null;
            try
            {
                Validator.Validate<MinimunWage>(item);
                result = _unitOfWork.MinimunWageRepository.Add(item);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await _exceptionModule.Log(ex);
            }
            return result;
        }

        public async Task<MinimunWage> Update(MinimunWage item)
        {
            MinimunWage result = null;
            try
            {
                result = await _unitOfWork.MinimunWageRepository.GetAsync(x => x.Id == item.Id);
                if (result != null)
                {
                    result.Year = item.Year;
                    result.Salary = item.Salary;                    
                    result.IsActive = item.IsActive;

                    await _unitOfWork.MinimunWageRepository.UpdateAsync(result);
                    await _unitOfWork.SaveChangesAsync();
                }
                else
                {
                    throw new ArgumentException("El item que intentas actualizar no existe");
                }
            }
            catch (Exception ex)
            {
                await _exceptionModule.Log(ex);
            }
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            bool result = false;
            try
            {
                MinimunWage item = await _unitOfWork.MinimunWageRepository.GetAsync(x => x.Id == id);
                if (item != null)
                {
                    _unitOfWork.MinimunWageRepository.Remove(item);
                    await _unitOfWork.SaveChangesAsync();
                    result = true;
                }
                else
                {
                    throw new ArgumentException("El item que intentas eliminar no existe");
                }
            }
            catch (Exception ex)
            {
                await _exceptionModule.Log(ex);
            }
            return result;
        }

        public async Task<MinimunWage> Get(int id)
        {
            MinimunWage result = new MinimunWage();
            try
            {
                result = await _unitOfWork.MinimunWageRepository.GetAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                await _exceptionModule.Log(ex);
            }
            return result;
        }

        public async Task<IEnumerable<MinimunWage>> List(Pagination pagination)
        {
            IEnumerable<MinimunWage> result = new List<MinimunWage>();
            try
            {
                result = await _unitOfWork.MinimunWageRepository.GetListAsync(pagination);
            }
            catch (Exception ex)
            {
                await _exceptionModule.Log(ex);
            }
            return result;
        }

        public async Task<IEnumerable<MinimunWage>> List()
        {
            IEnumerable<MinimunWage> result = new List<MinimunWage>();
            try
            {
                result = await _unitOfWork.MinimunWageRepository.GetListAsync();
            }
            catch (Exception ex)
            {
                await _exceptionModule.Log(ex);
            }
            return result;
        }

    }
}
