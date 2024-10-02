using Application.Common.Application.Midleware;

namespace Application.Common.Utility
{
    public interface ISystem
    {
        public List<string> Permissions { get; set; }
        //List<RoleInfo> Roles { get; set; }
        UserInfo User { get; set; }

        void Set(
            UserInfo user,
            //List<RoleInfo> roles, 
            List<string> permissions);
    }
}
