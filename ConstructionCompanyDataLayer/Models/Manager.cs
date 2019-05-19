using System;
using System.Collections.Generic;
using System.Text;

namespace ConstructionCompanyDataLayer.Models
{
    public class Manager
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
