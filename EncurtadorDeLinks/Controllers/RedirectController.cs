using EncurtadorDeLinks.Data;
using EncurtadorDeLinks.Models;
using EncurtadorDeLinks.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Serialization;

namespace EncurtadorDeLinks.Controllers
{
    public class RedirectController : Controller
    {
        private readonly ILinkRepositorio _linkRepositorio;

        public RedirectController(ILinkRepositorio linkRepositorio)
        {
            _linkRepositorio = linkRepositorio;
        }

        [HttpGet("u/{shortCode}")]
        public IActionResult Index(string shortCode)
        {
            LinkModel link = _linkRepositorio.BuscarLinkPorShortCode(shortCode);

            if (link == null) return NotFound("URL não encontrada.");

            return Redirect(link.LinkOriginal);
        }
    }
}
