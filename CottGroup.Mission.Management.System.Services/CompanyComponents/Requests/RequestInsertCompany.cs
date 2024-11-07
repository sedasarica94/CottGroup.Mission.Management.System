namespace CottGroup.Mission.Management.System.Services.CompanyComponents.Requests
{
    public class RequestInsertCompany : BaseCompanyModel
    {
        public int CreatedBy { get; set; }
        public int IsActive { get; set; }
    }
}
