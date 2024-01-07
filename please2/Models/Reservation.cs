using System.ComponentModel.DataAnnotations.Schema;

namespace please2.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string Book { get; set; }
        public int Bookid { get; set; }
        public string Adherent {  get; set; }
        public string  Adherentid { get; set; }
    }
}


