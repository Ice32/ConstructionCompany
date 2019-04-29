using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Models
{
    public class Equipment
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime? PurchaseDate { get; set; }

        public string SerialNumber { get; set; }

        [Required]
        [DefaultValue(1)]
        public int Quantity { get; set; }

        [Column(TypeName = "text")]
        [MinLength(4)]
        public string Description { get; set; }

        public List<WorksheetEquipment> WorksheetEquipment { get; set; }
    }
}
