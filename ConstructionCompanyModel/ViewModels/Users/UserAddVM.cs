using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConstructionCompanyModel.ViewModels.Users
{
    public class UserAddVM
    {
        public int? Id { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string UserName { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        [MinLength(3)]
        public string Password { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public List<int> RoleIds { get; set; } = new List<int>();

        public bool Active { get; set; }
    }
}
