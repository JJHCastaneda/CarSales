using System.Collections.Generic;

namespace ImportCars.ViewModels
{
    public class DisplayVehicleSalesViewModel
    {
        public string VehicleMostSold { get; set; } = string.Empty;
        public IEnumerable<VehicleSaleViewModel> Vehicles { get; set; }
    }
}
