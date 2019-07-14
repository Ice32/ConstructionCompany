﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructionCompanyDataLayer.Models
{
    public class Worker: IUserType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string JobDescription { get; set; }
        public string TelephoneNumber { get; set; }
        public List<WorkerTask> WorkerTasks { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
