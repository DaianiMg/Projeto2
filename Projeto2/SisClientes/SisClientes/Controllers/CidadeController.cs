using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SisClientes.Configuration;
using SisClientes.Date.CidadeDto;
using SisClientes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisClientes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CidadeController : ControllerBase
    {

        private SisClientesContext _context;
        private IMapper _mapper;
        public CidadeController(SisClientesContext context, IMapper mapper)
        {

            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaCidade([FromBody] CreateCidadeDto cidadeDto)
        {



            Cidade cidade = _mapper.Map<Cidade>(cidadeDto);
            _context.Cidade.Add(cidade);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaCidadePorId), new { id = cidade.Id }, cidade);

        }

        [HttpGet]
        public IActionResult RecuperaCidades()
        {
            var cidadeDto = _mapper.Map<List<Cidade>, List<ReadCidadeDto>>(_context.Cidade.ToList());
            return Ok(cidadeDto);
        }

        [HttpGet("{Id}")]
        public IActionResult RecuperaCidadePorId([FromQuery] int id)
        {
            Cidade cidade = _context.Cidade.FirstOrDefault(cidade => cidade.Id == id);
            if (cidade != null)
            {
                ReadCidadeDto cidadeDto = _mapper.Map<ReadCidadeDto>(cidade);

                return Ok(cidadeDto);
            }
            return NotFound();
        }

        [HttpPut("{Id}")]
        public IActionResult AtualizaCidade([FromQuery] int id,  UpdateCidadeDto cidadeDto)
        {
            Cidade cidade = _context.Cidade.FirstOrDefault(cidade => cidade.Id == id);
            if (cidade == null)
            {
                return NotFound();
            }

            _mapper.Map(cidadeDto, cidade);

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public IActionResult DeletaCidade([FromQuery] int id)
        {
            Cidade cidade = _context.Cidade.FirstOrDefault(cidade => cidade.Id == id);
            if (cidade == null)
            {
                return NotFound();
            }
            _context.Remove(cidade);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
