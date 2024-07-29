using EncurtadorDeLinks.Data;
using EncurtadorDeLinks.Models;

namespace EncurtadorDeLinks.Repositorio
{
    public class LinkRepositorio : ILinkRepositorio
    {
        private readonly BancoContext _bancoContext;
        public LinkRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public LinkModel Adicionar(LinkModel link)
        {
            _bancoContext.Links.Add(link);
            _bancoContext.SaveChanges();
            return link;
        }

        public List<LinkModel> BuscarTodos()
        {
            return _bancoContext.Links.ToList();
        }
    }
}
