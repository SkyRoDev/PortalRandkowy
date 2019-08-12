using System.ComponentModel.DataAnnotations;

namespace PortalRandkowy.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required(ErrorMessage="Nazwa użytkownika jest wymagana")]
        public string Username { get; set; }   
        [Required(ErrorMessage="Hasło jest wymagane")]
        [StringLength(16, MinimumLength=6, ErrorMessage="Hasło musi mieć od 6 do 16 znaków")]
        public string Password { get; set; }
    }
}