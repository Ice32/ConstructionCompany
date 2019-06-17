using System;

namespace ConstructionCompanyModel.ViewModels.Users
{
    public class UserVM
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string UserName { get; set; }
        
        public DateTime DateOfBirth { get; set; }

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