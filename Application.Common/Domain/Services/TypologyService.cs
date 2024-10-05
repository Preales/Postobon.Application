using Application.Common.Domain.Dtos;
using Application.Common.Domain.Interfaces;
using Application.Common.Infraestructure.DataAccess;
using Application.Common.Infraestructure.Entities;

namespace Application.Common.Domain.Services
{
    public class TypologyService : ITypologyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ExceptionModule _exceptionModule;
        public TypologyService(IUnitOfWork unitOfWork,
                ExceptionModule exceptionModule)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _exceptionModule = exceptionModule ?? throw new ArgumentNullException(nameof(exceptionModule));
        }

        public async Task<Typology> Create(Typology item)
        {
            Typology result = null;
            try
            {
                Validator.Validate<Typology>(item);
                result = _unitOfWork.TypologyRepository.Add(item);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await _exceptionModule.Log(ex);
            }
            return result;
        }

        public async Task<Typology> Update(Typology item)
        {
            Typology result = null;
            try
            {
                result = await _unitOfWork.TypologyRepository.GetAsync(x => x.Code == item.Code);
                if (result != null)
                {
                    /// Aqui deben de agregar la logica de los campos que cambiaron o en su defecto el automapper 
                    await _unitOfWork.TypologyRepository.UpdateAsync(result);
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

        public async Task<bool> Delete(string code)
        {
            bool result = false;
            try
            {
                Typology item = await _unitOfWork.TypologyRepository.GetAsync(x => x.Code == code);
                if (item != null)
                {
                    _unitOfWork.TypologyRepository.Remove(item);
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

        public async Task<bool> DeleteLogic(string code)
        {
            bool result = false;
            try
            {
                Typology item = await _unitOfWork.TypologyRepository.GetAsync(x => x.Code == code);
                if (item != null)
                {
                    item.Deleted = true;
                    await _unitOfWork.TypologyRepository.UpdateAsync(item);
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

        public async Task<Typology> Get(string code)
        {
            Typology result = new Typology();
            try
            {
                result = await _unitOfWork.TypologyRepository.GetAsync(x => x.Code == code);
            }
            catch (Exception ex)
            {
                await _exceptionModule.Log(ex);
            }
            return result;
        }

        public async Task<IEnumerable<Typology>> List(Pagination pagination)
        {
            IEnumerable<Typology> result = new List<Typology>();
            try
            {
                result = await _unitOfWork.TypologyRepository.GetListAsync(pagination);
            }
            catch (Exception ex)
            {
                await _exceptionModule.Log(ex);
            }
            return result;
        }

        public async Task<IEnumerable<Typology>> List()
        {
            IEnumerable<Typology> result = new List<Typology>();
            try
            {
                result = await _unitOfWork.TypologyRepository.GetListAsync();
            }
            catch (Exception ex)
            {
                await _exceptionModule.Log(ex);
            }
            return result;
        }

    }
}
