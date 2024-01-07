using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace please2.Models
{
    public class User
    {
        [Required(ErrorMessage = "Le champ CIN est requis.")]
        public string CIN { get; set; }

        [Required(ErrorMessage = "Le champ Last Name est requis.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Le champ First Name est requis.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Le champ Email est requis.")]
        [EmailAddress(ErrorMessage = "Veuillez entrer une adresse email valide.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Le champ Address est requis.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Le champ Telephone est requis.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Le champ Password est requis.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Les mots de passe ne correspondent pas.")]
        public string ConfirmPassword { get; set; }

        // Informations liées à l'authentification externe
        public string ExternalLoginProvider { get; set; }
        public string ExternalLoginDisplayName { get; set; }

        // Autres propriétés si nécessaire

        public string ReturnUrl { get; set; }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

    }
}
