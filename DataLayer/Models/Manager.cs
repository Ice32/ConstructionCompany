using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public class Manager
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
