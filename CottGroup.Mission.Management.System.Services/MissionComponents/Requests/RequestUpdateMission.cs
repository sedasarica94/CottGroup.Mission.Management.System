namespace CottGroup.Mission.Management.System.Services.MissionComponents.Requests
{
    public class RequestUpdateMission : BaseMission
    {
        public int Id { get; set; }
        public int UpdatedBy { get; set; }
        public int IsActive { get; set; }
    }
}
