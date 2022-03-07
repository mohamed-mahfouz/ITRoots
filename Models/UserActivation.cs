using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITRoots.Models
{
    public class UserActivation
    {
        public int Id { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }

        public Guid ActivationCode { get; set; }

    }
}