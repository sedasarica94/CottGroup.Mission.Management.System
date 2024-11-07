namespace CottGroup.Mission.Management.System.Services.UserComponents.Requests
{
    public class RequestUpdateUser : BaseUser
    {
        public int Id { get; set; }
        public int UpdatedBy { get; set; } 
        public string Password { get; set; }
        public int IsActive { get; set; }
    }
}
