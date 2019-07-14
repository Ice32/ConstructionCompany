using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructionCompanyDataLayer.Models
{
    public class Task
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        public List<WorkerTask> WorkerTasks { get; set; }

        public int WorksheetId { get; set; }
        public Worksheet Worksheet { get; set; }
    }
}
