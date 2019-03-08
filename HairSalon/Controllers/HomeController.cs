using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace HairSalon.Controllers
{
  public class HomeController : Controller
  {

    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }

  }
}
