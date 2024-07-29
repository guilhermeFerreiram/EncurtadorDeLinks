using EncurtadorDeLinks.Models;

namespace EncurtadorDeLinks.Repositorio
{
    public interface ILinkRepositorio
    {
        LinkModel Adicionar(LinkModel link);
        List<LinkModel> BuscarTodos();
    }
}
