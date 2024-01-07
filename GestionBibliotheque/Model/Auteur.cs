using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBibliotheque.Model
{
    internal class Auteur
    {
        public int AuteurId { get; set; }

        [Required]
        public string Nom { get; set; }

        [Required]
        public string Prenom { get; set; }

        [Required]
        public DateTime? DateNaissance { get; set; }

        public ICollection<Livre> Livres { get; }

    }
}
