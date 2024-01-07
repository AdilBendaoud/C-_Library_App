using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBibliotheque.Model
{
    internal class User
    {
        [Key]
        public string CIN { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Adresse { get; set; }
        public int? Tel { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsSuperAdmin { get; set; }
    }
}
