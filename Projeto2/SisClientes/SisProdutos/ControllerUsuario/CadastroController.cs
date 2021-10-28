using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SisProdutos.Date.DtosUsuario;
using SisProdutos.Model;
using SisProdutos.ServicesUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SisProdutos.ControllerUsuario
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase
    {
        private CadastroService _cadastroService;

        public CadastroController(CadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        [HttpPost]
        public IActionResult CadastraUsuario(CreateUsuarioDto createDto)
        {
            //var httpClient = new HttpClient();
            //var url = await httpClient.GetStringAsync("https://localhost:5001/cliente/" + usuario.Id);

            //var teste = JsonConvert.DeserializeObject<IdResponse>(url);



            Result resultado = _cadastroService.CadastraUsuario(createDto);
            if (resultado.IsFailed) return StatusCode(500);
            return Ok();
        }
    }
}
