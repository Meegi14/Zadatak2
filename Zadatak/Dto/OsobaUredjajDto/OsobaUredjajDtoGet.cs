using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zadatak.Dto.OsobaUredjajDto
{
    public class OsobaUredjajDtoGet
    {
        public string Osoba { get; set; }
        public string Uredjaj { get; set; }
        public DateTime VrijemeOd { get; set; }
        public DateTime? VrijemeDo { get; set; }
    }
}
