using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using vendor.domain.data;

namespace vendor.domain.entities
{ 
    public class Store : UserStore<User, Role, VendorDbContext, long>
    {
        public Store(VendorDbContext context) : base(context) { }
    }
}
