using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GestionBibliotheque.Model
{
    class Livre
    {
        public int LivreId { get; set; }
        
        [Required]
        public string Titre { get; set; }
        
        public double Prix { get; set; }
        
        public DateTime? DateDistrubution { get; set; }
        
        public string? Edition { get; set; }
        
        [Required]  
        public string Image { get; set; }

        public int AuteurId { get; set; }
        public Auteur Auteur { get; set; }
        
        public int CategorieId { get; set; }
        public Categorie Categorie { get; set; }
    }
}
