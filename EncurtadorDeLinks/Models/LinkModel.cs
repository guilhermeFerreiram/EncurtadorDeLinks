using System.ComponentModel.DataAnnotations;

namespace EncurtadorDeLinks.Models
{
    // Adicionar data de criação e data de modificação

    public class LinkModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do link...")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Cole o link original...")]
        public string LinkOriginal { get; set; }
        public string? LinkEncurtado { get; set; } // LinkEncurtado deve ser anulável para ModelState retornar true no Controller Link Action Criar [post]
        public string? ShortCode { get; set; }

        public void Encurtar() // Precisa conferir se shortCode já existe no banco de dados
        {
            string shortCode = GerarShortCode();
            ShortCode = shortCode;
            LinkEncurtado = "https://localhost:7084/u/" + shortCode;
        }

        public string GerarShortCode()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 6);
        }
    }
}
