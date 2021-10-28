using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SisClientes.Model
{
    public class CidadesCliente
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; }
        public int CidadeId { get; set; }
        [Required(ErrorMessage = "O campo Cep é obrigatório")]
        public string ClienteId { get; set; }
        public bool CidadePrincipal { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Cidade Cidade { get; set; }

    }
}
