using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zadatak.Models;
using Zadatak.Dto.OsobaDto;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Zadatak.Dto.KancelarijaDto;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Zadatak.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OsobaController : BaseController<Osoba, OsobaDtoGet, OsobaDtoPost, OsobaDtoPut>
    {
        private readonly IMapper _mapper;

        /// <inheritdoc />
        public OsobaController(ZadatakContext context, IMapper mapper) : base(context, mapper)
        {
            _mapper = mapper;
        }

        
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public override IActionResult Post(OsobaDtoPost input)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    if (input != null)
                    {
                        // OsobaDto to Osoba obj
                        var osobaInput = _mapper.Map<Osoba>(input);

                        // Nova Osoba
                        var osoba = new Osoba
                        {
                            Ime = osobaInput.Ime,
                            Prezime = osobaInput.Prezime,
                            KancelarijaForeignKey = osobaInput.KancelarijaForeignKey
                        };
                        _context.Osobe.Add(osoba);
                        _context.SaveChanges();

                        // Find last added person ofice id
                        var poslednjaOsoba = _context.Osobe.Last();
                        var poslednjaOsobaKancelarija = poslednjaOsoba.KancelarijaForeignKey;

                        // Find office where is last added person
                        var kancelarijaIme = _context.Kancelarije.FirstOrDefault(o => o.Id == poslednjaOsobaKancelarija);

                        // Add person into office list
                        var osobaList = kancelarijaIme.Osobe;
                        osobaList.Add(osoba);
                        transaction.Commit();

                        return Ok();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public override IActionResult Put(int id, OsobaDtoPut input)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var all = _context.Osobe.Include(o => o.Kancelarija);
                    // Find office id for person
                    var kancelarijaKey = all.Where(x => x.OsobaId == id).Select(c => c.KancelarijaForeignKey).FirstOrDefault();
                    // Find person
                    var foundOsoba = _context.Osobe.Find(id);

                    if (foundOsoba != null)
                    {
                        var inputOsoba = _mapper.Map<Osoba>(input);

                        foundOsoba.Ime = inputOsoba.Ime;
                        foundOsoba.Prezime = inputOsoba.Prezime;
                        if (inputOsoba.KancelarijaForeignKey
                             != 0)
                        {
                            // Change office if specified
                            foundOsoba.KancelarijaForeignKey = inputOsoba.KancelarijaForeignKey;
                        }
                        else
                        {
                            // Keep the same ofice id if not specified
                            foundOsoba.KancelarijaForeignKey = kancelarijaKey;
                        }
                        _context.SaveChanges();
                        transaction.Commit();

                        return Ok();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }

            return NotFound();
        }

        [HttpGet("GetByKancelarija")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetByOffice(string kancelarijaIme)
        {
            var allKancelarije = _context.Kancelarije;

            

            var query = allKancelarije.Where(x => x.Ime == kancelarijaIme)
                .ProjectTo<KancelarijaDtoGet>(_mapper.ConfigurationProvider);

            if (query != null)
            {
                return Ok(query);
            }

            return NotFound();
        }
    }

}


