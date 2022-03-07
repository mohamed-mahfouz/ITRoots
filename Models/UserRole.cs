using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITRoots.Models
{
    public class UserRole
    {
        public int Id { get; set; }

        public Guid UserId { get; set; }

        public ICollection<User> Users { get; set; }

        public Guid RoleId { get; set; }

        public ICollection<Role> Roles { get; set; }

    }
}