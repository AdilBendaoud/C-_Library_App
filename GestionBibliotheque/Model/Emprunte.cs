using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBibliotheque.Model
{
    internal class Emprunte
    {
        public int EmprunteId { get; set; }
        public DateTime DateRetourPrevue {  get; set; }
        public DateTime DateRetourReelle { get; set; }
        public DateTime DateEmprunte { get; set; }
        public decimal PrixPaye { get; set; }

        [NotMapped]
        public string DateRetourPrevueString { get; set; }

        [NotMapped]
        public string? DateRetourReelleString { get; set; }

        [NotMapped]
        public string DateEmprunteString { get; set; }

        public int LivreId { get; set; }
        public Livre Livre { get; set;}

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
