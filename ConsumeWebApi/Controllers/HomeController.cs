using ConsumeWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace ConsumeWebApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private string baseURL = "http://localhost:8082/";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            //calling the web api and populating the data in view using DataTable
            DataTable dt = new DataTable();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage getData = await client.GetAsync("api/Person");
                if (getData.IsSuccessStatusCode)
                {
                    string results = getData.Content.ReadAsStringAsync().Result;
                    dt = JsonConvert.DeserializeObject<DataTable>(results);
                }
                else
                {
                    Console.Out.WriteLineAsync("Error calling web api");
                }

                ViewData.Model = dt;

            }
            return View();
        }

        public async Task<IActionResult> Index2()
        {
            //calling the web api and populating the data in view using Entity model class

            IList<PersonEntity> persons = new List<PersonEntity>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage getData = await client.GetAsync("api/Person");
                if (getData.IsSuccessStatusCode)
                {
                    string results = getData.Content.ReadAsStringAsync().Result;
                    persons = JsonConvert.DeserializeObject<List<PersonEntity>>(results);
                }
                else
                {
                    Console.Out.WriteLineAsync("Error calling web api");
                }

                ViewData.Model = persons;

            }
            return View();
        }

        public async Task<IActionResult> AddPerson(AddPersonEntity p)
        {
            AddPersonEntity obj = new AddPersonEntity()
            {
                person_Name = p.person_Name,
                person_Email = p.person_Email,
                person_Address = p.person_Address,
                person_Phone = p.person_Phone,
            };
            

            if(p.person_Name!=null)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseURL + "api/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage postData = await client.PostAsJsonAsync<AddPersonEntity>("Person", obj);
                    Console.Out.WriteLine(postData);

                    if (postData.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        Console.WriteLine("Error calling web api");
                    }
                }
            }
            return View();
        }


       public async Task<IActionResult> DeletePerson(Guid id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL + "api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var person = await client.DeleteAsync($"Person/{id}");
                if(person.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    return NotFound();
                }

            }
        }

        public async Task<IActionResult> EditPerson(Guid id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL + "api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync($"Person/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var person = JsonConvert.DeserializeObject<PersonEntity>(content);
                    return View("Update",person);

                }
                else
                {
                    return NotFound();
                }
            }

        }
        public async Task<IActionResult> UpdatePerson(PersonEntity person)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL + "api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.PutAsJsonAsync($"Person/{person.person_Id}",person);
                if(response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    return NotFound();
                }
            }

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}