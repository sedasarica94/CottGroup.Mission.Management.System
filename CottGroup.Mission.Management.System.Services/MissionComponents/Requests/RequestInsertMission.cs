namespace CottGroup.Mission.Management.System.Services.MissionComponents.Requests
{
    public class RequestInsertMission:BaseMission
    {
        public int CreatedBy { get; set; }
        public int IsActive { get; set; }
    }
}
