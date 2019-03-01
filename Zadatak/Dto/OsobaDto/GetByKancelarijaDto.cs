using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zadatak.Dto.OsobaDto
{
    public class GetByKancelarijaDto
    {
        public string KancelarijaIme { get; set; }
        public List<OsobaDtoGet> Osobe { get; set; }
    }
}
