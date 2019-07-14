﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructionCompanyDataLayer.Models
{
    public class Role
    {
        public enum RoleEnum
        {
            Manager,
            ConstructionSiteManager,
            Worker
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string Description { get; set; }
        public RoleEnum Name { get; set; }
        
        public List<UserRole> UserRoles { get; set; }
    }
}
