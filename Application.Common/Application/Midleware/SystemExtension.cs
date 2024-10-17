namespace Application.Common.Application.Midleware
{
    public class SystemExtension : ISystem
    {
        public List<string> Permissions { get; set; }
        public UserInfo User { get; set; }
        public void Set(
            UserInfo user,
            List<string> permissions
            )
        {
            User = user;
            this.Permissions = permissions;

        }
    }

    public record UserInfo(string Id);
}
