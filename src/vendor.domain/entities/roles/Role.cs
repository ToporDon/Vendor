using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace vendor.domain.entities
{
    public class Role : IdentityRole<long>
    {
        public Role()
        {
        }

        public Role(string name)
        {
            this.Name = name;
        }
        
        public DateTime UpdDate { get; set; }
    }
}
