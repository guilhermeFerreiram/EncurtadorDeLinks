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
            try
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }

                if (ModelState.IsValid)
                {
                    link.Encurtar(); // Precisa conferir se shortCode já existe no banco de dados
                    _linkRepositorio.Adicionar(link);
                    TempData["MensagemSucesso"] = "Link encurtado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(link);
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos encurtar o link. Tente novamente. Detalhe do erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Alterar(LinkModel link)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _linkRepositorio.Atualizar(link);
                    TempData["MensagemSucesso"] = "Link alterado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View("Editar", link);
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos alterar o link. Tente novamente. Detalhe do erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _linkRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Link apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não conseguimos apagar seu link";
                }

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar o link. Tente novamente. Detalhe do erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
