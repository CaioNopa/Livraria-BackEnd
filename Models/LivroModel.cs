namespace Livro.Models
{
    public class LivroModel
    {
        public int Id{ get; set; }
        public string? Editora { get; set; }
        public string? Titulo { get; set; }
        public DateTime Ano { get; set; }
        public string? Autor { get; set; }
        public int QtdEstoque { get; set; }


    }   

}