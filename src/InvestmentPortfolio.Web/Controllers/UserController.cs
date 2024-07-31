using InvestmentPortfolio.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace InvestmentPortfolio.Web.Controllers
{
    public class UserController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44334/api");
        HttpClient client;

        public UserController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        public IActionResult Index()
        {
            List<UserViewModel> users = new List<UserViewModel>();

            HttpResponseMessage responseMessage = client.GetAsync("").Result;

            if(responseMessage.IsSuccessStatusCode)
            {
                string data = responseMessage.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject<List<UserViewModel>>(data);
            }

            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserViewModel user)
        {
            string data = JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = client.PostAsync(client.BaseAddress + "/user", content).Result;

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Login");
            }

            return View();
        }


    }
}
