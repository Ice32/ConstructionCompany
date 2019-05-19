using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConstructionCompanyDataLayer.Models
{
    public class Worker
    {
        public int Id { get; set; }
        public string JobDescription { get; set; }
        public string TelephoneNumber { get; set; }
        public List<WorkerTask> WorkerTasks { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
