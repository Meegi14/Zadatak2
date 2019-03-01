using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zadatak.Models;
using Zadatak.Dto;
using AutoMapper.QueryableExtensions;

namespace Zadatak.Controllers
{
    [Route("api/[controller]")]
    public abstract class BaseController<TEntity, TDtoGet, TDtoPost, TDtoPut> : Controller where TEntity : class where TDtoGet : class where TDtoPost : class where TDtoPut : class  
    {
        protected readonly ZadatakContext _context;
        private readonly DbSet<TEntity> _dbSet;
        private readonly IMapper _mapper;

        protected BaseController(ZadatakContext context, IMapper mapper)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
            _mapper = mapper;

        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public virtual IActionResult Get()
        {
            var all = _dbSet.ProjectTo<TDtoGet>(_mapper.ConfigurationProvider);

            
            if (all != null)
            {
                return Ok(all.ToList());
            }

            return NotFound();
            
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public virtual IActionResult Get(int id)
        {
            var found = _dbSet.Find(id);

            var otr  = _mapper.Map<TDtoGet>(found);

            if (otr != null)
            {
                return Ok(otr);
            }

            return NotFound();
        }
                
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public virtual IActionResult Post(TDtoPost input)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var otr = _mapper.Map<TEntity>(input);

                    _dbSet.Add(otr);
                    _context.SaveChanges();
                    transaction.Commit();
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
        }
                
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public virtual IActionResult Put(int id, TDtoPut input)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var found = _dbSet.Find(id);
                    // Map from input obj to found obj
                    _mapper.Map<TDtoPut, TEntity>(input, found);
                    _context.SaveChanges();
                    transaction.Commit();
                    return Ok();
                }
                catch (Exception exception)
                {
                    return BadRequest(exception.ToString());
                }
            }

        }

        
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public virtual IActionResult Delete(int id)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                var found = _dbSet.Find(id);

                if (found != null)
                {
                    try
                    {
                        _dbSet.Remove(found);
                        _context.SaveChanges();
                        transaction.Commit();
                        return Ok();
                    }
                    catch (Exception)
                    {
                        return BadRequest();
                    }
                }

                return NotFound();
            }
        }


    }

    
}
