using System.ComponentModel.DataAnnotations;

namespace SisProdutos.Date.DtosUsuario
{
    public class CreateUsuarioDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Required]
        [Compare("Password")]
        public string RePassword { get; set; }
    }
}
