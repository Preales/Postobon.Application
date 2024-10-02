using Application.Common.Utility;

namespace Application.Common.Application.Midleware
{
    public class SystemExtension : ISystem
    {
        public List<string> Permissions { get; set; }
        //public List<RoleInfo> Roles { get; set; }
        public UserInfo User { get; set; }
        //public string Cognito_IdToken { get; set; }
        //public string Cognito_AccessToken { get; set; }
        public void Set(
            UserInfo user,
            //List<RoleInfo> roles,              
            List<string> permissions
            //, string cognito_idToken = null
            //, string cognito_accessToken = null
            )
        {
            User = user;
            //this.Roles = roles;
            this.Permissions = permissions;

        }
    }

    public record UserInfo(string Id);
}
