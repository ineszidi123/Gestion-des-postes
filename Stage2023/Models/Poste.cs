using System.ComponentModel.DataAnnotations;

namespace Stage2023.Models
{
    public class Poste
    {
        [Key]
        public long id { get; set; }
        public long IdTypeposteFK { get; set; }

        public string Nomreseau { get; set; } = null!;

        public string Libelle { get; set; } = null!;

        public bool Actif { get; set; }
        public TypePoste typePoste { get; set; } = null!;
        public Poste()
        {
            
        }
        public Poste(long IdTypeposteFK, string Nomreseau, string Libelle, bool Actif)
        {
            
             this.IdTypeposteFK = IdTypeposteFK;
            this.Nomreseau = Nomreseau;
            this.Libelle = Libelle;
            this.Actif = Actif;
            


        }

        //public Poste(string nomreseau, string libelle, bool? actif)
        //{
           // Nomreseau = nomreseau;
            //Libelle = libelle;
            //Actif = actif;
        //}
    }
}
