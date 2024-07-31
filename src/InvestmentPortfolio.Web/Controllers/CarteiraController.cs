using Microsoft.AspNetCore.Mvc;

namespace InvestmentPortfolio.Web.Controllers
{
    public class CarteiraController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
