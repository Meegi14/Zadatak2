using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Zadatak.Models
{
    public class Osoba
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long OsobaId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        public long KancelarijaForeignKey { get; set; }

        [ForeignKey("KancelarijaForeignKey")]
        public Kancelarija Kancelarija { get; set; }

        public IList<Uredjaj> Uredjaji { get; set; }
    }

}
