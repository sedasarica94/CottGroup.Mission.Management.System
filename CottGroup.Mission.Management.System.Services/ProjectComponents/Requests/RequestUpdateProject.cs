namespace CottGroup.Mission.Management.System.Services.ProjectComponents.Requests
{
    public class RequestUpdateProject : BaseProject
    {
        public int Id { get; set; }
        public int UpdatedBy { get; set; }
        public int IsActive { get; set; }
    }
}
