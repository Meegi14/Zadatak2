using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zadatak.Models;
using Zadatak.Dto.KancelarijaDto;
using AutoMapper;

namespace Zadatak.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KancelarijaController : BaseController<Kancelarija, KancelarijaDtoGet, KancelarijaDtoPost, KancelarijaDtoPut>
    {

        private readonly IMapper _mapper;

        
        public KancelarijaController(ZadatakContext context, IMapper mapper) : base(context, mapper)
        {
            _mapper = mapper;
        }

        /*
        private readonly ZadatakContext _context;

        public KancelarijaController(ZadatakContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetKancelarije()
        {
            return Ok(_context.Kancelarije.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetKancelarijeById(long id)
        {
            var kancelarija = _context.Kancelarije.Find(id);

            if(kancelarija == null)
            {
                return NotFound("Ne postoji kancelarija.");
            }

            return Ok(kancelarija);
        }

        [HttpPost]
        public IActionResult CreateKancelarija(Kancelarija kancelarija)
        {
            _context.Kancelarije.Add(kancelarija);
            _context.SaveChanges();

            return CreatedAtAction("CreateKancelarija", new { id = kancelarija.Id, ime = kancelarija.Ime }, kancelarija);
        }
        */
     }
}