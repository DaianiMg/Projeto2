using SisProdutos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisProdutos.Date.DtosProduto
{
    public class ReadProdutoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public float Preco { get; set; }
        public string Palavra_Chave { get; set; }
        public string Categoria { get; set; }
        public List<CidadeResponse> CidadeList { get; set; }
    }
}
