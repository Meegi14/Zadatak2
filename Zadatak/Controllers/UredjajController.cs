using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Zadatak.Models;
using Zadatak.Dto.UredjajDto;
using Microsoft.AspNetCore.Mvc;

namespace Zadatak.Controllers
{
    [Route("api/[controller]")]
    public class UredjajController : BaseController<Uredjaj, UredjajDtoGet, UredjajDtoPost, UredjajDtoPut>
    {
        /// <inheritdoc />
        public UredjajController(ZadatakContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
