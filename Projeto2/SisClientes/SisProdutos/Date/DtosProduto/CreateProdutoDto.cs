using SisProdutos.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SisProdutos.Date.DtosProduto
{
    public class CreateProdutoDto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public float Preco { get; set; }
        public string Palavra_Chave { get; set; }
        public string Categoria { get; set; }
        public List<CidadeResponse> CidadeList { get; set; }

    }
}
