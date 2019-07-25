

namespace ConstructionCompanyDataLayer.Models
{
    public class WorksheetEquipment
    {
        public int WorksheetId { get; set; }
        public Worksheet Worksheet { get; set; }

        public int EquipmentId { get; set; }
        public Equipment Equipment { get; set; }

        public int Quantity { get; set; }
    }
}
