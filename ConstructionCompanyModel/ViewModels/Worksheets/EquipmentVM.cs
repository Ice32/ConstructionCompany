﻿using System;

namespace ConstructionCompanyModel.ViewModels.Worksheets
{
    public class EquipmentVM
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SerialNumber { get; set; }
        public DateTime? PurchaseDate { get; set; }
    }
}
