using Microsoft.AspNetCore.Mvc;

namespace EncurtadorDeLinks.Controllers
{
    public class LinkController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Encurtar()
        {
            return View();
        }

        public IActionResult Editar()
        {
            return View();
        }

        public IActionResult ApagarConfirmacao()
        {
            return View();
        }
    }
}
