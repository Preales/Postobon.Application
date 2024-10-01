using Application.Common.Infraestructure.DataAccess;
using Application.Common.Infraestructure.Entities;
using Application.Common.Utility.ExceptionResources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Application.Common.Utility
{
    public class ExceptionModule
    {
        //private readonly IServiceProvider _serviceProvider;
        private readonly IUnitOfWork _unitOfWork;

        private readonly ISystem _system;

        public ExceptionModule(IUnitOfWork unitOfWork, ISystem system)
        {
            //_serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _system = system ?? throw new ArgumentNullException(nameof(system));
        }

        public static string GetMessage(System.Exception ex)
        {
            var messages = new List<string>();

            do
            {
                messages.Add(string.Format("Message: {0} - Data: {1} - StackTrace: {2}", ex.Message, ex.Data, ex.StackTrace));
                ex = ex.InnerException;
            }
            while (ex != null);

            var message = string.Join(" - ", messages);

            return message;
        }

        public async Task Log(string message, bool throwError = true)
        {
            await Log(new System.Exception(message), throwError);
        }

        public async Task Log(System.Exception ex, bool throwError = true)
        {
            
            string message = string.Empty;
            if (ex.GetType() == typeof(ArgumentException))
                message = ex.Message;
            else if (ex.GetType() == typeof(ExceptionValidation))
                message = ex.Data["ValidationError"].ToString();
            else if (ex.GetType() == typeof(AuthorizationException))
                message = ex.Message;
            else
                message = ex.Message;

            var info = Reflexion.GetCurrentMethod();
            var logEx = new LogExceptionInfo()
            {
                //Class = info.Item2 ?? ex.TargetSite.Name ?? "NONE",
                //Source = ex.Source ?? "NONE",
                //CreatedBy = Guid.Empty, //CONSTANT_USER.AdministratorUser,
                //CreatedOn = DateExt.getDate(),
                //Message = message,
                //Method = info.Item1 ?? ex.TargetSite.Name ?? "NONE",
                //Stack = ex.StackTrace ?? "NONE",
                //Type = ex.GetType().FullName.Truncate(50) ?? "NONE",
                //TenantId = (_system != null && _system.TenantId != Guid.Empty) ? _system.TenantId : CONSTANT_TENANT.Default,
                //Description = GetMessage(ex)
            };
            logEx.Class = logEx.Class.Truncate(50);
            logEx.Source = logEx.Source.Truncate(2000);
            logEx.Message = logEx.Message.Truncate(2000);

            //Escribir la logica
            await _unitOfWork.Log.AddAsync(logEx);
            await _unitOfWork.SaveChangesAsync();
            if (throwError)
            {
                throw new AppException(message);
            }
        }
    }
}
