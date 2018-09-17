using ImportCars.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace ImportCars.BusinessLogic
{
    public interface IImportVehicleInfo
    {
        IEnumerable<VehicleInfo> Read(IFormFile file);
    }
}
