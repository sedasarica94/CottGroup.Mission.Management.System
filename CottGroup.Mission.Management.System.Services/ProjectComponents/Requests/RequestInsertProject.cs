namespace CottGroup.Mission.Management.System.Services.ProjectComponents.Requests
{
    public class RequestInsertProject:BaseProject
    {
        public int CreatedBy { get; set; }
        public int IsActive { get; set; }
    }
}
