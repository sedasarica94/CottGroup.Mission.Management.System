namespace CottGroup.Mission.Management.System.Services.CompanyComponents.Requests
{
    public class RequestUpdateCompany : BaseCompanyModel
    {
        public int Id { get; set; }
        public int UpdatedBy { get; set; }
        public int IsActive { get; set; }
    }
}
