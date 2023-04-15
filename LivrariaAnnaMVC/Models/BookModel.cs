using System.ComponentModel.DataAnnotations;

namespace LivrariaAnnaMVC.Models
{
    public class BookModel
    {
        public int BookId { get; set; }

        [Required(ErrorMessage ="Digite o nome do livro")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Digite o ISBN do livro")]
        public string? Isbn { get; set; }
        [Required(ErrorMessage = "Digite a data de publicação do livro")]
        public DateTime? Year { get; set; }

        [Required(ErrorMessage = "O livro precisa estar vinculado a uma chave de autor")]
        public int? AuthorId { get; set; }
        public virtual AuthorModel? Author { get; set; }

    }
}
