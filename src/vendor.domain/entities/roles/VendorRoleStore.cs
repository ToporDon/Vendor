using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using vendor.domain.data;

namespace vendor.domain.entities
{
    public class VendorRoleStore : RoleStore<Role, VendorDbContext, long>
    {
        public VendorRoleStore(VendorDbContext context) : base(context) { }
    }
}
