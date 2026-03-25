using Microsoft.AspNetCore.Mvc;
using MvcCoreApiClient.Models;
using MvcCoreApiClient.Services;

namespace MvcCoreApiClient.Controllers
{
    public class HospitalesController : Controller
    {
        private ServiceHospitales service;

        public HospitalesController(ServiceHospitales service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cliente()
        {
            return View();
        }

        public async Task<IActionResult> Servidor()
        {
            List<Hospital> hospitales = await service.GetHospitalesAsync();
            return View(hospitales);
        }

        public async Task<IActionResult> Details(int id)
        {
            Hospital hospital = await service.FindHospitalAsync(id);
            return View(hospital);
        }
    }
}
