using CottGroup.Mission.Management.System.Infrastructure.Enums;

namespace CottGroup.Mission.Management.System.Services.MissionComponents
{
    public class BaseMission
    {
        public string Name { get; set; }

        public string Details { get; set; }

        public int EstimatedHoursCost { get; set; }

        public int EffortHoursCost { get; set; }

        public int Priority { get; set; }

        public MissionStatusType Status { get; set; }

        public string Comment { get; set; }

        public int ProjectId { get; set; }

        public int UserId { get; set; } 

    }
}
