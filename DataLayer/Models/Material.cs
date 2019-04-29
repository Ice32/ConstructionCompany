using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Models
{
    public enum MeasurementUnit
    {
        Kilogram,
        Litre,
    };
    public class Material
    {
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
