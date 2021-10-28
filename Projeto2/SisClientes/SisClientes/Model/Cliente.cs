using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SisClientes.Model
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo data de nascimento obrigatório")]
        public DateTime Data_Nascimento { get; set; }
        public int CidadeId { get; set; }
        [Required(ErrorMessage = "O campo Cep é obrigatório")]
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public virtual Cidade Cidade { get; set; }
    }
}
