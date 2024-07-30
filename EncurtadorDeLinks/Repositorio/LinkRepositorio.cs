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

        public bool Apagar(int id)
        {
            var linkDb = ListarPorId(id);

            if (linkDb == null) throw new Exception("Id de link não encontrado");

            _bancoContext.Links.Remove(linkDb);
            _bancoContext.SaveChanges();
            return true;
        }

        public LinkModel Atualizar(LinkModel link)
        {
            var linkDb = ListarPorId(link.Id);

            if (linkDb == null) throw new Exception("Id de link não encontrado");

            linkDb.Nome = link.Nome;
            linkDb.LinkOriginal = link.LinkOriginal;

            _bancoContext.Links.Update(linkDb);
            _bancoContext.SaveChanges();

            return linkDb;
        }

        public List<LinkModel> BuscarTodos()
        {
            return _bancoContext.Links.ToList();
        }

        public LinkModel ListarPorId(int id)
        {
            return _bancoContext.Links.FirstOrDefault(x => x.Id == id);
        }
    }
}
