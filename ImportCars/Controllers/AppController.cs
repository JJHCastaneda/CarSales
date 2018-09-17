using ImportCars.BusinessLogic;
using ImportCars.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ImportCars.Controllers
{
    /// <summary>
    /// Main Controller used to import and display the csv file
    /// </summary>
    public class AppController : Controller
    {
        private IImportVehicleInfo _import;

        public AppController(IImportVehicleInfo import)
        {
            _import = import;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormFile postedFile)
        {
            // TODO: Add validation to make sure that postedFile is csv file
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                DisplayVehicleSalesViewModel vm = new DisplayVehicleSalesViewModel();
                
                //NOTE:we could also use Automapper or similar
                var vehicles = _import
                    .Read(postedFile)
                    .Select(v => new VehicleSaleViewModel() {
                        CustomerName = v.CustomerName,
                        Date = v.Date,
                        DealershipName = v.DealershipName,
                        DealNumber = v.DealNumber,
                        Vehicle = v.Vehicle,
                        Price = v.Price
                    });

                vm.Vehicles = vehicles;
                vm.VehicleMostSold = vehicles.GroupBy(v => v.Vehicle).OrderByDescending(v => v.Count()).FirstOrDefault().Key;
                return View(vm);
            }
        }
    }
}