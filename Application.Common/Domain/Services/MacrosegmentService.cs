using Application.Common.Domain.Dtos;
using Application.Common.Domain.Interfaces;
using Application.Common.Infraestructure.DataAccess;
using Application.Common.Infraestructure.Entities;

namespace Application.Common.Domain.Services
{
    public class MacrosegmentService : IMacrosegmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ExceptionModule _exceptionModule;

        public MacrosegmentService(IUnitOfWork unitOfWork,
                ExceptionModule exceptionModule)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _exceptionModule = exceptionModule ?? throw new ArgumentNullException(nameof(exceptionModule));
        }

        public async Task<Macrosegment> Create(Macrosegment item)
        {
            Macrosegment result = null;
            try
            {
                Validator.Validate<Macrosegment>(item);
                result = _unitOfWork.MacrosegmentRepository.Add(item);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await _exceptionModule.Log(ex);
            }
            return result;
        }

        public async Task<Macrosegment> Update(Macrosegment item)
        {
            Macrosegment result = null;
            try
            {
                result = await _unitOfWork.MacrosegmentRepository.GetAsync(x => x.Id == item.Id);
                if (result != null)
                {
                    await _unitOfWork.MacrosegmentRepository.UpdateAsync(result);
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
                Macrosegment item = await _unitOfWork.MacrosegmentRepository.GetAsync(x => x.Id == id);
                if (item != null)
                {
                    _unitOfWork.MacrosegmentRepository.Remove(item);
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

        public async Task<Macrosegment> Get(int id)
        {
            Macrosegment result = new Macrosegment();
            try
            {
                result = await _unitOfWork.MacrosegmentRepository.GetAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                await _exceptionModule.Log(ex);
            }
            return result;
        }

        public async Task<IEnumerable<Macrosegment>> List(Pagination pagination)
        {
            IEnumerable<Macrosegment> result = new List<Macrosegment>();
            try
            {
                result = await _unitOfWork.MacrosegmentRepository.GetListAsync(pagination);
            }
            catch (Exception ex)
            {
                await _exceptionModule.Log(ex);
            }
            return result;
        }

        public async Task<IEnumerable<Macrosegment>> List()
        {
            IEnumerable<Macrosegment> result = new List<Macrosegment>();
            try
            {
                result = await _unitOfWork.MacrosegmentRepository.GetListAsync();
            }
            catch (Exception ex)
            {
                await _exceptionModule.Log(ex);
            }
            return result;
        }

    }
}
