using SisProdutos.Date;
using SisProdutos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisProdutos.Service
{
    public class ServiceProduto
    {
        public List<CidadeResponse> GetCidadeProduto(ProdutoContext _context, int ProdutoId)
        {
            var produtoCidadesList = _context.CidadeResponse.Where(produto => produto.IdCidade == ProdutoId).ToList();
            var CidadeList = new List<CidadeResponse>();
            foreach (var produtoCidade in produtoCidadesList)
            {
                CidadeResponse cidade = _context.CidadeResponse.FirstOrDefault(cidade => cidade.IdCidade == produtoCidade.IdCidade);
                CidadeList.Add(cidade);
            }
            return CidadeList;
        }
    }
}
