using EncurtadorDeLinks.Models;
using EncurtadorDeLinks.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace EncurtadorDeLinks.Controllers
{
    public class LinkController : Controller
    {
        private readonly ILinkRepositorio _linkRepositorio;

        public LinkController(ILinkRepositorio linkRepositorio)
        {
            _linkRepositorio = linkRepositorio;
        }

        public IActionResult Index()
        {
            var links = _linkRepositorio.BuscarTodos();
            return View(links);
        }

        public IActionResult Criar()
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

        [HttpPost]
        public IActionResult Criar(LinkModel link)
        {
            link.Encurtar(); // Precisa conferir se shortCode já existe no banco de dados
            _linkRepositorio.Adicionar(link);
            return RedirectToAction("Index");
        }
    }
}
