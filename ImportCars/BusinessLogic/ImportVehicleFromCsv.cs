using ImportCars.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ImportCars.BusinessLogic
{
    public class ImportVehicleFromCsv : IImportVehicleInfo
    {
        private Regex _CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");

        private const int DealNumberColumn = 0;
        private const int CustomerNameColumn = 1;
        private const int DealershipNameColumn = 2;
        private const int VehicleColumn = 3;
        private const int PriceColumn = 4;
        private const int DateColumn = 5;

        public IEnumerable<VehicleInfo> Read(IFormFile file)
        {
            IEnumerable<VehicleInfo> vehicles;

            using (StreamReader reader = new StreamReader(file.OpenReadStream(), Encoding.UTF7))
            {
                var result = reader.ReadToEnd();

                vehicles = result.Split('\n')
                          .Skip(1)
                          .Where(v => !string.IsNullOrWhiteSpace(v))
                          .Select(v => CreateVehicleSale(v.ToString()))
                          .ToList();
            }
            return vehicles;
        }

        private VehicleInfo CreateVehicleSale(string csvLine)
        {
            var values = _CSVParser.Split(csvLine);
            for (int i = 0; i < values.Length; i++)
            {
                // Remove quotes("")
                values[i] = values[i].Replace("\"", string.Empty);
            }

            var vehicleSale = new VehicleInfo();
            if (!string.IsNullOrEmpty(values[DealNumberColumn]))
            {
                vehicleSale.DealNumber = Convert.ToInt32(values[DealNumberColumn]);
            }
            if (!string.IsNullOrEmpty(values[CustomerNameColumn]))
            {
                vehicleSale.CustomerName = Convert.ToString(values[CustomerNameColumn]);
            }
            if (!string.IsNullOrEmpty(values[DealershipNameColumn]))
            {
                vehicleSale.DealershipName = Convert.ToString(values[DealershipNameColumn]);
            }
            if (!string.IsNullOrEmpty(values[VehicleColumn]))
            {
                vehicleSale.Vehicle = Convert.ToString(values[VehicleColumn]);
            }
            if (!string.IsNullOrEmpty(values[PriceColumn]))
            {
                vehicleSale.Price = Convert.ToDecimal(values[PriceColumn]);
            }
            if (!string.IsNullOrEmpty(values[DateColumn]))
            {
                vehicleSale.Date = Convert.ToDateTime(values[DateColumn]);
            }

            return vehicleSale;
        }
    }
}
