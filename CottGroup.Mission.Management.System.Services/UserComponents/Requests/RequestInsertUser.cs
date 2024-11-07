namespace CottGroup.Mission.Management.System.Services.UserComponents.Requests
{
    public class RequestInsertUser:BaseUser
    {

        public string Password { get; set; }
        public int CreatedBy { get; set; }
        public int IsActive { get; set; }
    }
}
