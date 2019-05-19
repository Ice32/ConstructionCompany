using System;
using System.Collections.Generic;
using System.Text;

namespace ConstructionCompanyDataLayer.Models
{
    public class Role
    {
        public enum RoleEnum
        {
            Manager,
            ConstructionSiteManager,
            DefaultUser
        }
        public string Description { get; set; }
        public RoleEnum UserRole { get; set; }
    }
}
