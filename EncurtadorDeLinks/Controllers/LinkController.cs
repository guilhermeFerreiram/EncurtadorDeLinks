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

        public IActionResult Editar(int id)
        {
            var link = _linkRepositorio.ListarPorId(id);
            return View(link);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            var link = _linkRepositorio.ListarPorId(id);
            return View(link);
        }

        [HttpPost]
        public IActionResult Criar(LinkModel link)
        {
            link.Encurtar(); // Precisa conferir se shortCode já existe no banco de dados
            _linkRepositorio.Adicionar(link);
            return RedirectToAction("Index");
        }

        public IActionResult Alterar(LinkModel link)
        {
            _linkRepositorio.Atualizar(link);
            return RedirectToAction("Index");
        }

        public IActionResult Apagar(int id)
        {
            _linkRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }
    }
}
