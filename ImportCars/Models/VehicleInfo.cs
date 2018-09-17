using System;

namespace ImportCars.Models
{
    /// <summary>
    /// Object used in Business Logic
    /// </summary>
    public class VehicleInfo
    {
        public int? DealNumber { get; set; }
        public string CustomerName { get; set; }
        public string DealershipName { get; set; }
        public string Vehicle { get; set; }
        public decimal? Price { get; set; }
        public DateTime? Date { get; set; }
    }
}
