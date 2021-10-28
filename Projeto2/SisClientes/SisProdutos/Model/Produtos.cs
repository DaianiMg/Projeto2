using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SisProdutos.Model
{
    public class Produtos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public float Preco { get; set; }
        public string Palavra_Chave { get; set; }
        public string Categoria { get; set; }
        //public List<Produtos> Produto_Cidade { get; set; }
        public virtual CidadeResponse Cidade { get; set; }
    }
}
