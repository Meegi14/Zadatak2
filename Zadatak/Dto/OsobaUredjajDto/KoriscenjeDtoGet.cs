using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zadatak.Dto.OsobaUredjajDto
{
    public class VrijemeOsobaUredjajDtoGet
    {
        public string Uredjaj { get; set; }
        public IEnumerable<OsobaUredjajDtoGet> OsobeUredjaji { get; set; }
    }
}
