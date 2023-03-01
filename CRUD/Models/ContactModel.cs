using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do contato")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Digite o e-mail do contato")]
        [EmailAddress(ErrorMessage = "Digite um email valido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o celular do contato")]
        [Phone(ErrorMessage = "Digite um número de celular valido")]
        public string Cell { get; set; }
    }
}
