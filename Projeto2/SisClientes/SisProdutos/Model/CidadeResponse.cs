using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SisProdutos.Model
{
    public class CidadeResponse
    {
        [Key]
        public int IdCidade { get; set; }
        public string cep { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }

    }
    
}
