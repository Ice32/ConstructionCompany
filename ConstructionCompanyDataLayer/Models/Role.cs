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
        public int Id { get; set; }
        
        public string Description { get; set; }
        public RoleEnum Name { get; set; }
        
        public List<UserRole> UserRoles { get; set; }
    }
}
