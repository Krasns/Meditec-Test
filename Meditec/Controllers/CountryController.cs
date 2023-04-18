using Meditec.Data;
using Meditec.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace Meditec.Controllers
{
    public class CountryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CountryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Country()
        {
            CountryModel countries = await GetAllCountrys();
            if (countries != null)
            {
                return View("Country", countries);
            }
            return View("Country");

        }

        public async Task<IActionResult> Holidays(string iso2)
        {
            List<PublicHolidayModel> holidays = await GetCountrysPublicHolidays(iso2);

            return PartialView("PublicHoliday", holidays);
        }

        [HttpGet]
        public async Task<CountryModel> GetAllCountrys()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://countriesnow.space/api/v0.1/countries");
                response.EnsureSuccessStatusCode();
                string? json = await response.Content.ReadAsStringAsync();
                CountryModel? countryes = JsonConvert.DeserializeObject<CountryModel>(json);
                return countryes;
            }
        }

        [HttpGet]
        public async Task<List<PublicHolidayModel>> GetCountrysPublicHolidays(string iso2)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://date.nager.at/api/v3/publicholidays/2023/" + iso2);
                response.EnsureSuccessStatusCode();
                string? json = await response.Content.ReadAsStringAsync();
                List<PublicHolidayModel>? holidays = JsonConvert.DeserializeObject<List<PublicHolidayModel>>(json);
                return holidays;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostPublicHolidays (PublicHolidayDbModel obj)
        {
            if (ModelState.IsValid)
            {
                _db.PublicHoliday.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

    }
}
