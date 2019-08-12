using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructionCompanyDataLayer.Models
{
    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        public List<WorkerTask> WorkerTasks { get; set; }

        public int WorksheetId { get; set; }
        public Worksheet Worksheet { get; set; }

        public int Rating { get; set; }
        
        public override bool Equals(object obj)
        {
            var item = obj as Task;

            if (item == null)
            {
                return false;
            }

            return Id.Equals(item.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
