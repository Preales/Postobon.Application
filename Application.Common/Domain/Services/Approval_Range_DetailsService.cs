using Application.Common.Domain.Dtos;
using Application.Common.Infraestructure.Entities;
using Application.Common.Infraestructure.DataAccess;
using Application.Common.Domain.Interfaces;

namespace Application.Common.Domain.Services
{
    public class Approval_Range_DetailsService: IApproval_Range_DetailsService
    {
		private readonly IUnitOfWork _unitOfWork;
		private readonly ExceptionModule _exceptionModule;
		public Approval_Range_DetailsService(IUnitOfWork unitOfWork,
				ExceptionModule exceptionModule)
		{
			_unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
			_exceptionModule = exceptionModule ?? throw new ArgumentNullException(nameof(exceptionModule));
		}

		public async Task<Approval_Range_Details> Create(Approval_Range_Details item)
		{
			Approval_Range_Details result = null;
			try
			{
				Validator.Validate<Approval_Range_Details>(item);
				result = _unitOfWork.Approval_Range_DetailsRepository.Add(item);
				await _unitOfWork.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				await _exceptionModule.Log(ex);
			}
			return result;
		}

		public async Task<Approval_Range_Details> Update(Approval_Range_Details item)
		{
			Approval_Range_Details result = null;
			try
			{
				result = await _unitOfWork.Approval_Range_DetailsRepository.GetAsync(x => x.Id == item.Id);
				if (result != null)
				{
					await _unitOfWork.Approval_Range_DetailsRepository.UpdateAsync(result);
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
				Approval_Range_Details item = await _unitOfWork.Approval_Range_DetailsRepository.GetAsync(x => x.Id == id);
				if (item != null)
				{
					_unitOfWork.Approval_Range_DetailsRepository.Remove(item);
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

		public async Task<Approval_Range_Details> Get(int id)
		{
			Approval_Range_Details result = new Approval_Range_Details();
			try
			{
				result = await _unitOfWork.Approval_Range_DetailsRepository.GetAsync(x=> x.Id == id);
			}
			catch (Exception ex)
			{
				await _exceptionModule.Log(ex);
			}
			return result;
		}

		public async Task<IEnumerable<Approval_Range_Details>> List(Pagination pagination)
		{
			IEnumerable<Approval_Range_Details> result = new List<Approval_Range_Details>();
			try
			{
				result =  await _unitOfWork.Approval_Range_DetailsRepository.GetListAsync(pagination);
			}
			catch (Exception ex)
			{
				await _exceptionModule.Log(ex);
			}
			return result;
		}

		public async Task<IEnumerable<Approval_Range_Details>> List()
		{
			IEnumerable<Approval_Range_Details> result = new List<Approval_Range_Details>();
			try
			{
				result =  await _unitOfWork.Approval_Range_DetailsRepository.GetListAsync();
			}
			catch (Exception ex)
			{
				await _exceptionModule.Log(ex);
			}
			return result;
		}

	}
}
