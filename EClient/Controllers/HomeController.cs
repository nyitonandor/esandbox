using EClient.Helpers;
using EClient.Models;
using EClient.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace EClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMotorcycleService _motorcycleService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IMotorcycleService motorcycleService, ILogger<HomeController> logger)
        {
            _motorcycleService = motorcycleService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _motorcycleService.GetAllAsync();
            return View(result);
        }

        public async Task<IActionResult> AddMotorcycle()
        {
            var id = Guid.NewGuid();
            var name = Utils.GetMotorcycleName();
            var serialnumber = Utils.CreateSerialNumber(name, id.ToString());

            var model = new Motorcycle()
            {
                Id = id,
                Name = name,
                Serialnumber = serialnumber
            };

            await _motorcycleService.CreateAsync(model);

            var result = await _motorcycleService.GetAllAsync();
            return View(nameof(Index), result);
        }

        public async Task<IActionResult> DeleteMotorcycle(Guid id)
        {
            await _motorcycleService.DeleteAsync(id);

            var result = await _motorcycleService.GetAllAsync();
            return View(nameof(Index), result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
