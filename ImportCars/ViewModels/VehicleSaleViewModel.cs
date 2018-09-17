using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ImportCars.ViewModels
{
    public class VehicleSaleViewModel
    {
        public int? DealNumber { get; set; }
        public string CustomerName { get; set; }
        public string DealershipName {get; set; }
        public string Vehicle { get; set; }
        [DisplayFormat(DataFormatString = "CAD{0:C0}")]
        public decimal? Price { get; set; }
        public DateTime? Date { get; set; }
    }
}
