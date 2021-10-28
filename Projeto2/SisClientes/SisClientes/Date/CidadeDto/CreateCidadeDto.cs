using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SisClientes.Date.CidadeDto
{
    public class CreateCidadeDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo Estado É obrigatório")]
        public string Estado { get; set; }
    }
}
