using System.ComponentModel.DataAnnotations;

namespace LivrariaAnnaMVC.Models
{
    public class AuthorModel
    {


        public int AuthorId { get; set; }
        [Required(ErrorMessage = "Digite o nome do autor")]
        public string? AuthorName { get; set; }
        [Required(ErrorMessage = "Digite o sobrenome do autor")]
        public string? AuthorLastName { get; set; }

        [EmailAddress(ErrorMessage = "O email informado não é valido")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Digite a data de nascimento do autor")]
        public DateTime? Birth { get; set; }


    }
}
