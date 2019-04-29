using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
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
