using System;
using ConstructionCompanyModel.ViewModels.Worksheets;

namespace ConstructionCompanyMobile.Util
{
    public static class ViewModelsExtensions
    {
        private static string Symbol(this MeasurementUnit unit)
        {
            switch(unit)
            {
                case MeasurementUnit.Kilogram:
                    return "kg";
                case MeasurementUnit.Litre:
                    return "l";
                case MeasurementUnit.Meter:
                    return "m";
                default:
                    throw new Exception($"Unknown unit {unit}, cannot return a symbol");
            }
        }
        public static string PrettyPrint(this MaterialVM material)
        {
            return $"{material.Name} {material.Amount}{material.Unit.Symbol()}";
        }

        public static string PrettyPrint(this EquipmentVM equipment)
        {

            return $"{equipment.Name} x {equipment.Quantity}";
        }
    }
}
