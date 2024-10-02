//using Application.Common.Domain.Dtos;
//using Application.Common.Infraestructure.DataAccess;
//using Application.Common.Infraestructure.Entities;
//using Application.Common.Utility;

//namespace Application.Common.Domain.Services
//{
//	public class TypologyService
//	{
//		private readonly IUnitOfWork _unitOfWork;
//		private readonly ExceptionModule _exceptionModule;
//		public TypologyModule(IUnitOfWork unitOfWork,
//				ExceptionModule exceptionModule)
//		{
//			_unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
//			_exceptionModule = exceptionModule ?? throw new ArgumentNullException(nameof(exceptionModule));
//		}

//		public async Task<Typology> Create(Typology item)
//		{
//			Typology result = null;
//			try
//			{
//				Validator.Validate<Typology>(item);
//				result = _unitOfWork.TypologyRepository.Add(item);
//				await _unitOfWork.SaveChangesAsync();
//			}
//			catch (Exception ex)
//			{
//				await _exceptionModule.Log(ex);
//			}
//			return result;
//		}

//		public async Task<Typology> Update(Typology item)
//		{
//			Typology result = null;
//			try
//			{
//				result = await _unitOfWork.TypologyRepository.GetAsync(x => x.Id == item.Id);
//				if (result != null)
//				{
//					await _unitOfWork.TypologyRepository.UpdateAsync(result);
//					await _unitOfWork.SaveChangesAsync();
//				}
//				else
//				{
//					throw new ArgumentException("El item que intentas actualizar no existe");
//				}
//			}
//			catch (Exception ex)
//			{
//				await _exceptionModule.Log(ex);
//			}
//			return result;
//		}

//		public async Task<bool> Delete(Guid id)
//		{
//			 bool result = false;
//			try
//			{
//				Typology item = await _unitOfWork.TypologyRepository.GetAsync(x => x.Id == id);
//				if (item != null)
//				{
//					_unitOfWork.TypologyRepository.Remove(item);
//					await _unitOfWork.SaveChangesAsync();
//					result = true;
//				}
//				else
//				{
//					throw new ArgumentException("El item que intentas eliminar no existe");
//				}
//			}
//			catch (Exception ex)
//			{
//				await _exceptionModule.Log(ex);
//			}
//			return result;
//		}

//		public async Task<Typology> Get(Guid id)
//		{
//			Typology result = new Typology();
//			try
//			{
//				result = await _unitOfWork.TypologyRepository.GetAsync(x=> x.Id == id);
//			}
//			catch (Exception ex)
//			{
//				await _exceptionModule.Log(ex);
//			}
//			return result;
//		}

//		public async Task<IEnumerable<Typology>> List(Pagination pagination)
//		{
//			IEnumerable<Typology> result = new List<Typology>();
//			try
//			{
//				result =  await _unitOfWork.TypologyRepository.GetListAsync(pagination);
//			}
//			catch (Exception ex)
//			{
//				await _exceptionModule.Log(ex);
//			}
//			return result;
//		}

//		public async Task<IEnumerable<Typology>> List()
//		{
//			IEnumerable<Typology> result = new List<Typology>();
//			try
//			{
//				result =  await _unitOfWork.TypologyRepository.GetListAsync();
//			}
//			catch (Exception ex)
//			{
//				await _exceptionModule.Log(ex);
//			}
//			return result;
//		}

//	}
//}
