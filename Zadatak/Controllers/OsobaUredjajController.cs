
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Zadatak.Models;
using Zadatak.Dto.OsobaUredjajDto;
using AutoMapper.QueryableExtensions;

namespace Zadatak.Controllers
{
    namespace OfficeApp.Controllers
    {
        [Route("api/[controller]")]
        public class UsageController : Controller
        {
            private static ZadatakContext _context;
            private IMapper _mapper;

            public UsageController(ZadatakContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
                       
            [HttpGet]
            [ProducesResponseType(200)]
            [ProducesResponseType(404)]
            public IActionResult Get()
            {
                var allKoriscenje = _context.OsobeUredjaji;

               

                var query = allKoriscenje.ProjectTo<OsobaUredjajDtoGet>(_mapper.ConfigurationProvider);

                if (query.Any())
                {
                    return Ok(query.ToList());
                }

                return NotFound();
            }

           
            [HttpGet("{osobaId}")]
            [ProducesResponseType(200)]
            [ProducesResponseType(404)]
            public IActionResult Get(int osobaId)
            {
                var allUsages = _context.OsobeUredjaji;

               

                var query = allUsages.Where(u => u.OsobaId == osobaId).ProjectTo<OsobaUredjajDtoGet>(_mapper.ConfigurationProvider);
                if (query.Any())
                {
                    return Ok(query.ToList());
                }

                return NotFound();
            }
                       
            [HttpGet("Svi uredjaji/{id}")]
            [ProducesResponseType(200)]
            [ProducesResponseType(404)]
            public IActionResult AllByDevice(int uredjajId)
            {
                var allKoriscenje = _context.OsobeUredjaji;

               

                var query = allKoriscenje.Where(d => d.UredjajId == uredjajId)
                    .ProjectTo<OsobaUredjajDtoGet>(_mapper.ConfigurationProvider);

                if (query.Any())
                {
                    return Ok(query.ToList());
                }

                return NotFound();
            }

            /*
            [ProducesResponseType(200)]
            [ProducesResponseType(404)]
            public IActionResult AllByPerson(int osobaId)
            {
                var allKoriscenje = _context.OsobeUredjaji;
                               
                var query = allKoriscenje.Where(p => p.OsobaId == osobaId).GroupBy(d => d.Uredjaj.Ime)
                    .Select(x => new KoriscenjeDtoGet { Uredjaj = x.Key, OsobeUredjaji = x.Select(y => new KoriscenjeDtoGet { VrijemeOd = y.VrijemeOd, VrijemeDo = y.VrijemeDo })
                    });

                if (query.Any())
                {
                    return Ok(query.ToList());
                }

                return NotFound();
            }
            */

            [HttpGet("Vrijeme koriscenja")]   
            [ProducesResponseType(200)]
            [ProducesResponseType(404)]
            public IActionResult TimeUsedByPerson(int osobaId)
            {
                var allOsobeUredjaji = _context.OsobeUredjaji;

                var query = allOsobeUredjaji.Where(p => p.OsobaId == osobaId).GroupBy(x => x.Uredjaj.Ime)
                    .Select(y => new VrijemePoOsobiDto
                    {
                        Uredjaj = y.Key,
                        VrijemeKoriscenja = new TimeSpan(y.Sum(u => (u.VrijemeDo.Value != null ? u.VrijemeDo.Value.Ticks : DateTime.Now.Ticks) - u.VrijemeOd.Ticks)).ToString(@"dd\.hh\:mm\:ss")
                    });

                if (query.Any())
                {
                    return Ok(query.ToList());
                }

                return NotFound();
            }
        }
    }
}
