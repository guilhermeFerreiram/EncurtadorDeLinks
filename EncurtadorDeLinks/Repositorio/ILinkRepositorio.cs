using EncurtadorDeLinks.Models;

namespace EncurtadorDeLinks.Repositorio
{
    public interface ILinkRepositorio
    {
        LinkModel Adicionar(LinkModel link);
        List<LinkModel> BuscarTodos();
        LinkModel ListarPorId(int id);
        LinkModel Atualizar(LinkModel link);
        bool Apagar(int id);
    }
}
