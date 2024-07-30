namespace EncurtadorDeLinks.Models
{
    // Adicionar data de criação e data de modificação

    public class LinkModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string LinkOriginal { get; set; }
        public string LinkEncurtado { get; set; }

        public void Encurtar() // Precisa conferir se shortCode já existe no banco de dados
        {
            string shortCode = GerarShortCode();
            LinkEncurtado = shortCode;
        }

        public string GerarShortCode()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 6);
        }
    }
}
