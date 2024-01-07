using GestionBibliotheque.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBibliotheque.Model
{
    internal class Categorie
    {
        public int CategorieId { get; set; }

        [Required]
        public string Nom { get; set; }

        public ICollection<Livre> Livres { get; }
    }
}
