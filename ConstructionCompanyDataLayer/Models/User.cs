using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructionCompanyDataLayer.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual string UserName { get; set; }
        public virtual string PasswordHash { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsDeleted { get; set; }
        public bool NeedToChangePassword { get; set; }
        [NotMapped]
        public string FullName
        {
            get
            {
                if (!string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName))
                {
                    return FirstName + " " + LastName;
                }

                return FirstName ?? LastName ?? string.Empty;
            }
        }
    }
}
