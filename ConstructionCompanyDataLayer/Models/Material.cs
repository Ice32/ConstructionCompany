using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructionCompanyDataLayer.Models
{
    public enum MeasurementUnit
    {
        Kilogram,
        Litre,
        Meter
    };
    public class Material
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DefaultValue(1)]
        public double Amount { get; set; }

        [DefaultValue(MeasurementUnit.Kilogram)]
        public MeasurementUnit Unit { get; set; }

        public List<WorksheetMaterial> WorksheetMaterials { get; set; }
    }
}
