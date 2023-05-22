using ConsumeWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ConsumeWebApi.Controllers
{
    public class UserController : Controller
    {
        private string baseURL = "http://localhost:8082/";
       
        public  async Task<IActionResult> Login(UserEntity user)
        {
            UserEntity obj = new UserEntity
            {
               user_Name = user.user_Name,
               user_Password = user.user_Password
            };

            if (obj.user_Name!=null && obj.user_Password != null)
            {
                using(var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseURL + "api/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    var response = await client.GetAsync($"User?user_name={obj.user_Name}&user_Password={obj.user_Password}");
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else if(response.StatusCode == HttpStatusCode.NotFound)
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login Crediential");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "An error occured");
                    }

                }

            }
            
            return View();
            
        }
    }
}
