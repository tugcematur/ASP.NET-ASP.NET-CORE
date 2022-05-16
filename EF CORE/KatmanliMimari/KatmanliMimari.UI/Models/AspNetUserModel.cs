using KatmanliMimari.Dal.Users;
using KatmanliMimari.DTO;

namespace KatmanliMimari.UI.Models
{
    public class AspNetUserModel
    {
        public AspNetUserModel()
        {
            AspNetUser = new AspNetUser();
        }
        public string Id { get; set; }
        public string  RoleId { get; set; }
        public IQueryable<RoleSelect> RoleList { get; set; }
        public AspNetUser AspNetUser { get; set; }
    }
}
