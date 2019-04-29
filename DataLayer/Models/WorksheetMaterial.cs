using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public class WorksheetMaterial
    {
        public double Amount { get; set; }

        public int WorksheetId { get; set; }
        public Worksheet Worksheet { get; set; }

        public int MaterialId { get; set; }
        public Material Material { get; set; }
    }
}
