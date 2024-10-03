using Application.Common.Domain.Dtos;
using Application.Common.Infraestructure.Entities;
using Application.Common.Infraestructure.DataAccess;
using Application.Common.Domain.Interfaces;

namespace Application.Common.Domain.Services
{
    public class Approval_RangeService : IApproval_RangeService
    {
		private readonly IUnitOfWork _unitOfWork;
		private readonly ExceptionModule _exceptionModule;
		public Approval_RangeService(IUnitOfWork unitOfWork,
				ExceptionModule exceptionModule)
		{
			_unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
			_exceptionModule = exceptionModule ?? throw new ArgumentNullException(nameof(exceptionModule));
		}

		public async Task<Approval_Range> Create(Approval_Range item)
		{
			Approval_Range result = null;
			try
			{
				Validator.Validate<Approval_Range>(item);
				result = _unitOfWork.Approval_RangeRepository.Add(item);
				await _unitOfWork.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				await _exceptionModule.Log(ex);
			}
			return result;
		}

		public async Task<Approval_Range> Update(Approval_Range item)
		{
			Approval_Range result = null;
			try
			{
				result = await _unitOfWork.Approval_RangeRepository.GetAsync(x => x.Id == item.Id);
				if (result != null)
				{
					await _unitOfWork.Approval_RangeRepository.UpdateAsync(result);
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
				Approval_Range item = await _unitOfWork.Approval_RangeRepository.GetAsync(x => x.Id == id);
				if (item != null)
				{
					_unitOfWork.Approval_RangeRepository.Remove(item);
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

		public async Task<Approval_Range> Get(int id)
		{
			Approval_Range result = new Approval_Range();
			try
			{
				result = await _unitOfWork.Approval_RangeRepository.GetAsync(x=> x.Id == id);
			}
			catch (Exception ex)
			{
				await _exceptionModule.Log(ex);
			}
			return result;
		}

		public async Task<IEnumerable<Approval_Range>> List(Pagination pagination)
		{
			IEnumerable<Approval_Range> result = new List<Approval_Range>();
			try
			{
				result =  await _unitOfWork.Approval_RangeRepository.GetListAsync(pagination);
			}
			catch (Exception ex)
			{
				await _exceptionModule.Log(ex);
			}
			return result;
		}

		public async Task<IEnumerable<Approval_Range>> List()
		{
			IEnumerable<Approval_Range> result = new List<Approval_Range>();
			try
			{
				result =  await _unitOfWork.Approval_RangeRepository.GetListAsync();
			}
			catch (Exception ex)
			{
				await _exceptionModule.Log(ex);
			}
			return result;
		}

	}
}
