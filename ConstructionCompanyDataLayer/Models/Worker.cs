using System.Collections.Generic;

namespace ConstructionCompanyDataLayer.Models
{
    public class Worker: IUserType
    {
        public int Id { get; set; }
        public string JobDescription { get; set; }
        public string TelephoneNumber { get; set; }
        public List<WorkerTask> WorkerTasks { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
