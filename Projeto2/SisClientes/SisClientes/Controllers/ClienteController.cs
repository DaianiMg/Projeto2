using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SisClientes.Configuration;
using SisClientes.Date.ClienteDto;
using SisClientes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SisClientes.Controllers
{
    [ApiController]
    [Route("api/cliente/")]
    public class ClienteController : ControllerBase
    {

        private SisClientesContext _context;
        private IMapper _mapper;


        public ClienteController(SisClientesContext context, IMapper mapper)
        {

            _context = context;
            _mapper = mapper;

        }

        [HttpPost]
        public async Task<IActionResult> AdicionaCliente([FromBody] CreateClienteDto clienteDto )
        {

            Cliente cliente = _mapper.Map<Cliente>(clienteDto);
            var httpClient = new HttpClient();
            var url = await httpClient.GetStringAsync("http://viacep.com.br/ws/" + clienteDto.Cep + "/json");

            var teste = JsonConvert.DeserializeObject<CepResponse>(url);


            Cidade cidade = _context.Cidade.FirstOrDefault(cidade => cidade.Nome == teste.localidade && cidade.Estado == teste.uf);

            if (cidade != null)
            {
                cliente.CidadeId = cidade.Id;
                _context.Cliente.Add(cliente);
                _context.SaveChanges();
                return CreatedAtAction(nameof(RecuperaClientePorId), new { Id = cliente.Id }, cliente);
            }

            return NotFound();

        }

        [HttpGet]
        public IActionResult RecuperaCliente()
        {
            var clienteDto = _mapper.Map<List<Cliente>, List<ReadClienteDto>>(_context.Cliente.ToList());
            return Ok(clienteDto);
        }


        [HttpGet("{Id}")]
        public IActionResult RecuperaClientePorId([FromQuery]int id)
        {
            Cliente cliente = _context.Cliente.FirstOrDefault(cliente => cliente.Id == id);
            if (cliente != null)
            {
                ReadClienteDto clienteDto = _mapper.Map<ReadClienteDto>(cliente);

                return Ok(clienteDto);
            }
            return NotFound();
        }

        [HttpPut("{Id}")]
        public IActionResult AtualizaCliente([FromQuery] int id, UpdateClienteDto clienteDto)
        {
            Cliente cliente = _context.Cliente.FirstOrDefault(cliente => cliente.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            _mapper.Map(clienteDto, cliente);

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public IActionResult DeletaCliente([FromQuery] int id)
        {
            Cliente cliente = _context.Cliente.FirstOrDefault(cliente => cliente.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            _context.Remove(cliente);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
