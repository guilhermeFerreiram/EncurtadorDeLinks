namespace EncurtadorDeLinks.Models
{
    public class LinkModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string LinkOriginal { get; set; }
        public string LinkEncurtado { get; set; }

        public void Encurtar() // Precisa conferir se shortCode já existe no banco de dados
        {
            string shortCode = Guid.NewGuid().ToString("N").Substring(0, 6);
            LinkEncurtado = shortCode;
        }
    }
}
