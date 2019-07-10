namespace ConstructionCompanyModel.ViewModels.Worksheets
{
    public enum MeasurementUnit
    {
        Kilogram,
        Litre,
        Meter,
    };
    public class MaterialVM
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        
        public string Name { get; set; }

        public MeasurementUnit Unit { get; set; }
    }
}
