 using KatmanliMimari.Dal.Users;

namespace KatmanliMimari.UI.Models
{
    public class AspNetRoleModel
    {
        public AspNetRoleModel()
        {
            AspNetRole = new AspNetRole();
        }
        public string Id { get; set; }

        public string  Name { get; set; }

        public AspNetRole AspNetRole { get; set; }

    }
}
