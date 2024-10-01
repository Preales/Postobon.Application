using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Utility
{
    public interface ISystem
    {
        public List<string> Permissions { get; set; }
        //List<RoleInfo> Roles { get; set; }
        public Guid TenantId { get; set; }
        //UserInfo User { get; set; }

        //void Set(UserInfo user, List<RoleInfo> roles, Guid tenantId, List<string> permissions);
    }
}
